// ----- ----- ----- ----- -----
//
// MouseRay
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

[AddComponentMenu("MyScript/MouseRay")]
public class MouseRay : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("説明文")]
    bool isHit;

    

    #endregion


    #region プロパティ

    public bool IsHit
    {
        get{ return isHit; }
    }

    #endregion


    #region メソッド

    // 初期化処理
    void Awake()
    {

    }

    // 更新前処理
    void Start()
    {
        
    }

    // 更新処理
    void Update()
    {
        
    }
	#endregion
}