using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {

	void FixedUpdate () {

		Touch[] myTouches = Input.touches;
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (myTouches[i].phase == TouchPhase.Stationary) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (myTouches[i].position), Vector3.forward);
				if (hit.collider != null) {
					hit.collider.SendMessage ("AddScore");
					SoundManager.instance.Play ();
					Destroy (hit.collider.gameObject);
				}
			}
		}
	
	}
}
