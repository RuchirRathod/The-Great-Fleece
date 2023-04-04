using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
	private NavMeshAgent _agent;
	private Animator _anim;
	private Vector3 _target;
	public GameObject coinPrefab;
	public AudioClip coinSoundEffect;
	private bool _coinTossed;

	// Use this for initialization
	void Start () 
	{
		_agent= GetComponent<NavMeshAgent>();
		_anim= GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if left click
		if(Input.GetMouseButtonDown(0))
		{
			//cast a ray from mouse position
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if(Physics.Raycast(rayOrigin, out hitInfo))
			{
				//debug the floor position hit
				//Debug.Log("Hit: " + hitInfo.point);

				/*//create object at floor position
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = hitInfo.point;*/


				_agent.SetDestination(hitInfo.point);
				_anim.SetBool("Walk", true);
				_target = hitInfo.point;
			}
		}

		float distance = Vector3.Distance(transform.position, _target);
		if(distance < 1.0f)
		{
			_anim.SetBool("Walk", false);
		}

        //if right click
        if (Input.GetMouseButtonDown(1) && _coinTossed == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
				_coinTossed = true;
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
				SendAIToCoinSpot(hitInfo.point);
            }
        }
    }

	void SendAIToCoinSpot(Vector3 coinPos)
	{
		GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
		foreach(var guard in guards)
		{
			NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();	
			GuardAI currentGuard = guard.GetComponent<GuardAI>();
			Animator currentAnim = guard.GetComponent<Animator>();

			currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
			currentAnim.SetBool("Walk", true);
			currentGuard.coinPos = coinPos;
		}
	}
}
