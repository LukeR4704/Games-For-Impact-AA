using UnityEngine;
public class CalendarSceneSwapper : MonoBehaviour
{
    //just a temp script so i can swap days when testing in a method similar to the intended way
    float timer;
    private void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 4;
        if(timer > 2)
        {
            TimeManagerScript.Instance.CalendarToRooms();
        }
    }
}
