using UnityEngine;
using TMPro;



public class UI_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hourText, dayText;
    private string[] timePeriods = { "Morning", "Afternoon", "Evening" };
    [SerializeField] private GameObject debugButtons;

    private bool debugActive = false;

    public static UI_Script Instance { get; private set; }

    private void Start()
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



        debugButtons.SetActive(false);
        TimeUpdate();
        TimeManagerScript.Instance.passTime.AddListener(TimeUpdate);
        TimeManagerScript.Instance.passDay.AddListener(TimeUpdate);
    }


    public void ShowDebugOptions()
    {
        
        if (!debugActive)
        {
            debugButtons.SetActive(true);
        }
        else 
        {
            debugButtons.SetActive(false); 
        }
    }

    public void TimeUpdate()
    {
        hourText.text = timePeriods[TimeManagerScript.Instance.currentHour];
        dayText.text = "Day: " + ((TimeManagerScript.Instance.currentDay) + 1);
    }
}
