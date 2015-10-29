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
using System.Collections;
using System.Collections.Generic;

public static class VectorUtility
{
    public static Vector2 xy(this Vector3 a)
    {
        return new Vector2(a.x, a.y);
    }

    public static Vector2 xz(this Vector3 a)
    {
        return new Vector2(a.x, a.z);
    }

    public static Vector2 yz(this Vector3 a)
    {
        return new Vector2(a.y, a.z);
    }
}