using UnityEngine;
using System.Collections;

public enum GameState { NullState, Intro, MainMenu, Game }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {
	
	static GameManager _instance;
	private static object _lock = new object();
	
	public GameState gameState { get; private set; }
	public event OnStateChangeHandler OnStateChange;
	
	public static bool isActive { 
		get { 
			return _instance != null; 
		} 
	}
	
	public static GameManager instance
	{
		get
		{
			if (applicationIsQuitting) {
				return null;
			}
			lock(_lock)
			{
				if (_instance == null)
				{
					_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
					
					if (_instance == null)
					{
						GameObject go = new GameObject();
						_instance = go.AddComponent<GameManager>();
						go.name = "(singleton) "+typeof(GameManager).ToString();
						DontDestroyOnLoad(go);
					}
				}
				return _instance;
			}
		}
	}

	public void SetGameState(GameState gameState) {
		this.gameState = gameState;
		if(OnStateChange != null) {
			OnStateChange();
		}
	}
	
	private static bool applicationIsQuitting = false;
	public void OnDestroy () {
		applicationIsQuitting = true;
	}
}