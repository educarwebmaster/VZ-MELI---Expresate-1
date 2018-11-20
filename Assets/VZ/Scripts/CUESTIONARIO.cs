//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System;
//
//[System.Serializable]
//public class Respuestas
//{
//    public string ID;
//    public string Respuesta_Texto;
//    public string Valor;
//}
//
//[System.Serializable]
//public class Preguntas
//{
//    public string ID;
//    public string Pregunta_id;
//    public string Pregunta_texto;
//    public string Cuestionario_nombre;
//    public string Cantidad;
//    public string Tipo;
//}
//
//public class CUESTIONARIO : MonoBehaviour {
//    public Preguntas[] Preguntas_;
//    public Respuestas[] Respuestas_;
//    public MOODLE moodle;
//    public CONTROLADOR_PREGUNTAS Controlador_preguntas;
//    public string ID;
//    public string ID_pregunta;
//    public int intentos;
//    public string Nota_s;
//    public string Fecha_s;
//    public string Bienvenida_s;
//    public string cuestionario_s;
//    public string limite_s;
//    public Text texto_nombre;
//    public Text Bienvenido;
//    public Text Fecha_Cierre;
//    public Text Nota_text;
//    public Text Tiempo_limite;
//    public Image Calificacion;
//    public GameObject Hijo_pregunta;
//    public Transform Pabre_pregunta;
//    public GameObject[] Cache;
//    public bool calificado = false;
//    
//	void Start ()
//    {
//        texto_nombre.text = cuestionario_s;
//        Bienvenido.text = Bienvenida_s;
//        Fecha_Cierre.text = Fecha_s;
//        if(Nota_s == "999"){
//            Nota_text.text = "0";
//        }else{
//            calificado = true;
//            Nota_text.text = Nota_s;
//        }
//        Tiempo_limite.text = limite_s + " Minutos";
//
//        if(int.Parse(Nota_s) < 20 || int.Parse(Nota_s) == 999){
//            Calificacion.sprite = moodle.Caras[0];
//        }
//        if(int.Parse(Nota_s) >= 20 && int.Parse(Nota_s) < 40){
//            Calificacion.sprite = moodle.Caras[1];
//        }
//        if(int.Parse(Nota_s) >= 40 && int.Parse(Nota_s) < 60){
//            Calificacion.sprite = moodle.Caras[2];
//        }
//        if(int.Parse(Nota_s) >= 60 && int.Parse(Nota_s) < 80){
//            Calificacion.sprite = moodle.Caras[3];
//        }
//        if(int.Parse(Nota_s) >= 80){
//            Calificacion.sprite = moodle.Caras[4];
//        }
//        /*if(PlayerPrefs.HasKey("" + ID)){
//          
//        }else{
//           PlayerPrefs.SetInt("" + ID, 0);
//        }*/
//	}
//
//    public void Destruir_cache()
//    {
//        for (int i = 0; i < Cache.Length;i++)
//        {
//            Destroy(Cache[i]);
//        }
//    }
//
//    public void Crear_Preguntas()
//    {
//        Destruir_cache();
//        Controlador_preguntas.Limite_tiempo = int.Parse(limite_s);
//        Controlador_preguntas.Fecha_limite =  Fecha_s;
//        Controlador_preguntas.iniciar_t();
//        Controlador_preguntas.Cuestionario_iniciado = true;
//        Cache = new GameObject[Preguntas_.Length + 1];
//        var NewValidador = Instantiate(moodle.Validar) as GameObject;//crear la pregunta
//        NewValidador.transform.SetParent(Pabre_pregunta, false);
//        //NewValidador.SetActive(true);
//        for (int i = 0; i < Cache.Length; i++)
//        {
//            Cache[i] = null;
//        }
//        PlayerPrefs.SetString("CodeTemp", ID);
//        Debug.Log("creando preguntas de " + PlayerPrefs.GetString("CodeTemp"));//creando la pregunta con sus respuestas
//        for (int i = 0;i < Preguntas_.Length;i++)
//        {
//            var NewPregunta = Instantiate(Hijo_pregunta) as GameObject;//crear la pregunta
//            NewPregunta.transform.SetParent(Pabre_pregunta, false);
//            NewPregunta.GetComponent<PREGUNTA>().Pregunta_texto = Preguntas_[i].Pregunta_texto;
//            NewPregunta.GetComponent<PREGUNTA>().ID = Preguntas_[i].Pregunta_id;
//            NewPregunta.GetComponent<PREGUNTA>().Cuestionario_nombre = cuestionario_s;
//            NewPregunta.GetComponent<PREGUNTA>().Tipo = Preguntas_[i].Tipo;
//            NewPregunta.GetComponent<PREGUNTA>().Respuestas = new string[int.Parse(Preguntas_[i].Cantidad)];//numero de respuestas
//            for (int a = 0; a <int.Parse(Preguntas_[i].Cantidad); a++)
//            {
//                NewPregunta.GetComponent<PREGUNTA>().Respuestas[a] = ",,,,,";//clear para poder utilizar
//            }
//            int cont = 0;//contador
//            int cont2 = 0;
//            int[] tem = new int[Respuestas_.Length];//temporal para saber las respuestas correctas
//            for (int e = 0; e < Respuestas_.Length; e++)//asignar respuestas
//            {
//                if (NewPregunta.GetComponent<PREGUNTA>().ID == Respuestas_[e].ID)//comparar pregunta que pertenesca a la respuesta
//                {
//                    if (int.Parse(Respuestas_[e].Valor) >= 1)//saber si es una pregunta correcta
//                    {
//                            if(Preguntas_[i].Tipo == "multiple"){
//                                    tem[cont2] = cont;//cantidad de respuestas buenas y pocision
//                                    cont2++;
//                            }else{
//                                    NewPregunta.GetComponent<PREGUNTA>().Respuesta = Respuestas_[e].Respuesta_Texto;
//                            } 
//                    }
//                    NewPregunta.GetComponent<PREGUNTA>().Respuestas[cont] = Respuestas_[e].Respuesta_Texto;
//                    cont++;      
//                }
//            }
//            NewPregunta.GetComponent<PREGUNTA>().Respuestas_multiple = new string[tem.Length];//tamaño de los texto respuesta
//            for (int e = 0; e < NewPregunta.GetComponent<PREGUNTA>().Respuestas_multiple.Length; e++)//asignar respuestas
//            {
//                if(tem[e]>=1){
//                    NewPregunta.GetComponent<PREGUNTA>().Respuestas_multiple[e] = NewPregunta.GetComponent<PREGUNTA>().Respuestas[tem[e]];
//                }
//            }
//
//            NewPregunta.GetComponent<PREGUNTA>().CrearPreguntas();
//            Cache[i] = NewPregunta;
//            Controlador_preguntas.Preguntas[i] = NewPregunta;
//            //Controlador_preguntas.Size_preguntas = Preguntas_.Length;
//        }
//        Controlador_preguntas.Size_preguntas = Preguntas_.Length + 1;
//        Cache[Preguntas_.Length] = NewValidador;
//        Controlador_preguntas.Preguntas[Preguntas_.Length] = NewValidador;
//        NewValidador.transform.SetSiblingIndex(Preguntas_.Length+2);
//    }
//}
