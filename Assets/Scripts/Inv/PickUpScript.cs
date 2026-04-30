using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PickUpScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform parentBeforeDrag;
    Vector2 posBeforeDrag;
    public Item item;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("Begin drag");
        posBeforeDrag = transform.position;
        parentBeforeDrag = transform.parent;
        Inventory_Brain.instance.grabbedItem = item;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        
        transform.position = Pointer.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        Inventory_Brain.instance.grabbedItem = null;
        transform.SetParent(parentBeforeDrag);
        transform.position = posBeforeDrag;
    }
}
