using UnityEngine;
using System.Collections;

public class CAMBIAR_OBJETOS_FLECHAS : MonoBehaviour {
    public TextMesh[] texto;
    public int tama;
    public Vector3 trans;
	// Use this for initializan
	void Start () {
        tama = 1;
        trans = this.transform.localScale;
	}
	

    public void Aumentar()
    {
        if (tama < 3)
        {
            tama += 1;
            Verificar();
        }
    }

    public void Disminuir()
    {
        if (tama > 1)
        {
            tama -= 1;
            Verificar();
        }
    }

    public void Verificar()
    {
        if (tama == 1)
        {
            /*transform.localScale = trans.localScale;*/
            transform.localScale = new Vector3(trans.x, trans.y, trans.z);
            CambiarTextos(3);
        }

        if (tama == 2)
        {
            /*transform.localScale = trans.localScale * 1.5f;*/
            transform.localScale = new Vector3(trans.x * 1.3f, trans.y * 1.3f, trans.z * 1.3f);
            CambiarTextos(5);
        }

        if (tama == 3)
        {
            /*transform.localScale = trans.localScale * 2.0f;*/
            transform.localScale = new Vector3(trans.x * 1.7f, trans.y * 1.7f, trans.z * 1.7f);
            CambiarTextos(10);
        }
    }

    public void CambiarTextos(int Numero)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            texto[i].text = "" + Numero;
        }
    }
}
