using UnityEngine;
using UnityEngine.UI;

public class AlfaObject : MonoBehaviour
{
    [SerializeField]
    Text text = null;

    [SerializeField]
    Image image = null;

    public void ChangeColor(float alfa)
    {
        Color color = Color.white;

        if(text != null)
        {
            color = text.color;
            color.a = alfa;
            text.color = color;
        }
        if(image != null)
        {
            color = text.color;
            color.a += alfa;
            text.color = color;
        }
    }
}
