//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System;
//
//public class CONTROLADOR_PREGUNTAS : MonoBehaviour {
//    public GameObject[] Preguntas;
//    public int Size_preguntas;
//    public int Calificados;
//    public int PreguntaActual = 0;
//    public int Puntos = 0;
//    public GameObject Retroalimentacion_buena;
//    public GameObject Retroalimentacion_mala;
//    public int Minuto;
//    public int Segundo;
//    public int Limite_tiempo;
//    public string Fecha_limite;
//    public Animator anim_malo;
//    public Animator anim_bueno;
//    public string Tiempo = "";
//    public Text tiempo_bueno;
//    public Text tiempo_malo,puntaje_bueno,puntaje_malo,Tiempo_text;
//    public bool Cuestionario_iniciado = false;
//    public MOODLE moodle;
//    int porcentaje;
//    WWW www;
//    public string BBDD;
//    public GameObject Cuestionarios;
//    public GameObject Cursos;
//    
//    void Start ()
//    {
//        Retroalimentacion_buena.SetActive(false);
//        Retroalimentacion_mala.SetActive(false);
//        PreguntaActual = 1;
//    }
//	
//	void Update ()
//    {
//        if (Cuestionario_iniciado)
//        {
//            Tiempo_text.text = "" + Minuto + ":" + Segundo;
//        }
//    }
//
//    public void Restaurar()
//    {
//        Calificados = 0;
//        PreguntaActual = 0;
//        Puntos = 0;
//        Retroalimentacion_buena.SetActive(false);
//        Retroalimentacion_mala.SetActive(false);
//    }
//
//    public void Iniciar()
//    {
//        for (int i = 0; i < Size_preguntas - 1; i++)
//        {
//            Preguntas[i].SetActive(false);
//        }
//        Preguntas[0].SetActive(true);
//    }
//
//    public void Next()
//    {
//        if (PreguntaActual < Size_preguntas)
//        {
//            PreguntaActual++;
//            for (int i = 0; i < Size_preguntas - 1; i++)
//            {
//                Preguntas[i].SetActive(false);
//            }
//            Preguntas[PreguntaActual - 1].SetActive(true);
//        }
//    }
//
//    public void Previus()
//    {
//        if (PreguntaActual > 1)
//        {
//            PreguntaActual--;
//            for (int i = 0; i < Size_preguntas; i++)
//            {
//                Preguntas[i].SetActive(false);
//            }
//            Preguntas[PreguntaActual - 1].SetActive(true);
//        }
//    }
//
//    public void Verify1(){
//        for(int i = 0;i < Size_preguntas - 1; i++){
//            Preguntas[i].GetComponent<PREGUNTA>().Terminar();
//        }
//        MostrarCalificacion();
//    }
//
//    public void MostrarCalificacion()
//    {
//        porcentaje = (Puntos * 100) / (Preguntas.Length - 1);
//        Debug.Log("nota " + porcentaje);
//        Debug.Log("numero de preguntas " + (Preguntas.Length - 1));
//        Tiempo = "" + Minuto + ":" + Segundo;
//        puntaje_bueno.text = "" + porcentaje;
//        tiempo_bueno.text = "" + Tiempo;
//        puntaje_malo.text = "" + porcentaje;
//        tiempo_malo.text = "" + Tiempo;
//        Cuestionario_iniciado = false;
//        for(int i = 0;i<Preguntas.Length;i++){
//            Destroy(Preguntas[i].gameObject);
//        }
//        StartCoroutine("Actualizar");
//        if (porcentaje < 50)
//        {
//            StopCoroutine("IniciarTiempo");
//            Retroalimentacion_buena.SetActive(false);
//            Retroalimentacion_mala.SetActive(true);
//            anim_malo.Play("RetroMala");
//        }
//        else
//        {
//            StopCoroutine("IniciarTiempo");
//            Retroalimentacion_buena.SetActive(true);
//            Retroalimentacion_mala.SetActive(false);
//            anim_bueno.Play("RetroBuena");
//        }
//    }
//
//    public void iniciar_t()
//    {
//        StartCoroutine("IniciarTiempo");
//    }
//
//    public IEnumerator Actualizar()
//    {
//        Cuestionarios.SetActive(false);
//        Cursos.SetActive(true);
//        www = new WWW(BBDD + "3&usuario=" + PlayerPrefs.GetString("NombreUsuario") + "&nota=" + porcentaje + "&code=" + PlayerPrefs.GetString("CodeTemp") + "&tiempo=" + Tiempo + "&fecha_limite=" + Fecha_limite);
//        yield return www;
//        Debug.Log(BBDD + "3&usuario=" + PlayerPrefs.GetString("NombreUsuario") + "&nota=" + porcentaje + "&code=" + PlayerPrefs.GetString("CodeTemp") + "&tiempo=" + Tiempo + "&fecha_limite=" + Fecha_limite);
//        string[] Respuesta = www.text.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);//quitar elementos inecesarios
//        
//        yield return new WaitForSeconds(3);
//        if(Respuesta[0] == "actualizado"){
//            moodle.Mensaje("Calificado",0);
//        }else{
//            if(Respuesta[0] == "caducado"){
//                moodle.Mensaje("El cuestionario a caducado",2);
//            }else{
//                moodle.Mensaje("Numero de intentos excedido",2);
//            }
//        }
//        
//        moodle.Actualizar();
//    }
//
//    public IEnumerator IniciarTiempo()
//    {
//        Segundo++;
//        if(Segundo>60){
//            Minuto++;
//            Segundo = 0;
//        }
//        if(Minuto >= Limite_tiempo){
//            MostrarCalificacion();
//        }
//        yield return new WaitForSeconds(1);
//        StartCoroutine("IniciarTiempo");
//    }
//
//    public void Cerrar_cuestionario()
//    {
//        PreguntaActual = 1;
//        Puntos = 0;
//        Minuto = 0;
//        Segundo = 0;
//        Calificados = 0;
//        Size_preguntas = 0;
//        Retroalimentacion_buena.SetActive(false);
//        Retroalimentacion_mala.SetActive(false);
//    }
//}
