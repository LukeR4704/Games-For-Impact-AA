using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject mapPanel;

    public void ToggleMap()
    {
        mapPanel.SetActive(!mapPanel.activeSelf);
    }

    public void LoadLocation(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}