using System;
using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	private static BallSpawner m_instance;
	public static BallSpawner instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<BallSpawner>();
			}
			return m_instance;
		}
	}

	public GameObject ballPrefab;

	private int m_amt;
	private float m_wait;
	public float OffsetTime { get { return m_wait; } }
	private float m_exploTime;

	public void SpawnBall () {

		SoundManager.instance.SetSong (Level.instance.Now);

		switch (Level.instance.Now) {
		case 1:
			m_wait = .5f;
			m_exploTime = 3f;
			break;
		case 2:
			m_wait = .4f;
			m_exploTime = 2.5f;
			break;
		case 3:
			m_wait = .3f;
			m_exploTime = 2f;
			break;
		case 4:
			m_wait = .2f;
			m_exploTime = 1.5f;
			break;
//		case 5:
//			m_wait = .15f;
//			m_exploTime = 1.3f;
//			break;
		default:
			goto case 4;
		}
		m_amt = Convert.ToInt32(Mathf.Floor(SoundManager.instance.GetSongTime () / m_wait));
		Debug.Log (m_amt);
		StartCoroutine ("Spawn", m_amt);
	}

	void ReadyToNextLevel () {
		CancelInvoke ("IsAnyBallExist");
		Level.instance.Next (); // next level
	}
	
	IEnumerator Spawn (int amt) {
		for (int i=0; i<amt; i++) {
			yield return new WaitForSeconds (m_wait);
			GameObject ball = (GameObject)Instantiate (
				ballPrefab, 
				new Vector3 (
					UnityEngine.Random.Range (-2.5f, 2.5f),
					UnityEngine.Random.Range (-4f, 4f),
					0f
				),
				Quaternion.identity
			);
			ball.transform.parent = transform;
			ball.GetComponent<Ball>().exploTime = m_exploTime;
			if (i == amt - 1)ReadyToNextLevel ();
		}
	}

	public void StopAll () {
		StopCoroutine ("Spawn");
		CancelInvoke ("IsAnyBallExist");
	}
}
