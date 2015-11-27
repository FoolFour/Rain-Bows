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
using System;
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

    private MouseTotalDistance    totalDistance;
    private MousePreviousPosition mousePreviousPosition;

    private float nextCreateDistance;
    private int arrayNumber;

    [SerializeField]
    private Vector3[] path;

    [SerializeField]
    private Vector3[] normal;

    #endregion


    #region プロパティ

    public Vector3[] Path
    {
        get{ return path; }
    }

    public Vector3[] Normal
    {
        get{ return normal; }
    }

    #endregion


    #region メソッド

    // 初期化処理
    void Awake()
    {
        totalDistance         = GetComponent<MouseTotalDistance   >();
        mousePreviousPosition = GetComponent<MousePreviousPosition>();
        path   = new Vector3[pathNumber];
        normal = new Vector3[pathNumber];
    }

    // 更新前処理
    void Start()
    {
        nextCreateDistance = 0;
        arrayNumber        = 0;
    }

    // 更新処理
    void Update()
    {
        if(totalDistance.TotalDistance >= nextCreateDistance && arrayNumber < pathNumber)
        {
            //一定長さで記録をとれるように
            nextCreateDistance += pathInterval;

            path  [arrayNumber] = transform.position;

            //法線は葉っぱ、ルートを作る時に必要
            normal[arrayNumber] = mousePreviousPosition.Normal;
            arrayNumber++;
        }
    }

    public void PathEnd()
    {
        if(arrayNumber < pathNumber)
        {
            for(int i = arrayNumber; i < pathNumber; i++)
            {
                normal[i] = Vector3.zero;
                path[i]   = transform.position;
            }
        }
    }

    public void GetRoute(Vector2 colPoint, int direction)
    {
        int index = GetNearPointIndex(colPoint);

        int arrayLength = path.Length - index + 1;

        Vector3 n = normal[index];

        //符号をみて符号が
        //
        //・合致していれば順番に
        //・合致しなければ逆順に
        //
        //パスを取っていく

        float nSign = Mathf.Sign(n.x);
        float dSign = Mathf.Sign(direction);
        
        Vector3[] array = new Vector3[path.Length - index + 1];

        if(dSign == nSign)
        {
            Array.Copy( path, index + 1, array, path.Length, path.Length - index + 1);
        }
        else
        {
            Vector3[] path_ = path;
            Array.Reverse(path_);
            Array.Copy(path_, index + 1, array, path.Length, path.Length - index + 1);
        }
    }

    private int GetNearPointIndex(Vector2 colPoint)
    {
        //if文でnullかどうかを判断するため
        float? minLength = null;

        //breakを通らなかったとき末尾がcolPointに一番近いため
        int    index     = path.Length - 1;

        for(int i = 0; i < path.Length; i++)
        {
            float length;
            length = VectorUtility.DistanceSquare(path[i].xy(), colPoint); //比較のみ

            //nullかどうかを先に見てエラー回避
            if(!minLength.HasValue || minLength.Value > length)
            {
                minLength = length;
                continue;
            }

            if(minLength.Value <= length)
            {
                //minLengthは1つ前のパスの情報になるので
                //i - 1を返す
                index = i - 1;
                break;
            }
        }
        
        return index;
    }
	#endregion
}