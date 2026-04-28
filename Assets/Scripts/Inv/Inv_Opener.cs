using UnityEngine;
using UnityEngine.Rendering;

public class Inv_Opener : MonoBehaviour
{
    private Transform ui;
    [SerializeField] private Transform[] ItemSlot;

    private void OnEnable()
    {
        ui = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().ui;
        foreach (Transform child in ui)
        {
            child.gameObject.SetActive(false);
        }

        InvUpdate();
    }

    // Update is called once per frame
    
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
            child.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);

    }
}
