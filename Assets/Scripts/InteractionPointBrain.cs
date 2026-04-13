using UnityEngine;
using UnityEngine.UI;

public class InteractionPointBrain : MonoBehaviour
{

    private Button[] buttons;

    void Start()
    {
        UnloadInteractionPoints();
    }


    public void UnloadInteractionPoints()
    {
        buttons = GetComponentsInChildren<Button>(true);

        foreach(Button intPoint in buttons)
        {
            intPoint.interactable = false;
        }
    }

    public void LoadInteractionPoints()
    {
        buttons = GetComponentsInChildren<Button>(true);

        foreach (Button intPoint in buttons)
        {
            intPoint.interactable = true;
        }
    }

}
