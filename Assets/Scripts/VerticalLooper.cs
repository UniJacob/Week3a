using UnityEngine;

public class VerticalLooper : MonoBehaviour
{
    [SerializeField] string borderTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(borderTag) && enabled)
        {
            transform.position = new((float)(transform.position.x * -0.98), transform.position.y, transform.position.z);
        }
    }
}
