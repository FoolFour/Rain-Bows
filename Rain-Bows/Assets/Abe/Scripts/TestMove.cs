// ----- ----- ----- ----- -----
//
// TestMove
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

[AddComponentMenu("MyScript/TestMove")]
public class TestMove : MonoBehaviour
{
	#region 変数

    //[SerializeField, Tooltip("説明文")]

    Hashtable hashtable = new Hashtable();

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {

    }

    // 更新前処理
    void Start()
    {
        Vector3[] path =
        {
            new Vector3(-6, -3,  0),
            new Vector3( 0, -5,  0),
            new Vector3( 0,  5,  0),
            new Vector3( 6,  3,  0)
        };
        hashtable.Add("path", path);
        hashtable.Add("time", 3.0f);
        hashtable.Add("easetype", iTween.EaseType.easeOutSine);
        iTween.MoveTo(gameObject, hashtable);
    }

    // 更新処理
    void Update()
    {
        
    }
	#endregion
}