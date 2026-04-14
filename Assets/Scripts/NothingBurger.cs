using UnityEngine;

public class NothingBurger : MonoBehaviour
{
    public GameObject otherBurger;

    public void DisableBurger()
    {
        gameObject.SetActive(false);
        EnableBurger();
    }

    public void EnableBurger()
    {
        otherBurger.SetActive(true);
    }
}
