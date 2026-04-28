using UnityEngine;

public class RoomBrain : MonoBehaviour
{
    private int curTime;
    private int curDay;

    [SerializeField] GameObject[] day;

    public int roomID;
    public TextBox textBox;
    public Transform ui;
    public InteractionPointBrain interactPoints;
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
