using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    void Start()
    {
        // Ensure the required components are set
        if (buttonImage == null)
        {
            buttonImage = GetComponent<Image>();
        }

        // Store the normal sprite
        if (buttonImage != null)
        {
            normalSprite = buttonImage.sprite;
        }
        else
        {
            Debug.LogError("Image component not found on the button GameObject.");
        }
    }

    // This method is called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null && hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite;
        }
    }

    // This method is called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null && normalSprite != null)
        {
            buttonImage.sprite = normalSprite;
        }
    }
}
