using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static Score m_instance;
	public static Score instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<Score>();
			}
			return m_instance;
		}
	}

	public Text scoreText;

	private int m_nowScore;

	void Reset () {
		m_nowScore = 0;
	}

	public void Add (int amt) {
		m_nowScore += amt;
	}

	void FixedUpdate () {
		scoreText.text = m_nowScore.ToString ("00000000");
	}
}
