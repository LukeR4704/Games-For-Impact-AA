using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main5_FirstAid : MonoBehaviour
{
    public int questStep = 0;
    private RoomBrain curRoom;
    [SerializeField] GameObject[] questInteraction;
    public Item[] questItem;
    public QuestData data;
    private QuestEventBrain brain;


    private int qi;
    private int iVal = 0;
    private int qVal = 0;

    private bool item1 = false;
    private bool item2 = false;

    private void Update()
    {
        Debug.Log(data.questStep);
    }

    private void Start()
    {

        curRoom = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        data = QuestBrain.instance.activeQuests[^1];

        brain = gameObject.GetComponent<QuestEventBrain>();
        brain.questProg.AddListener(ProgQuest);
        brain.questClose.AddListener(CloseQuest);

        QuestUpdate();

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)

    {
        if (Inventory_Brain.instance.inventory.Contains(questItem[0]))
        {
            item1 = true;
        }

        curRoom = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>();
        QuestUpdate();


    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    //run this whenever the quest status is updated
    public void QuestUpdate()
    {
        Debug.Log(data.questStep);
        try
        {
            switch (data.questStep)
            {
                case 0:

                    if (!data.isOptional)
                    {
                        QuestBrain.instance.mainQuestState = 1;
                    }

                    //first quest step; this is the default when the quest is first started. go find the next step (usually an item)
                    if (curRoom.roomID == 6 && !item1)
                    {
                        CreateInteractPoint(0, 1);

                    }

                    ;

                    break;

                //this is when you find the item and must now bring it back to the required npc
                case 1:
                    if (curRoom.roomID == 1)
                    {
                        Inventory_Brain.instance.giveItem.AddListener(CheckIfCorrectItem);
                    }
                    else
                    {
                        Inventory_Brain.instance.giveItem.RemoveListener(CheckIfCorrectItem);
                    }

                        ;
                    break;
                //for when youve given the NPC the required item; quest is now clear
                case 2:

                    CloseQuest();
                    ;

                    break;

                    //if necessary, add more steps here
            }


        }
        catch
        {
            Debug.Log("Quest out of step bounds!");
            CloseQuest();
        }
    }

    //this is called when the player hands over an item while in the correct room for the quest. it will check if the item is correct, then incremement the quest while removing the player's item.
    void CheckIfCorrectItem()
    {
        if (Inventory_Brain.instance.grabbedItem.itemID == questItem[0].itemID)
        {

            Inventory_Brain.instance.inventory.Remove(questItem[0]);
            curRoom.textBox.onDialogueComplete.AddListener(CorrectItem);
            return;
        }
        else
        {
            return;
        }
    }

    void CorrectItem()
    {
        qVal++;
        if (qVal >= 1)
        {
            ProgQuest();
        }
        curRoom.textBox.onDialogueComplete.RemoveListener(CorrectItem);
    }


    //standard increase quest by 1 script
    public void ProgQuest()
    {

        Debug.Log("Progging quest");
        data.questStep++;

        QuestUpdate();
    }



    //method that erases the quest object and removes it from the active quest list
    public void CloseQuest()
    {
        if (!data.isOptional)
        {
            QuestBrain.instance.mainQuestState = 2;
        }

        QuestBrain.instance.activeQuests.Remove(data);
        Destroy(gameObject);

    }

    //method that creates item interaction points when the quest needs them. i = the item, p = the transform of the interact point
    public void CreateInteractPoint(int i, int p)
    {
        Debug.Log(i + " and " + p);
        GameObject obj = Instantiate(questInteraction[i], curRoom.questPoints[p]);

        obj.GetComponent<QuestInteraction>().questObj = gameObject;
        obj.GetComponent<Button>().interactable = false;
    }

}
