using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	private static Lives m_instance;
	public static Lives instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<Lives>();
			}
			return m_instance;
		}
	}

	public GameObject livePrefab;

	private int m_nowLives;

	void Start () {
		m_nowLives = (PlayerPrefs.GetInt ("Lives")<=3)?3:PlayerPrefs.GetInt ("Lives");
		Display ();
	}

	void Display () {

		foreach (Transform child in transform)
			Destroy (child.gameObject);

		for (int i=1;i<=m_nowLives;i++) {
			GameObject obj = (GameObject)Instantiate (livePrefab);
			obj.transform.SetParent(transform, false);
			obj.GetComponent<RectTransform>().anchoredPosition = new Vector2 (i * 60f, 0f);
		}
	}

	public void LostOne () {
		if (m_nowLives > 0) {
			m_nowLives --;
			if (m_nowLives <= 0) {
				m_nowLives = 0;
				ShowPlayAgainUI ();
				BallSpawner.instance.StopAll ();
			}
			Display ();
		}
	}

	void ShowPlayAgainUI () {
		GameObject.Find ("GamePanel").GetComponent<Animator> ().SetBool ("Show", true);
	}
}
