using UnityEngine;

public class SceneBorderManager : MonoBehaviour
{
    private void Awake()
    {
        SceneBorders.SetBorders(
            GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)),
            GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)));
    }
}
