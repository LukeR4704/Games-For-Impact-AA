using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform parentBeforeDrag;
    Vector2 posBeforeDrag;
    public Item item;

    private bool dragging = false;

    private EventSystem eventSystem;
    private GraphicRaycaster raycaster;
    
    void Start()
    {
        raycaster = GameObject.FindWithTag("MainCanvas").GetComponent<GraphicRaycaster>();

    }

    void Update()
    {
        if (dragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, Pointer.current.position.ReadValue(), DragSpeed() * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        posBeforeDrag = transform.position;
        parentBeforeDrag = transform.parent;
        Inventory_Brain.instance.grabbedItem = item;

        dragging = true;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Vector3.MoveTowards(transform.position, Pointer.current.position.ReadValue(), 2 * Time.deltaTime);
//transform.position = Pointer.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        CheckForNPC(eventData);
        dragging = false;
        //Inventory_Brain.instance.grabbedItem = null;
        transform.SetParent(parentBeforeDrag);
        transform.position = posBeforeDrag;
    }


    //check if theres an NPC under the object being dragged when releasing

    public bool CheckForNPC(PointerEventData pointerData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);
        foreach (RaycastResult raycastResult in results)
        {
            if (raycastResult.gameObject.CompareTag("NPC"))
            {
                Debug.Log("Npc given item!");
                DialogueBrancher branch = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().brancher;
                branch.itemID = item.itemID;
                branch.TriggerDialogueItem();
                return true;
            }
        }
        Debug.Log("No NPC found");
        return false;
            
    }

    private float DragSpeed()
    {
        float distance = Vector2.Distance(transform.position, Pointer.current.position.ReadValue());

        float speed = 1000 + (distance * 8);
        speed = Mathf.Clamp(speed, 1000, 5000);
        return speed;
    }

}
