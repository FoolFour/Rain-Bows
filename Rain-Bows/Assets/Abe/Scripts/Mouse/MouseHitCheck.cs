// ----- ----- ----- ----- -----
//
// MouseHitCheck
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

[AddComponentMenu("Mouse/MouseHitCheck")]
public abstract class MouseHitCheck : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("毎回行うか？　初回のみ有効")]
    protected bool onAwakeHitUpdate;

    [SerializeField, Tooltip("チェックするレイヤー")]
    protected LayerMask layer;

    //ヒットの情報
    protected RaycastHit2D hitInfo;
    #endregion


    #region プロパティ

    public bool IsHit
    {
        get{ return hitInfo.collider; }
    }

    public Collider2D collider2D
    {
        get
        {
            //ヒットしているのみ
            Debug.Assert(IsHit, "Ray don't hit any GameObjects");
            return hitInfo.collider;
        }
    }

    public RaycastHit2D HitInfo
    {
        get{ return hitInfo; }
    }

    #endregion


    #region メソッド

    void Awake()
    {
        HitAwake();
    }

    protected virtual void HitAwake()
    {
        //
    }

    // 更新前処理
    void Start()
    {
        //毎回有効になっているかどうかをみないようにするため
        if(onAwakeHitUpdate)
        {
            StartUpdate();
        }
    }

    public void StartUpdate()
    {
        StartCoroutine(HitUpdate());
    }

    public void StopUpdate()
    {
        StopCoroutine (HitUpdate());
    }

    public IEnumerator HitUpdate()
    {
        while(true)
        {
            HitCheck();
            yield return null;
        }
    }

    public abstract void HitCheck();
	#endregion
}