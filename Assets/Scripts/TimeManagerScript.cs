using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    //this class is a singleton. it will only ever be created once in the game, and all other instances will be erased on Awake().
    //while it includes a function to carry itself over between scene transitions, extras are to be placed in every scene to ease debugging. 

    public static TimeManagerScript instance;

    public int currentDay = 0;
    public int finalDay = 4;

    public int currentHour = 0;
    public int finalHour = 3;



    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void IncrementTime()
    {
        if (currentHour <= finalHour)
        {
            currentHour++;
        }
        else
        {
            NextDay();
        }

    }

    public void NextDay()
    {
        if (currentDay <= finalDay)
        {
            currentDay++;
        }

    }


}
