// ----- ----- ----- ----- -----
//
// VectorUtility
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;

public static class VectorUtility
{
    /// <summary>
    /// Vector3のx yをそれぞれVector2のx yに格納します
    /// </summary>
    /// <returns>new Vector2(Vector3.x, Vector3.y)</returns>
    public static Vector2 xy(this Vector3 a)
    {
        return new Vector2(a.x, a.y);
    }

    /// <summary>
    /// Vector3のx zをそれぞれVector2のx zに格納します
    /// </summary>
    /// <returns>new Vector2(Vector3.x, Vector3.z)</returns>
    public static Vector2 xz(this Vector3 a)
    {
        return new Vector2(a.x, a.z);
    }

    /// <summary>
    /// Vector3のy zをそれぞれVector2のx yに格納します
    /// </summary>
    /// <returns>new Vector2(Vector3.y, Vector3.z)</returns>
    public static Vector2 yz(this Vector3 a)
    {
        return new Vector2(a.y, a.z);
    }
}