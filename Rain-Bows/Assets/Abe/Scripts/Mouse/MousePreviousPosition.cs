// ----- ----- ----- ----- -----
//
// MousePreviousPosition
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

[AddComponentMenu("MyScript/MousePreviousPosition")]
public class MousePreviousPosition : MonoBehaviour
{
	#region 変数

    Vector3 previousPosition;

    #endregion


    #region プロパティ

    public Vector3 PreviousPosition
    {
        get { return previousPosition; }
    }

    public Vector3 Normal
    {
        get { return (previousPosition - Input.mousePosition).normalized; }
    }

    public Vector3 PreviousWorldPosition
    {
        get { return Camera.main.ScreenToWorldPoint(previousPosition); }
    }

    #endregion


    #region メソッド
    
    // 更新処理
    void LateUpdate()
    {
        previousPosition = Input.mousePosition;
    }
	#endregion
}