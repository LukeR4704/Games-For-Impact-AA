using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPointBrain : MonoBehaviour
{

    public List<Button> buttons = new List<Button>();
    private TextBox textBox;
    public bool looking = false;

    void Start()
    {
        textBox = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().textBox;
        UnloadInteractionPoints();
        textBox.onLineStart.AddListener(UnloadInteractionPoints);
        textBox.onDialogueComplete.AddListener(LoadInteractionPoints);
    }

    //disables interaction points regardless of state
    public void UnloadInteractionPoints()
    {
        foreach (Transform child in transform)
        {
            try
            {
                buttons.Remove(child.GetComponent<Button>());
            }
            catch
            {
                Debug.Log("No button found on this object");
            }
        }

        foreach(Button interactPoint in buttons)
        {
            if (interactPoint != null)
            {
                interactPoint.interactable = false;
            }
        }
    }

    //enables interaction buttons if the player is in the "looking" state
    public void LoadInteractionPoints()
    {
        foreach (Transform child in transform)
        {
            try
            {
                buttons.Add(child.GetComponent<Button>());
            }
            catch
            {
                Debug.Log("No button found on this object");
            }

            if (looking)
            {
                foreach (Button interactPoint in buttons)
                {
                    interactPoint.interactable = true;
                }
            }



        }
    }

    public void StartLooking()
    {
        looking = true;
        LoadInteractionPoints();
    }

    public void StopLooking()
    {
        looking = false;
        UnloadInteractionPoints();
    }


}
