using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour {

	private static Level m_instance;
	public static Level instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<Level>();
			}
			return m_instance;
		}
	}

	private int m_nowLevel = 1;
	public int Now { get { return m_nowLevel; } set { m_nowLevel = value; } }

	void Reset () {
		m_nowLevel = 1;
	}

	public void Next () {
		m_nowLevel ++;
		BallSpawner.instance.SpawnBall ();
	}
}
