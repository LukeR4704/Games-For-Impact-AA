using UnityEngine;
using UnityEngine.SceneManagement;

public class TestQuestScript : MonoBehaviour
{
    public int questStep = 0;
    private RoomBrain curRoom;
    [SerializeField] GameObject[] questInteraction;
    [SerializeField] GameObject[] questNPC;
    public QuestData data;
    [SerializeField] private Item questItem;
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


    //run this whenever the quest status is updated
    public void QuestUpdate()
    {


        switch (data.questStep)
        {
            case 0:

                if (!data.isOptional)
                {
                    QuestBrain.instance.mainQuestState = 1;
                }

                if (curRoom.roomID == 9)
                {
                    Debug.Log("Quest step 0 active");
                    Inventory_Brain.instance.AddItem(questItem);
                    CreateInteractPoint(0, 0);
                }
                ;

                break;

            case 1:
                if(curRoom.roomID == 9)
                {
                    Inventory_Brain.instance.AddItem(questItem);
                    Debug.Log("Quest step 1 active");
                    CreateInteractPoint(1, 1);
                };
                break;

            case 2:

                if(curRoom.roomID == 9)
                {
                    Inventory_Brain.instance.RemoveItem(questItem);
                    Debug.Log("Quest step 2 active");
                    CloseQuest();
                };

                break;

            case 3:


                break;


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

    public void CreateInteractPoint(int i, int p)
    {
        Debug.Log(i + " and " + p);
        GameObject obj = Instantiate(questInteraction[i], curRoom.questPoints[p]);
        obj.GetComponent<QuestInteraction>().questObj = gameObject;
    }

}
