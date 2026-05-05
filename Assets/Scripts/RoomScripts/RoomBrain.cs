using UnityEngine;
using UnityEngine.EventSystems;

public class RoomBrain : MonoBehaviour
{
    private int curTime;
    private int curDay;

    [SerializeField] GameObject[] day;

    [Header("Assign major room components.")] 
    public EventSystem eventSystem;
    public TextBox textBox;
    public Transform ui;
    public InteractionPointBrain interactPoints;
    public DialogueBrancher brancher;

    [Header("Refer to cheat sheet")]
    public int roomID;

    [Header("Assign where quest items will spawn")]
    public Transform[] questPoints;
    
    



    void Start()
    {
        curTime = TimeManagerScript.Instance.currentHour;
        curDay = TimeManagerScript.Instance.currentDay;

        LoadEvents();
    
    }

    void LoadEvents()
    {
        int i = 0;
        foreach(GameObject g in day)
        {
            if(i != curDay)
            {
                day[i].SetActive(false);
            }
            else if (i == curDay)
            {
                day[i].SetActive(true);
            }
            i++;
        }
        
    }
}
