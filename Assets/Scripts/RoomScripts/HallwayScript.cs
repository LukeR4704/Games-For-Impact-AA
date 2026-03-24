using UnityEngine;

public class HallwayScript : MonoBehaviour
{
    private int curTime;
    private int curDay;

    [SerializeField] GameObject[] day;



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
