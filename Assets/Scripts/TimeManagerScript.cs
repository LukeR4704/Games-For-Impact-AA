using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimeManagerScript : MonoBehaviour
{
    //this class is a singleton. it will only ever be created once in the game, and all other instances will be erased on Awake().
    //while it includes a function to carry itself over between scene transitions, extras are to be placed in every scene to ease debugging. 

    public static TimeManagerScript Instance { get; private set;}

    public int currentDay = 0;
    public int finalDay = 4;

    public int currentHour = 0;
    public int finalHour = 1;

    public UnityEvent passTime, passDay;

    


    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }



    }


    public void IncrementTime(int timeSpent)
    {
        currentHour += timeSpent;
        if (currentHour <= finalHour)
        {
            
            passTime?.Invoke();
        }
        else
        {
            NextDay();
        }

    }

    public void NextDay()
    {
            currentDay++;
            currentHour = 0;

            passDay?.Invoke();

            SceneManager.LoadScene("CalendarScene");


    }

    public void CalendarToRooms()
    {
        if (currentDay <= finalDay)
        {
            SceneManager.LoadScene("Bedroom");
        }
        else if (currentDay > finalDay)
        {
            ProceedToEnding();
        }
    }

    public void ProceedToEnding()
    {
        SceneManager.LoadScene("Epilogue");
    }


    public void ResetAll()
    {
        currentDay = 0;
        currentHour = 0;
        passDay?.Invoke();

        
        SceneManager.LoadScene("CalendarScene");
    }

}
