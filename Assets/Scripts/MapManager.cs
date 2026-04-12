using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }
    public GameObject mapPanel;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleMap()
    {
        mapPanel.SetActive(!mapPanel.activeSelf);
    }

    public void LoadLocation(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        mapPanel.SetActive(false);
    }
}