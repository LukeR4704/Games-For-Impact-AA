using UnityEngine;
using UnityEngine.UI;

public class NpcBobbing : MonoBehaviour
{


    private bool bobbing = true;

    void Update()
    {
        if (bobbing)
        {
            transform.position += new Vector3(0, Mathf.Lerp(-100, 100, 0.5f), 0);
            Debug.Log(Mathf.Lerp(-100, 100, 0.5f));
        }
    }
}
