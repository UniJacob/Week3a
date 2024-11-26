using TMPro;
using UnityEngine;

public class FadeInAndOut : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshPro;
    [SerializeField] float FadeOutSpeed;
    void Update()
    {
        Color color = textMeshPro.color;
        color.a -= FadeOutSpeed * Time.deltaTime;
        if (color.a <= 0)
        {
            Destroy(this);
            return;
        }
        textMeshPro.color = color;
    }
}
