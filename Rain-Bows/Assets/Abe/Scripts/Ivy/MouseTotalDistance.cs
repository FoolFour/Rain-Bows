// ----- ----- ----- ----- -----
//
// MouseTotalDistance
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

[AddComponentMenu("MyScript/MouseTotalDistance")]
public class MouseTotalDistance : MonoBehaviour
{
	#region 変数

	//進んだ距離
	private float totalDistance;
	private Vector3 previousPosition;
    #endregion


    #region プロパティ

	public float TotalDistance
	{
		get{return totalDistance; }
	}
    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
	{
		totalDistance    = 0;
    }

    //更新前処理
    void Start()
    {
        previousPosition = transform.position;
    }

    //マウスの同期が終わってから実行させる為
	void LateUpdate()
	{
		totalDistance += Vector3.Magnitude(transform.position - previousPosition);

		previousPosition = transform.position;
	}

    public void ResetTotalDistance()
    {
        totalDistance = 0;
    }
	#endregion
}