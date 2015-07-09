using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {

	void FixedUpdate () {

#if UNITY_EDITOR
//		if (Input.GetButtonDown("Fire1")) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.forward);
			if (hit.collider != null) {
				SoundManager.instance.AddPlayTime (BallSpawner.instance.OffsetTime);
				Destroy (hit.collider.gameObject);
			}
//		}
#else
		Touch[] myTouches = Input.touches;
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (myTouches[i].phase == TouchPhase.Stationary) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (myTouches[i].position), Vector3.forward);
				if (hit.collider != null) {
					SoundManager.instance.AddPlayTime (BallSpawner.instance.OffsetTime);
					Destroy (hit.collider.gameObject);
				}
			}
		}
#endif
	}
}
