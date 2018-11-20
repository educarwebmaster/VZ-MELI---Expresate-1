using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Moneda
{
    public Image Imagen;
    public GameObject MonedaObjeto;
}

public class Monedas : MonoBehaviour {
    public int Cantidad;
    public Moneda[] Moneda;
    public GameObject[] Cache;
    public GameObject MonedaHijo;
    public Transform PadreMonedas;
    public Sprite MonedaActivada;
    public Sprite MonedaDesactivada;


    public void CrearMonedas(int Numero)
    {
        Cantidad = Numero;
        for (int i = 0; i< Cantidad;i++)
        {
            Moneda[i].MonedaObjeto = null;
            Moneda[i].Imagen = null;
            GameObject NewMoneda = Instantiate(MonedaHijo) as GameObject;
            NewMoneda.transform.SetParent(PadreMonedas,false);
            Moneda[i].MonedaObjeto = NewMoneda;
            Moneda[i].Imagen = NewMoneda.GetComponent<Image>();
            Cache[i] = NewMoneda;
            NewMoneda.GetComponent<Image>().sprite = MonedaDesactivada;
            NewMoneda.SetActive(true);
        }
    }

    public void DestruirMonedas()
    {
        for (int i = 0; i < Moneda.Length; i++)
        {
            Destroy(Cache[i]);
        }
    }

    public void ParticulasCrear(int Numero)
    {
        Moneda[Numero].MonedaObjeto.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(Moneda[Numero].MonedaObjeto.transform.GetChild(0).gameObject, 3);
        Moneda[Numero].Imagen.sprite = MonedaActivada;
    }
}
