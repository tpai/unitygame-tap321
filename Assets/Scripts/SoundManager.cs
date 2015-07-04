using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager m_instance;
	public static SoundManager instance
	{
		get
		{
			if (m_instance == false)
			{
				m_instance = FindObjectOfType<SoundManager>();
			}
			return m_instance;
		}
	}

	public AudioClip[] clips;
	public AudioSource source;

	public void Play () {
		source.clip = clips [Random.Range (0, clips.Length)];
		source.Play ();
	}
}
