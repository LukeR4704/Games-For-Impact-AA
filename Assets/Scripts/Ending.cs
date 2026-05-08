using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject[] endings;
    void Start()
    {
        AllOptionalQuestsClear();    
    }

    void AllOptionalQuestsClear()
    {
        int c = 0;
        
        foreach (bool q in QuestBrain.instance.optionalQuestsCleared)
        {
            if (q)
            {
                c++;
            }
        }
        if(c >= 2)
        {
            endings[0].SetActive(false);
            endings[1].SetActive(true);
        }
    }

}
