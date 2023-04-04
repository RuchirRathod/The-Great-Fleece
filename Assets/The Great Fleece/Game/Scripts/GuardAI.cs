using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour 
{
	public List<Transform> wayPoints;
	private NavMeshAgent _agent;
	[SerializeField]
	private int _currentTarget;
	private bool _reverseGuard;
	private bool _targetReached;
    private Animator _anim;
    public bool coinTossed;
    public Vector3 coinPos;

	// Use this for initialization
	void Start () 
	{
		_agent= GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", false);
                }
            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", true);
                }
            }

            if (distance < 1.0f && _targetReached == false)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }

                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
                {
                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverseGuard == true)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _reverseGuard = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);
            if (distance < 4.0f)
            {
                _anim.SetBool("Walk", false);
            }
        }
	}

	IEnumerator WaitBeforeMoving()
	{
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
        else if (_currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
        }

        if (_reverseGuard == true)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverseGuard = false;
                _currentTarget = 0;
            }
        }
        else
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count)
            {
                _reverseGuard = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
    }
}
