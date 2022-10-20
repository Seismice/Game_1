using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private bool scale;
    [SerializeField] private float defaultX;
    [SerializeField] private float defaultY;
    [SerializeField] private float x;
    [SerializeField] private float y;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter()
    {
        if(scale == true)
        {
            GetComponent<RectTransform>().localScale = new Vector2(x, y);
        }
    }

    public void OnPointerExit()
    {
        if (scale == true)
        {
            GetComponent<RectTransform>().localScale = new Vector2(defaultX, defaultY);
        }
    }
}
