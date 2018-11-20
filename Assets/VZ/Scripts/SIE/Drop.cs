///***********************************************
//
//Sistema Drag And Drop 
//Creado Originalmente por : Hector Stiven Gomez Ramirez
//Modificado por :
//
//Esta script esta creada para tener los componentes logicos 
//del elemento Drop o receptor
//*********************************************/
//
//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.EventSystems;
//
//public class Drop : MonoBehaviour, IDropHandler
//{
//    public enum TipeDrop
//    {//lista para saber que tipo de receptor es
//        Objetivo,
//        Inicial
//    }
//
//    public int ID;
//    public TipeDrop DropTipe = TipeDrop.Inicial;
//    public bool Check;
//    public SELECCION_SALUD Controlador;
//
//    public GameObject item//variable autoasignable a los elementos hijos
//    {
//        get
//        {
//            if (transform.childCount > 0)
//            {
//                //Debug.LogError("" + transform.GetChild(transform.childCount-1).gameObject);
//                return transform.GetChild(transform.childCount-1).gameObject;// mirar el ultimo hijo
//            }
//            return null;
//        }
//    }
//
//    #region IdropHandler implementation
//
//    public void OnDrop(PointerEventData eventData)//al colocar un objeto
//    {
//        if (!item)//verificar si no hay un objeto arrastrandose
//        {
//            InsertDrag();
//        }
//        else
//        {
//            if (DropTipe == TipeDrop.Objetivo)
//            {
//                InsertDrag();
//            }
//
//            if (DropTipe == TipeDrop.Inicial)
//            {
//                RestoreDrag();
//            }
//        }
//    }
//
//    #endregion
//
//    public void RestoreDrag()
//    {
//        Drag.item.GetComponent<Drag>().Restore();//reestaurar pocicion
//    }
//
//    public void InsertDrag()// incertar elemento como hijo
//    {
//        Drag.item.transform.SetParent(transform);
//        //Drag.item.GetComponent<LayoutElement>().ignoreLayout = false;
//        if (item.GetComponent<Drag>().ID == ID)//comparar id para saber si son correctos
//        {
//            Controlador.Verificar(true);
//            //array para desactivar
//            for (int i = 0; i < transform.childCount;i++)
//            {
//                transform.GetChild(i).gameObject.SetActive(false);
//            }
//            
//            //Destroy(transform.GetChild(0).gameObject);
//        }else
//        {
//            Controlador.Verificar(false);
//            for (int i = 0; i < transform.childCount; i++)
//            {
//                transform.GetChild(i).gameObject.SetActive(false);
//            }
//            //transform.GetChild(0).gameObject.SetActive(false);
//            //Destroy(transform.GetChild(0).gameObject);
//        }
//    }
//
//}
//
