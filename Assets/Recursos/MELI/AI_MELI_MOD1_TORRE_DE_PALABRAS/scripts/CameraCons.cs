using UnityEngine;
using UnityEngine.UI;

namespace Recursos.MELI.TORRE_DE_PALABRAS.scripts
{
	public class CameraCons : MonoBehaviour {
		[SerializeField] private float LimXLeft, LimXRight, LimYUp, LimYDown, _SpeedLerp;
		private Vector3 currentPosition;
		public Slider _Slider;

	
		private void Update() {
		
			currentPosition = transform.position;

			if (transform.position.x < LimXLeft) {
				currentPosition.x = LimXLeft;
			}
			else if (currentPosition.x > LimXRight) {
				currentPosition.x = LimXRight;
			}

			if (transform.position.y < LimYDown) {
				if (_Slider.value < 30.2f)
				{
					LimYDown = 3.48f;
					LimXLeft = -3.0f;
				}
				else
				{
					LimYDown = 5.88f;
					LimXLeft = 0f;
				}

				/*if (_Slider.value < 20.2679f)
				{
					LimXLeft = -2.68f;
				}
				else
				{
					LimXLeft = 0f;
				}*/
				

				currentPosition.y = LimYDown;
				Debug.Log(LimXLeft);
				
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
}
