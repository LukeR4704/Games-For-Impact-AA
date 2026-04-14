using UnityEngine;

public class RoomBrain : MonoBehaviour
{
    private int curTime;
    private int curDay;

    [SerializeField] GameObject[] day;

    public int roomID;
    public TextBox textBox;
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
        day[curDay].SetActive(true);
    }
}
