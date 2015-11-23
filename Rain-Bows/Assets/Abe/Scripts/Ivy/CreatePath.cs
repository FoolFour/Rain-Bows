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
    private int pathInterval;

    [SerializeField, Tooltip("")]
    private int pathNumber;

    private MouseTotalDistance totalDistance;

    private float nextCreateDistance;
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
        path = new Vector3[pathNumber];
    }

    // 更新前処理
    void Start()
    {
        nextCreateDistance = 0;
        arrayNumber = 0;
    }

    // 更新処理
    void Update()
    {
        if(totalDistance.TotalDistance >= nextCreateDistance && arrayNumber < pathNumber)
        {
            nextCreateDistance += pathInterval;
            path[arrayNumber] = transform.position;
            arrayNumber++;
        }
    }

    public void PathAdd(Vector3 position)
    {
        if(arrayNumber > pathNumber)
        {
            path[arrayNumber] = position;
            arrayNumber++;
        }
    }

    public void PathEnd()
    {
        if(arrayNumber < pathNumber)
        {
            for(int i = arrayNumber; i < pathNumber; i++)
            {
                path[i] = transform.position;
            }
        }
    }
	#endregion
}