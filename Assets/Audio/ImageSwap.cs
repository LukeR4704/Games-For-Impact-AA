using UnityEngine;
using UnityEngine.UI;

public class ImageSwap : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    public void OnToggleChanged(bool isOn)
    {
        targetImage.sprite = isOn ? onSprite : offSprite;
    }
}