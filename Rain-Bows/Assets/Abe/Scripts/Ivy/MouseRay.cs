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

    [SerializeField, Tooltip("毎回Rayを飛ばすか初回のみ有効")]
    private bool onAwakeHitRayUpdate;

    [SerializeField, Tooltip("チェックするレイヤー")]
    private LayerMask layer;

    //ヒットしたかどうか
    private bool isHit;

    //ヒットの情報
    private RaycastHit hitInfo;

    #endregion


    #region プロパティ

    public bool IsHit
    {
        get{ return isHit; }
    }

    public RaycastHit HitInfo
    {
        get
        {
            //ヒットしているのみ
            Debug.Assert(IsHit, "Ray don't hit any GameObjects");
            return hitInfo;
        }
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
        //毎回有効になっているかどうかをみないようにするため
        if(onAwakeHitRayUpdate)
        {
            StartRayUpdate();
        }
    }

    IEnumerator RayUpdate()
    {
        while(true)
        {
            MouseRayHit();
            yield return null;
        }
    }

    //任意のタイミングでヒットされたかどうかを見る為 publicに
    public void MouseRayHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        isHit = Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layer);
    }

    public void StartRayUpdate()
    {
        StartCoroutine(RayUpdate());
    }

    public void StopRayUpdate()
    {
        StopCoroutine (RayUpdate());
    }
	#endregion
}