using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {

	public float exploTime = 3f;
	public Text timeText;
	public SpriteRenderer spriteRenderer;

	private bool m_isBoom = false;

	void FixedUpdate () {

		if (m_isBoom)
			return;

		exploTime -= Time.deltaTime;
		timeText.text = exploTime.ToString ("0");
		transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale + Vector3.one, Time.deltaTime * 2f);
		spriteRenderer.color = Color.Lerp (spriteRenderer.color, Color.red, Time.deltaTime * 1f);

		if (exploTime <= 0) {
			exploTime = 0;
			m_isBoom = true;
			Lives.instance.LostOne ();
			Destroy (gameObject);
		}
	}
}
