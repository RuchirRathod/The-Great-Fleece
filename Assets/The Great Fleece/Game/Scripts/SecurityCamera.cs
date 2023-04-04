using System.Collections;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;
    [SerializeField]
    private Animator _anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            render.material.SetColor("_TintColor", color);
            _anim.enabled = false;
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);
    }
}