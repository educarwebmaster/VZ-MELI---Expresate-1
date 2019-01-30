using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class CameraCons : MonoBehaviour {
	[SerializeField] private float LimXLeft, LimXRight, LimYUp, LimYDown, _SpeedLerp;
	private Vector3 currentPosition;

	private LeanCameraZoom _LeanCameraZoom = new LeanCameraZoom();
	private void Update() {
		currentPosition = transform.position;

		if (transform.position.x < LimXLeft) {
			currentPosition.x = LimXLeft;
		}
		else if (currentPosition.x > LimXRight) {
			currentPosition.x = LimXRight;
		}

		if (transform.position.y < LimYDown) {
			currentPosition.y = LimYDown;
		}
		else if (currentPosition.y > LimYUp) {
			currentPosition.y = LimYUp;
		}

		transform.position = Vector3.Lerp(transform.position, currentPosition,_SpeedLerp * Time.deltaTime);

//		if (_LeanCameraZoom.Zoom >= 10.0f) {
//			Debug.Log("entre");
//			transform.position = Vector3.Lerp(transform.position, currentPosition,0.05f * Time.deltaTime);
//		}
//		else {
//			Debug.Log("entre2");
//			transform.position = Vector3.Lerp(transform.position, currentPosition,10.0f * Time.deltaTime);
//		}

	}
}
