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

	public Text levelText;

	private int m_nowLevel = 1;
	public int Now { get { return m_nowLevel; } set { m_nowLevel = value; } }

	void Reset () {
		m_nowLevel = 1;
	}

	public void Next () {
		m_nowLevel ++;
		switch (m_nowLevel) {
		case 2:
			levelText.text = "L10"; break;
		case 3:
			levelText.text = "L99";
			levelText.color = Color.blue;
			break;
		case 4:
			levelText.text = "100";
			levelText.color = Color.red;
			break;
		case 5:
			levelText.text = "MAX";
			levelText.color = Color.black;
			break;
		}
		BallSpawner.instance.SpawnBall ();
	}
}
