// ----- ----- ----- ----- -----
//
// CreatePath
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

[RequireComponent(typeof(MouseTotalDistance))]
[AddComponentMenu("MyScript/CreatePath")]
public class CreatePath : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("説明文")]
    private int number;

    [SerializeField, Tooltip("")]
    private int arrayLength;

    private MouseTotalDistance totalDistance;

    private float num;
    private int arrayNumber;

    [SerializeField]
    private Vector3[] path;

    public Vector3[] Path
    {
        get
        {
            return path;
        }
    }

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

    // 初期化処理
    void Awake()
    {
        totalDistance = GetComponent<MouseTotalDistance>();
        path = new Vector3[arrayLength];
    }

    // 更新前処理
    void Start()
    {
        num = 0;
        arrayNumber = 0;
    }

    // 更新処理
    void Update()
    {
        if(totalDistance.TotalDistance >= num && arrayNumber < arrayLength)
        {
            num += number;
            path[arrayNumber] = transform.position;
            arrayNumber++;
        }
    }
	#endregion
}