using UnityEngine;

public class Eyes : MonoBehaviour 
{
    [SerializeField]
    private GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
