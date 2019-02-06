using Recursos.MELI.TORRE_DE_PALABRAS.scripts;
using UnityEngine;
using UnityEngine.EventSystems;


public class boton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool op = false;
    public float axis;
    [SerializeField] private Tower _tower;
    private Rigidbody[] _rigidbody;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (op) _tower.RotationPiece(axis);
    }


    //detecta el clic del mouse (Press)
    public void OnPointerDown(PointerEventData eventData)
    {
        op = true;
        isKinematic(op);
    }

    //detecta el release del mouse
    public void OnPointerUp(PointerEventData eventData)
    {
        op = false;
        isKinematic(op);
    }

    public void isKinematic(bool op)
    {
        _rigidbody = _tower.gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (var elem in _rigidbody)
        {
            elem.isKinematic = op;
        }
    }
}