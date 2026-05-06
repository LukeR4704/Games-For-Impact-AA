using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory_Brain : MonoBehaviour
{

    public static Inventory_Brain instance;
    public GameObject[] itemCatalogue;
    //public Item[] itemData;
    public List<Item> inventory = new List<Item>();

    [HideInInspector]public Item grabbedItem;

    [HideInInspector]public UnityEvent giveItem;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    /*
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        invUI = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().invUI;
    }
    */
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }





    
}
