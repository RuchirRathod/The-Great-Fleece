using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour 
{
	[SerializeField]
	private Image _progressBar;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(LoadLevelAsync());
	}

	IEnumerator LoadLevelAsync()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(2);
		while(operation.isDone == false)
		{
			_progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }        
	}
}
