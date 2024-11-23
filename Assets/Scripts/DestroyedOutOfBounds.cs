using UnityEngine;

public class ViewToBorders : MonoBehaviour
{
    private Vector3 bottomLeftBorder, topRightBorder;
    private Bounds bounds;

    private void Start()
    {
        bottomLeftBorder = SceneBorders.BottomLeft() * 2;
        topRightBorder = SceneBorders.TopRight() * 2;
    }


    private void Update()
    {
        if (!IsPositionBounded(transform.position, bottomLeftBorder, topRightBorder))
        {
            Destroy(this.gameObject);
            return;
        }
    }

    bool IsPositionBounded(Vector3 position, Vector3 bottomLeft, Vector3 topRight)
    {
        return position.x >= bottomLeft.x && position.x <= topRight.x &&
               position.y >= bottomLeft.y && position.y <= topRight.y;
    }
}
