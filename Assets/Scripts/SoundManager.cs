using UnityEngine;
using UnityEngine.UI;
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

	public AudioClip[] clip;
	public AudioSource source;
	public Slider timeSlider;
	public float playTime = 0f;

	public void SetSong (int i) {
		source.clip = clip[i-1];
		timeSlider.maxValue = source.clip.length;
	}

	public float GetSongTime () {
		return source.clip.length;
	}

	void FixedUpdate () {
		playTime -= Time.deltaTime;
		timeSlider.value = source.time;

		if (playTime <= 0f) {
			playTime = 0f;
			Stop ();
		}
		else
			Play ();
	}

	public void AddPlayTime (float time) {
		playTime += time;
		if (playTime >= 2f)
			playTime = 2f;
	}

	void Play () {
		if (source.time > 0)
			source.UnPause ();
		else
			source.Play ();
	}

	void Stop () {
		source.Pause ();
	}
}
