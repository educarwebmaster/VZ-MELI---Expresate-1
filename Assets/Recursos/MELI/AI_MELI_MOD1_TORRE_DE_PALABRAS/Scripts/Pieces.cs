using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class Pieces : MonoBehaviour {
    public bool isTrue;
    public bool selectPiece;
    LeanCameraMove _cameraMove = new LeanCameraMove();
    LeanCameraZoom _cameraZoom = new LeanCameraZoom();

    private void OnMouseDown() {
        selectPiece = true;
        selectPieces(selectPiece);
    }

    public void selectPieces(bool select) {
        if (select) {
            if (isTrue) {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else {
                gameObject.SetActive(false);
            }
        }
    }
}
