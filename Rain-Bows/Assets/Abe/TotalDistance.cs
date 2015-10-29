// ----- ----- ----- ----- -----
//
// TotalDistance
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

[RequireComponent(typeof(MouseChase))]
[AddComponentMenu("MyScript/TotalDistance")]
public class TotalDistance : MonoBehaviour
{
	#region 変数

	[SerializeField, Tooltip("線の制限")]
	private float limitDistance;

	//進んだ距離
	private float totalDistance;
	private Vector3 previousPosition;
	private MouseChase mouseChase;
    //private Vector2

    #endregion


    #region プロパティ

	public float TotalDis
	{
		get{return totalDistance; }
	}

    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
	{
		previousPosition = transform.position;
		mouseChase = GetComponent<MouseChase>();
		totalDistance = 0;
		mouseChase.isChase = true;
    }

	void LateUpdate()
	{
		if (Input.GetMouseButton(0)) 
		{
			totalDistance += Vector3.Magnitude(transform.position - previousPosition);
			Debug.Log (totalDistance);

			previousPosition = transform.position;

			if(totalDistance > limitDistance)
			{
				mouseChase.enabled = false;
			}
		}
	}
	#endregion
}