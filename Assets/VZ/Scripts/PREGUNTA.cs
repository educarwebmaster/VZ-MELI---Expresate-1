//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System;
//
//public class PREGUNTA : MonoBehaviour {
//
//    public MOODLE moodle;
//    public CONTROLADOR_PREGUNTAS controlador;
//    public string ID;
//    public string Pregunta_texto;
//    public string[] Respuestas;
//    public string Cuestionario_nombre;
//    public string Respuesta;
//    public int Respuesta_entero;
//    public int[] Respuesta_entero_multiple;
//    public float suma,Puntos;
//    public string[] Respuestas_multiple;
//    public Text Pregunta_text;
//    public Text[] Respuesta_text;
//    public GameObject Cortinilla;
//    public Transform Padre;
//    public GameObject Hijo;
//    public Toggle[] checks;
//    public string Tipo;
//
//    // Use this for initialization
//    void Start () {
//        
//    }
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//    public void CrearPreguntas()
//    {
//        if(Tipo == "multiple"){//si es multiple respuesta
//            suma = 1/Respuestas_multiple.Length;
//            int tem =0;
//            for (int i = 0; i < Respuestas.Length; i++)
//            {
//                if(Respuestas_multiple[i] == Respuestas[i]){//cantidad de respuestas
//                    tem++;  
//                }
//                Respuesta_entero_multiple = new int[tem];
//                if(Respuestas_multiple[i] == Respuestas[i]){//asignar las respuestas correctas
//                    Respuesta_entero_multiple[i] = i;  
//                }
//            }
//        }else{//si es unica respuesta solo busca el correcto
//            suma = 1;
//            for (int i = 0; i < Respuestas.Length; i++)
//            {
//                if(Respuesta == Respuestas[i]){
//                    Respuesta_entero = i;
//                }
//            }
//        }
//        
//        Pregunta_text.text = Pregunta_texto;
//        Respuesta_text = new Text[Respuestas.Length];
//        checks = new Toggle[Respuestas.Length];
//        for (int i = 0; i < Respuestas.Length; i++)
//        {
//             checks[i] = null;
//             //Respuesta_text[i] = null;
//        }
//        for (int i = 0; i < Respuestas.Length; i++)
//        {
//            GameObject Pregun = Instantiate(Hijo) as GameObject;
//            Pregun.transform.SetParent(Padre, false);
//            Pregun.SetActive(true);
//            Respuesta_text[i] = Pregun.transform.GetChild(0).GetComponent<Text>();
//            Respuesta_text[i].text = Respuestas[i];
//            checks[i]= Pregun.transform.GetChild(2).GetComponent<Toggle>();
//        }
//    }
//
//    public void Verificar(Toggle Respuesta_p)
//    {
//        if(Tipo == "multiple"){
//            
//        }else{
//            for (int i = 0; i < checks.Length; i++)
//            {
//                if(checks[i] != Respuesta_p){
//                    checks[i].isOn = false;
//                    checks[i].gameObject.GetComponent<Animator>().Play("check_normal");
//                }
//            }
//        }
//    }
//
//    public void Terminar(){
//        for (int i = 0; i < checks.Length; i++)
//        {
//            if(Tipo == "multiple"){
//                if(checks[i].isOn == true){
//                    for (int e = 0; e < Respuesta_entero_multiple.Length; e++)
//                    {
//                        if(i == Respuesta_entero_multiple[e]){
//                            Puntos+=suma; 
//                            break;
//                        }
//                    }
//                }
//            }else{
//                if(checks[i].isOn == true){
//                    if(i == Respuesta_entero){
//                        Puntos+=suma; 
//                        break;
//                    }
//                }
//            }
//        }
//        if(Puntos == 1){
//            controlador.Puntos++; 
//        }
//        controlador.Calificados++;
//    }
//}
