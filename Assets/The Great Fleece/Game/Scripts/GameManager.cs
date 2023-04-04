using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("GameManager is Null");
			}
			return _instance;
		}
	}

	public bool HasCard { get; set; }
	[SerializeField]
	private PlayableDirector _introCutscene;

	private void Awake()
	{
		_instance = this;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			_introCutscene.time = 60.0f;
			AudioManager.Instance.PlayMusic();
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
