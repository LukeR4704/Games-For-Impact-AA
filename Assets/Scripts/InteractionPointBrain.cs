using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPointBrain : MonoBehaviour
{

    public List<Button> buttons = new List<Button>();
    private TextBox textBox;
    public bool looking = false;
    public Transform[] questPoints;
    public Transform bed;

    void Start()
    {
        textBox = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().textBox;
        UnloadInteractionPoints();
        textBox.onLineStart.AddListener(StopLooking);
        textBox.onDialogueComplete.AddListener(StartLooking);
    }

    //disables interaction points regardless of state
    public void UnloadInteractionPoints()
    {
        /*
        foreach (Transform child in transform)
        {
            try
            {
                buttons.Remove(child.GetComponent<Button>());
            }
            catch
            {
                buttons.Remove(child.GetChild(0).GetComponent<Button>()); 
            }
        }
        */

        foreach (Transform q in questPoints)
        {
            if (!buttons.Contains(q.GetComponentInChildren<Button>()))
            {
                buttons.Remove(q.GetComponentInChildren<Button>());
            }
        }

        if(bed != null)
        {
            buttons.Remove(bed.GetComponentInChildren<Button>());
        }

        StopLooking();

    }



    //enables interaction buttons if the player is in the "looking" state
    public void LoadInteractionPoints()
    {

            /*
            try
            {
                buttons.Add(child.GetComponent<Button>());
            }
            catch
            {
                buttons.Add(child.GetChild(0).GetComponent<Button>()); 
            }
            */
            foreach (Transform q in questPoints)
            {
                if (!buttons.Contains(q.GetComponentInChildren<Button>()))
                {
                    buttons.Add(q.GetComponentInChildren<Button>());
                }
            }

            if (bed != null)
            {
                buttons.Add(bed.GetComponentInChildren<Button>());
            }

            StartLooking();
            Debug.Log(buttons);



    }

    public void StartLooking()
    {
        looking = true;
        foreach (Button interactPoint in buttons)
        {
            if (interactPoint != null)
            {
                interactPoint.interactable = true;
            }
        }
        
    }

    public void StopLooking()
    {
        looking = false;

        foreach (Button interactPoint in buttons)
        {
            if (interactPoint != null)
            {
                interactPoint.interactable = false;
            }
        }
    }


}
