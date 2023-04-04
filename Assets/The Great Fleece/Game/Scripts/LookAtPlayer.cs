using UnityEngine;

public class LookAtPlayer : MonoBehaviour 
{
	public Transform target;
    public Transform startCamera;

    // Use this for initialization
    void Start()
    {
        transform.position = startCamera.transform.position;
        transform.rotation = startCamera.transform.rotation;
    }
    
    // Update is called once per frame
    void Update () 
	{
		transform.LookAt(target);
	}
}
