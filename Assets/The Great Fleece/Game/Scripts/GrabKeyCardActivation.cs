using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour 
{
    [SerializeField]
    private GameObject _sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
