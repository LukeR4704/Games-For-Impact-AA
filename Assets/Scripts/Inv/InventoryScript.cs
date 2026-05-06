using UnityEngine;
using UnityEngine.Rendering;

public class InventoryScript : MonoBehaviour
{

    //This script instantiates the inventory ui elements and nothing else. It does not need to be referred to ever.

    private Transform ui;
    [SerializeField] private Transform[] ItemSlot;
    [SerializeField] private Transform parentObj;

    private void Start()
    {
        Inventory_Brain.instance.giveItem.AddListener(InvUpdate);
    }

    private void OnEnable()
    {

        ui = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().ui;
        foreach (Transform child in ui)
        {
            if (child != parentObj.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        InvUpdate();
    }

    
    public void LoadInv()
    {
        
        gameObject.SetActive(true);


    }

    public void InvUpdate()
    {
        //clear items
        int c = 0;
        while (c <= ItemSlot.Length) 
        {
            
            try
            {
                Destroy(ItemSlot[c].GetChild(0).gameObject);
            }
            catch
            {
                Debug.Log("No child found to destroy");
            }
            c++;
        }

        //inst items
        int i = 0;
        foreach (Item item in Inventory_Brain.instance.inventory)
        {
            Debug.Log("Inst. child under: " + ItemSlot[i]);

            Instantiate(Inventory_Brain.instance.itemCatalogue[item.itemID], ItemSlot[i]);
            i++;
        }
    }

    public void CloseInv()
    { 

        foreach (Transform child in ui)
        {
            if (child != parentObj.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        gameObject.SetActive(false);

    }

}
