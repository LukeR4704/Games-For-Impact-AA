using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManagerScript : MonoBehaviour
{
    //this class is a singleton. it will only ever be created once in the game, and all other instances will be erased on Awake().
    //while it includes a function to carry itself over between scene transitions, extras are to be placed in every scene to ease debugging. 

    public static TimeManagerScript instance;

    public int currentDay = 0;
    public int finalDay = 4;

    public int currentHour = 0;
    public int finalHour = 3;
    public string[] timeOfDay;

    [SerializeField] private TextMeshProUGUI dayText, hourText;



    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    private void Start()
    {
        NextDay();
        IncrementTime(0);
    }

    public void IncrementTime(int timeSpent)
    {
        currentHour += timeSpent;
        if (currentHour <= finalHour)
        {
            
            hourText.text = "Hour : " + timeOfDay[currentHour];
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
            currentHour = 0;

            dayText.text = "Day : " + currentDay.ToString();
            hourText.text = "Hour : " + timeOfDay[currentHour];

        }

        else if(currentDay > finalDay)
        {
            ProceedToEnding();
        }

    }

    public void ProceedToEnding()
    {
        SceneManager.LoadScene("EndingScene");
    }


    public void ResetAll()
    {
        currentDay = 0;
        currentHour = 0;
        NextDay();
        IncrementTime(0);

        SceneManager.LoadScene("BarryScene");
    }

}
