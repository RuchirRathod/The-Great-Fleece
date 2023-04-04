using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour 
{
    public AudioClip clipToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlayVoiceOver(clipToPlay);
        }
    }
}
