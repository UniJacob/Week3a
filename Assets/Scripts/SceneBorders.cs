using UnityEngine;

public static class SceneBorders
{
    private static Vector3 bl, tr;

    public static void SetBorders(Vector3 bottomLeft_, Vector3 topRight_)
    {
        bl = bottomLeft_;
        tr = topRight_;
    }

    public static Vector3 BottomLeft()
    {
        return bl;
    }
    public static Vector3 TopRight()
    {
        return tr;
    }
}
