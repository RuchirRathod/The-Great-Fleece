using UnityEngine;

public class WinStateActivation : MonoBehaviour 
{

    [SerializeField]
    private GameObject _levelCompleteCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                _levelCompleteCutscene.SetActive(true);
            }
            else
            {
                _levelCompleteCutscene.SetActive(false);
            }
        }
    }
}
