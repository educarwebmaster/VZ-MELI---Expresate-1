using Recursos.MELI.AI_MELI_MOD1_ALIMENTAR_EL_OJO.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonMovimiento : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Use this for initialization
    private bool op;
    [SerializeField] private MoverPersonaje _moverPersonaje;
    public int axis;

    // Update is called once per frame
    void Update()
    {
        if (op) _moverPersonaje.Mover(axis);
    }

    //detecta el clic del mouse (Press)
    public void OnPointerDown(PointerEventData eventData)
    {
        op = true;
        Debug.Log(op);
    }

    //detecta el release del mouse
    public void OnPointerUp(PointerEventData eventData)
    {
        op = false;
        Debug.Log(op);
        _moverPersonaje.Stop();
    }
}