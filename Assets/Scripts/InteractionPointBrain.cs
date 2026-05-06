using UnityEngine;
using UnityEngine.UI;

public class InteractionPointBrain : MonoBehaviour
{

    private Button[] buttons;
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
        buttons = GetComponentsInChildren<Button>(true);

        foreach(Button interactPoint in buttons)
        {
            interactPoint.interactable = false;
        }
    }

    //enables interaction buttons if the player is in the "looking" state
    public void LoadInteractionPoints()
    {
        buttons = GetComponentsInChildren<Button>(true);

        if (looking)
        {
            foreach (Button interactPoint in buttons)
            {
                interactPoint.interactable = true;
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
