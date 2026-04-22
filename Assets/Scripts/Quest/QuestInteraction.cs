using UnityEngine;

public class QuestInteraction : MonoBehaviour
{
    [HideInInspector] public GameObject questObj;
    private TextBox textBox;
    private QuestEventBrain eventObj;

    [SerializeField] private bool addItem;


    void Start()
    {
        if(questObj == null)
        {
            Destroy(gameObject);
        }
        textBox = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>().textBox;
        eventObj = questObj.GetComponent<QuestEventBrain>();
    }

    public void QuestDialogueActive()
    {
        textBox.onDialogueComplete.AddListener(ProgEvent);
        textBox.onDialogueComplete.AddListener(RemoveObj);
    }

    void ProgEvent()
    {
        eventObj.questProg.Invoke();
    }

    void RemoveObj()
    {
        Destroy(gameObject);
    }


}
