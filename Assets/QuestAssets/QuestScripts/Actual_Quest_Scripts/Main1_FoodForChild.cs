using UnityEngine;
using UnityEngine.SceneManagement;

public class Main1_FoodForChild : MonoBehaviour
{
    public int questStep = 0;
    private RoomBrain curRoom;
    [SerializeField] GameObject[] questInteraction;
    public Item questItem;
    public QuestData data;
    private QuestEventBrain brain;




    private void Start()
    {

        curRoom = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        data = QuestBrain.instance.activeQuests[^1];

        brain = gameObject.GetComponent<QuestEventBrain>();
        brain.questProg.AddListener(ProgQuest);
        brain.questClose.AddListener(CloseQuest);


        Debug.Log("Quest data file:" + data + " Child of: " + GetComponentInParent<Transform>());

        QuestUpdate();

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)

    {
        curRoom = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>();
        QuestUpdate();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    //run this whenever the quest status is updated
    public void QuestUpdate()
    {

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
                    if (curRoom.roomID == 2 && !Inventory_Brain.instance.inventory.Contains(questItem)) //kitchen, sandwich
                    {
                        CreateInteractPoint(0, 0);
                    }
                    ;

                    break;

                //this is when you find the item and must now bring it back to the required npc
                case 1:
                    if (curRoom.roomID == 1)
                    {
                        Debug.Log("Waiting for item");
                        Inventory_Brain.instance.giveItem.AddListener(CheckIfCorrectItem);
                    }
                    else
                    {
                        Debug.Log("No longer waiting for item");
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


    //standard increase quest by 1 script
    public void ProgQuest()
    {
        data.questStep++;
        QuestUpdate();
    }

    //set quest step to a specified value
    public void SetQuestStep(int step)
    {
        data.questStep = step;
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

    //this is called when the player hands over an item while in the correct room for the quest. it will check if the item is correct, then incremement the quest while removing the player's item.
    public void CheckIfCorrectItem()
    {
        if (Inventory_Brain.instance.grabbedItem.itemID == questItem.itemID)
        {   
            Debug.Log("Correct item given!");
            curRoom.textBox.onDialogueComplete.AddListener(CorrectItem);
            Inventory_Brain.instance.inventory.Remove(questItem);
            return;
            
        }
        else
        {
            Debug.Log("Wrong item given!");
            return;
        }
    }

    void CorrectItem()
    {
        Debug.Log("Correct item taken!");
        ProgQuest();
        curRoom.textBox.onDialogueComplete.RemoveListener(CorrectItem);
    }

    //method that creates item interaction points when the quest needs them. i = the item, p = the transform of the interact point
    public void CreateInteractPoint(int i, int p)
    {
        Debug.Log(i + " and " + p);
        GameObject obj = Instantiate(questInteraction[i], curRoom.questPoints[p]);
        obj.GetComponent<QuestInteraction>().questObj = gameObject;
    }

}
