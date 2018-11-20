//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System;
//using System.Net;
//using System.IO;
//
//public class MOODLE : MonoBehaviour
//{
//    public CONTROLADOR_PREGUNTAS Controlador_preguntas; 
//    public CURSOS_MOODLE Curso;
//    public string[] cuestionario_array;
//    public string[] principales;
//    public string[] cuestionario_datos;
//    public string[] preguntas_datos;
//    public string[] respuestas_datos;
//    public GameObject Objetos_cuestionario_hijo;
//    public Transform Objetos_cuestionario_padre;
//    public GameObject Objetos_cursos_hijo;
//    public Transform Objetos_cursos_padre;
//    public GameObject[] cache;
//    public GameObject MensajeError,Validar;
//    public GameObject MensajeCargando;
//    public GameObject Verificacion;
//    public GameObject Login;
//    public GameObject Registro;
//    public Text MensageError;
//    public InputField Codigo;
//    public InputField Nombre;
//    public InputField Contraseña;
//    public InputField Nombre_r;
//    public InputField User_r;
//    public InputField Contraseña_r;
//    public string BBDD;
//    public string[] cuestionarios_prefaps;
//    public string Datos;
//    public Sprite[] Caras;
//    public Image Alert;
//    public Image Conex;
//    public WWW www;
//    [Header("Pagina")]
//    public Animator Menu;
//    public bool MenuBool;
//
//
//    // Use this for initialization
//    void Start() {
//        //PlayerPrefs.DeleteKey("Datos");
//        //PlayerPrefs.DeleteKey("NombreUsuario");
//        if (PlayerPrefs.HasKey("NombreUsuario"))
//        {
//            Login.SetActive(false);
//            Logueo();
//        }
//        else
//        {
//            Login.SetActive(true);
//        }
//    }
//
//	void Update () {
//        /*if(CheckInternetAcces()){
//        }else{
//        }*/
//	}
//
//    public void Menu_Desplege(){
//        if(MenuBool){
//           MenuBool = false;
//           Menu.Play("menu_vectorz_cerrar");
//        }else{
//           MenuBool = true;
//           Menu.Play("menu_vectorz_abrir");
//        }
//    }
//
//    public void VerContraseña(InputField input){
//        if(input.contentType == InputField.ContentType.Standard){
//            input.contentType = InputField.ContentType.Password;
//            input.ForceLabelUpdate();
//        }else{
//            input.contentType = InputField.ContentType.Standard;
//            input.ForceLabelUpdate();
//        }
//    }
//
//    public bool CheckInternetAcces(){
//        try{
//           WebClient client = new WebClient();
//           Stream stream = client.OpenRead("" + BBDD);
//           return true;
//        }
//        catch{
//            return false;
//        }
//    }
//
//    public void LoginUsuario()
//    {
//        StartCoroutine("Iniciar_logeo");
//    }
//
//    public void Logueo()
//    {
//        StartCoroutine("CrearEstructura");
//    }
//
//    public void TraerCurso(){
//        StartCoroutine("Iniciar_Preguntas");
//    }
//
//    public void Registrar(){
//        StartCoroutine("EnviarRegistro");
//    }
//
//    public void Actualizar(){
//        Desactivar();
//        QuitarCuestionarios();
//        StartCoroutine("Recargar");
//    }
//
//
//
//     public IEnumerator EnviarRegistro(){
//            www = new WWW(BBDD + "2&nombre=" + Nombre_r.text + "&usuario_nombre=" + User_r.text + "&contra=" + Contraseña_r.text);//ahora traigo los datos del cuestionario y cursos
//            yield return www;
//            Debug.Log("Datos de registro " + www.text);
//            cuestionarios_prefaps = www.text.Split(new string[] { "+" }, StringSplitOptions.None);//quito los datos inecesarios
//            if(cuestionarios_prefaps[0] == "correcto"){
//                Registro.SetActive(false);
//                Login.SetActive(true);
//                Mensaje("Registro Correcto",0);
//                Nombre_r.text = "";
//                User_r.text = "";
//                Contraseña_r.text = "";
//            }else{
//                Mensaje("Error al registrar",2);
//            } 
//    }
//
//    public IEnumerator Recargar(){
//            Desactivar();
//            QuitarCuestionarios();
//            www = new WWW(BBDD + "1&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&contra=" + PlayerPrefs.GetString("password") + "");//ahora traigo los datos del cuestionario y cursos
//            yield return www;
//            Debug.Log("Datos de recarga " + www.text);
//            cuestionarios_prefaps = new string[0];//formateo la cadena
//            cuestionarios_prefaps = www.text.Split(new string[] { "+" }, StringSplitOptions.None);//quito los datos inecesarios
//            PlayerPrefs.SetString("Datos", cuestionarios_prefaps[0]);//actualizar los datos de id del curso y del los cuestionarios correspondientes y los guardo
//            StartCoroutine("CrearEstructura");
//    }
//
//    //traer cursos
//    public IEnumerator Iniciar_Preguntas()
//    {
//        www = new WWW(BBDD + "4&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&curso=" + Codigo.text);
//        yield return www;
//        Debug.Log("" + www.text);
//        string[] respuesta = www.text.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);//quitar elementos inecesarios
//        if (respuesta[0] == "correcto")
//        {
//            Desactivar();
//            QuitarCuestionarios();
//            www = new WWW(BBDD + "1&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&contra=" + PlayerPrefs.GetString("password") + "");//ahora traigo los datos del cuestionario y cursos
//            yield return www;
//            Debug.Log("Datos de curso " + www.text);
//            cuestionarios_prefaps = new string[0];//formateo la cadena
//            cuestionarios_prefaps = www.text.Split(new string[] { "+" }, StringSplitOptions.None);//quito los datos inecesarios
//            PlayerPrefs.SetString("Datos", cuestionarios_prefaps[0]);//actualizar los datos de id del curso y del los cuestionarios correspondientes y los guardo
//            StartCoroutine("CrearEstructura");
//            Verificacion.SetActive(false);
//            Mensaje("Correctamente Agregado",0);
//            Codigo.text = "";
//        }
//        else
//        {
//            Mensaje("No se pudo anclar curso",2);
//        }
//    }
//
//    public IEnumerator Iniciar_logeo()
//    {
//        www = new WWW(BBDD + "0&nombre=" + Nombre.text + "&contra=" + Contraseña.text + "");
//        yield return www;
//        Debug.Log("" + www.text);
//        string[] Elementos = www.text.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);//quitar elementos inecesarios
//        if (Elementos[0] == "correcto")//si inicio sesion correctamente
//        {
//            PlayerPrefs.SetString("NombreUsuario", Nombre.text);//guardo los datos del usuario
//            PlayerPrefs.SetString("password", Contraseña.text);
//            Login.SetActive(false);//desactivo el modulo de logeo
//            www = new WWW(BBDD + "1&nombre=" + Nombre.text + "&contra=" + Contraseña.text + "");//ahora traigo los datos del cuestionario y cursos
//            yield return www;
//            Debug.Log("Datos de logeo " + www.text);
//            cuestionarios_prefaps = new string[0];//formateo la cadena
//            cuestionarios_prefaps = www.text.Split(new string[] { "+" }, StringSplitOptions.None);//quito los datos inecesarios
//            PlayerPrefs.SetString("Datos", cuestionarios_prefaps[0]);//actualizar los datos de id del curso y del los cuestionarios correspondientes y los guardo
//            StartCoroutine("CrearEstructura");
//            Login.SetActive(false);
//            Mensaje("Logeado correctamente",0);
//            Nombre.text = "";
//            Contraseña.text = "";
//        }
//        else
//        {
//           Mensaje("No se pudo Iniciar Login",2);
//        }
//    }
//
//    public IEnumerator CrearEstructura(){
//            Datos = PlayerPrefs.GetString("Datos");//asignar variable temporar con los datos
//            cuestionarios_prefaps = Datos.Split(new string[] { "§" }, StringSplitOptions.None);//dividimos los datos de cada curso
//            for (int i = 0; i < cuestionarios_prefaps.Length - 1; i++)
//            {
//                string[] datosCurso = cuestionarios_prefaps[i].Split(new string[] { "|datos_cursos_cuestionarios|" }, StringSplitOptions.None);//dividimos los datos entre curso y cuestionarios
//                string curso = datosCurso[0];//datos curso
//                string cuestionarios = datosCurso[1];//datos cuestionario
//                Debug.Log("" + cuestionarios);
//                string[] DatosCuestionarios = cuestionarios.Split(new string[] { "£" }, StringSplitOptions.None);//dividimos los datos de los cuestionarios
//                string NuevaCadena = "";
//                for(int e = 0; e < DatosCuestionarios.Length - 1;e++){//creamos un array para guardar cada cuestionario 
//                    Debug.Log("CUESTIONARIO " + DatosCuestionarios[e]);
//                    www = new WWW(BBDD + "7&code=" + DatosCuestionarios[e] + "&usuario=" + PlayerPrefs.GetString("NombreUsuario"));
//                    Debug.Log(BBDD + "7&code=" + DatosCuestionarios[e] + "&usuario=" + PlayerPrefs.GetString("NombreUsuario"));
//                    yield return www;
//                    Debug.Log("Datos de cuestionarios " + www.text);
//                    PlayerPrefs.SetString(DatosCuestionarios[e], www.text);//creamos los datos por cada cuestionario
//                    NuevaCadena = NuevaCadena + PlayerPrefs.GetString(DatosCuestionarios[e]) + "Æ" ;//creamos una cadema para tener los cuestionarios temporalmente en los cursos
//                }
//                CrearCursos(curso,NuevaCadena);
//            Debug.Log("" + curso + "  PARTIR " + NuevaCadena);
//        }
//    }
//
//    public void CrearCursos(string datosCurso,string datosCuestionarios){
//        string[] DatosCurso = datosCurso.Split(new string[] { "£" }, StringSplitOptions.None);//dividimos los datos
//        string[] DatosCuestionarios = datosCuestionarios.Split(new string[] { "Æ" }, StringSplitOptions.None);//dividimos los datos*/
//        var NewCurso = Instantiate(Objetos_cursos_hijo) as GameObject;
//        NewCurso.transform.SetParent(Objetos_cursos_padre);
//        NewCurso.transform.localScale = new Vector3(1,1,1);
//        NewCurso.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
//        NewCurso.SetActive(true);
//        NewCurso.GetComponent<CURSOS_MOODLE>().Cuestionarios = new string[DatosCuestionarios.Length - 1];
//        NewCurso.GetComponent<CURSOS_MOODLE>().CursoNombre = DatosCurso[1];
//        NewCurso.GetComponent<CURSOS_MOODLE>().CursoCode = DatosCurso[0];
//        for(int i = 0 ; i < cache.Length;i++){
//                if(cache[i] == null){
//                   cache[i] = NewCurso;
//                   break;
//                }
//        }
//        for(int i = 0;i<DatosCuestionarios.Length - 1;i++){
//            NewCurso.GetComponent<CURSOS_MOODLE>().Cuestionarios[i] = DatosCuestionarios[i];
//        }
//    }
//
//    public void CrearCuestionarios(string s)
//    {
//        Verificacion.SetActive(false);
//        MensajeCargando.SetActive(true);
//        cuestionario_array = s.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);
//        Debug.Log("cuestionario_array " + s);
//        principales = cuestionario_array[0].Split(new string[] { "§" }, StringSplitOptions.None);
//        Debug.Log("datos "+ cuestionario_array[0]);
//        cuestionario_datos = principales[0].Split(new string[] { "¥" }, StringSplitOptions.None);
//        Debug.Log("cuestioario " + principales[0]);
//        preguntas_datos = principales[1].Split(new string[] { "¥" }, StringSplitOptions.None);
//        Debug.Log("preguntas " + principales[1]);
//        respuestas_datos = principales[2].Split(new string[] { "¥" }, StringSplitOptions.None);
//        Debug.Log("respuestas  " + principales[2]);
//        var NewCuestionario = Instantiate(Objetos_cuestionario_hijo) as GameObject;
//            NewCuestionario.transform.SetParent(Objetos_cuestionario_padre, false);
//            NewCuestionario.GetComponent<CUESTIONARIO>().ID = cuestionario_datos[0];
//            NewCuestionario.GetComponent<CUESTIONARIO>().cuestionario_s = cuestionario_datos[1];
//            NewCuestionario.GetComponent<CUESTIONARIO>().intentos = int.Parse(cuestionario_datos[2]);
//            NewCuestionario.GetComponent<CUESTIONARIO>().Bienvenida_s = cuestionario_datos[3];
//            NewCuestionario.GetComponent<CUESTIONARIO>().Fecha_s = cuestionario_datos[4];
//            NewCuestionario.GetComponent<CUESTIONARIO>().limite_s = cuestionario_datos[5];
//            NewCuestionario.GetComponent<CUESTIONARIO>().Nota_s = cuestionario_datos[6];
//            NewCuestionario.GetComponent<CUESTIONARIO>().moodle = this;
//            NewCuestionario.SetActive(true);
//            NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_ = new Preguntas[preguntas_datos.Length - 1];
//            NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_ = new Respuestas[respuestas_datos.Length - 1];
//            for (int i = 0; i < preguntas_datos.Length - 1; i++)
//            {
//                NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i] = new Preguntas();
//            }
//            for (int i = 0; i < respuestas_datos.Length - 1; i++)
//            {
//                NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_[i] = new Respuestas();
//            }
//            Controlador_preguntas.Preguntas = new GameObject[NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_.Length + 1];
//            for (int a = 0; a < NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_.Length - 1; a++)
//            {
//                Controlador_preguntas.Preguntas[a] = null;
//            }
//            Controlador_preguntas.Preguntas[NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_.Length] = Validar;
//            for (int i = 0; i < preguntas_datos.Length - 1; i++)
//            {
//                // crear preguntas y respuestas en una base de datos local
//                string[] Datos_Pregunta = preguntas_datos[i].Split(new string[] { "£" }, StringSplitOptions.None);
//                string id_pregunta = Datos_Pregunta[0];
//                string titulo_pregunta = Datos_Pregunta[1];
//                string cantidad_pregunta = Datos_Pregunta[2];
//                string tipo = Datos_Pregunta[3];
//                for (int e = 0; e < respuestas_datos.Length - 1; e++)
//                {
//                    string[] Datos_Respuestas = respuestas_datos[e].Split(new string[] { "£" }, StringSplitOptions.None);//separar las respuestas
//                    if (Datos_Respuestas[2] == id_pregunta)
//                    {
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_[e].Respuesta_Texto = Datos_Respuestas[0];
//                        if (int.Parse(Datos_Respuestas[1]) > 1)
//                        {
//                            NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_[e].Valor = "100";
//                        }else{
//                            NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_[e].Valor = "0";
//                        }
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Respuestas_[e].ID = Datos_Respuestas[2];
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].ID = cuestionario_datos[0];
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].Pregunta_id = id_pregunta;
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].Pregunta_texto = titulo_pregunta;
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].Cuestionario_nombre = cuestionario_datos[0];
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].Cantidad = cantidad_pregunta;
//                        NewCuestionario.GetComponent<CUESTIONARIO>().Preguntas_[i].Tipo = tipo;
//                    }
//                }
//            }
//            MensajeCargando.SetActive(false);
//    }
//
//    public void CerrarSesion(){
//        PlayerPrefs.DeleteAll();
//        Desactivar();
//        QuitarCuestionarios();
//        Login.SetActive(true);
//        Mensaje("Sesion cerrada",1);
//    }
//
//    public void Desactivar()
//    {
//        for (int i = 0; i < cache.Length; i++)
//        {
//            if(cache[i] == null){
//
//            }else{
//                Destroy(cache[i]);
//            }
//        }
//    }
//
//    public void QuitarCuestionarios(){
//        for(int i = 1; i < Objetos_cuestionario_padre.childCount;i++){
//            Destroy(Objetos_cuestionario_padre.GetChild(i).gameObject);
//        }
//    }
//
//    public void Mensaje(string m, int c){
//            MensageError.text = m;
//            MensajeError.SetActive(true);
//            if(c == 0){
//              Alert.sprite = Caras[5];
//            }
//            if(c == 1){
//              Alert.sprite = Caras[6];
//            }
//            if(c == 2){
//              Alert.sprite = Caras[7];
//            }
//    }
//
//    public void filtro_nuevos(){
//        Curso.MostrarNuevos();
//    }
//
//    public void filtro_viejos(){
//        Curso.MostarRealizados();
//    }
//
//}
