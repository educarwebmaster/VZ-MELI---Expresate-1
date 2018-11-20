using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Formulario : MonoBehaviour {
    public string porstURL = "";
    public InputField nombre;
    public InputField email;
    public InputField asunto;
    private string maquina;
    private string maquina2;
    private char espacio = ' ';
    void Start()
    {
        maquina = "modelo:_" + SystemInfo.deviceModel + "_almacenamiento:_" + SystemInfo.systemMemorySize + "_sistema_operativo:_" + SystemInfo.operatingSystem;
        maquina2 = maquina.Replace(" ", "");
        Debug.Log(maquina2);
    }

    void Update()
    {

    }

    public void Enviar()
    {
        StartCoroutine("SaveName");
    }

    public IEnumerator SaveName()
    {
        string urlString = porstURL + "?name=" + nombre.text + "&mail=" + email.text + "&dispositivo=" + maquina2 + "&asunto=" + asunto.text;
        Debug.Log("Sending : " + urlString);
        WWW postName = new WWW(urlString);
        yield return postName;
        Debug.Log(postName.text);
    }
}
