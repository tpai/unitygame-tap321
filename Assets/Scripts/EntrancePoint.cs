using UnityEngine;
using System.Collections;

public class EntrancePoint : MonoBehaviour {

	void Start () {
		GameManager.instance.SetGameState (GameState.Game);
		BallSpawner.instance.SpawnBall ();
	}
}
