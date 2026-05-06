using System.Collections;
using UnityEngine;

public class CalendarSceneSwapper : MonoBehaviour
{
    [Header("Calendar Days In Order")]
    public GameObject[] days;

    [Header("Audio")]
    public AudioSource markerAudio;

    private void OnEnable()
    {
        StartCoroutine(CalendarSequence());
    }

    IEnumerator CalendarSequence()
    {
        int newDay = TimeManagerScript.Instance.currentDay;
        int previousDay = newDay - 1;

        // Turn all days off
        foreach (GameObject day in days)
        {
            day.SetActive(false);
        }

        // Show previous day
        if (previousDay >= 0 && previousDay < days.Length)
        {
            days[previousDay].SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        // Hide previous day
        if (previousDay >= 0 && previousDay < days.Length)
        {
            days[previousDay].SetActive(false);
        }

        if (markerAudio != null)
        {
            markerAudio.Play();
        }

        // Show new day
        if (newDay >= 0 && newDay < days.Length)
        {
            days[newDay].SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        TimeManagerScript.Instance.CalendarToRooms();
    }
}