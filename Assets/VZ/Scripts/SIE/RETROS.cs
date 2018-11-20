using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class RETROS_system_info
{
    public GameObject Info;
    public int Tiempo;

    public IEnumerator Info_c()
    {
        Info.SetActive(true);
        yield return new WaitForSeconds(Tiempo);
        Info.SetActive(false);
    }
}
public class RETROS : MonoBehaviour
{
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject Retralimentacion;
    public int Correctos;
    public int Incorrectos;
    public Text Buenos;
    public Text Malos;
    public float Tiempo;
    [HeaderAttribute("Array informaciones")]
    public RETROS_system_info[] Informacion;
    // Use this for initialization
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Aumentar()
    {
        Correctos++;
    }

    public void Disminuir()
    {
        Incorrectos++;
    }

    public void Verficar(int E1, int E2)
    {
        if (E1 >= E2)
        {
            
            RetroBuena.SetActive(true);
            RetroMala.SetActive(false);
            RetroBuena.GetComponent<Animator>().Play("RetroBuena");
        }
        else
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(true);
            RetroMala.GetComponent<Animator>().Play("RetroMala");
        }
        StartCoroutine("Ocultar");
    }

    public void Verficar2(int E1, int E2)
    {
        if (E1 >= E2)
        {
            RetroBuena.SetActive(true);
            RetroMala.SetActive(false);
        }
        else
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(true);
        }
    }

    public void Verificar_Final()
    {
        Retralimentacion.SetActive(true);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        Buenos.text = "" + Correctos;
        Malos.text = "" + Incorrectos;
    }

    public void Info(GameObject g)
    {

        StartCoroutine("Info_c", g);
        Debug.Log("iniciar tiempo" + Tiempo);
    }

    public IEnumerator Ocultar()
    {
        Debug.Log("iniciar corutina" + Tiempo);
        yield return new WaitForSeconds(3);
        Debug.Log("finalizar tiempo" + Tiempo);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
    }

    public IEnumerator FINAL()
    {
        yield return new WaitForSeconds(3);
        Verificar_Final();
    }

    public IEnumerator Info_c(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(Tiempo);
        g.SetActive(false);
    }

    public void Restore()
    {
        Retralimentacion.SetActive(false);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        Correctos = 0;
        Incorrectos = 0;
    }

    /* Nuevo Sistema de informacion */
    public void Informacion_mostrar(int Index)
    {
        StartCoroutine(Informacion[Index].Info_c());
    }
}