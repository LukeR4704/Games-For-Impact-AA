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

    private EventSystem eventSystem;
    private GraphicRaycaster raycaster;
    
    void Start()
    {
        raycaster = GameObject.FindWithTag("MainCanvas").GetComponent<GraphicRaycaster>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        posBeforeDrag = transform.position;
        parentBeforeDrag = transform.parent;
        Inventory_Brain.instance.grabbedItem = item;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Pointer.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        CheckForNPC(eventData);
        Inventory_Brain.instance.grabbedItem = null;
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
                raycastResult.gameObject.GetComponent<DialogueBrancher>().itemID = item.itemID;
                raycastResult.gameObject.GetComponent<DialogueBrancher>().TriggerDialogueItem();
                return true;
            }
        }
        Debug.Log("No NPC found");
        return false;
            
    }
}
