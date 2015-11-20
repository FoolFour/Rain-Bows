// ----- ----- ----- ----- -----
//
// SeedManager
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

[AddComponentMenu("MyScript/SeedManager")]
public class SeedManager : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("マウスのポインター")]
    private GameObject mousePointer;

    [SerializeField, Tooltip("タネの種類")]
    private SeedKind   seedKind;

    [SerializeField, Tooltip("ツタのオブジェクト")]
    private GameObject IvyObject;

    [SerializeField, Tooltip("水鉄砲のオブジェクト")]
    private GameObject WaterGunObject;

    [SerializeField, Tooltip("シャボンのオブジェクト")]
    private GameObject BubbleObject;

    [SerializeField, Tooltip("竹のオブジェクト")]
    private GameObject BambooObject;


    //シードを入れておくオブジェクト
    private Dictionary<SeedKind, GameObject> seedObjects = new Dictionary<SeedKind, GameObject>();

    private MouseRay mouseRay;

    #endregion


    #region プロパティ



    #endregion


    #region メソッド


	// 初期化処理
    void Awake()
    {
        mouseRay = GetComponent<MouseRay>();
    }

    // 更新前処理
    void Start()
    {
        seedObjects[SeedKind.Ivy]      = IvyObject;
        seedObjects[SeedKind.WaterGun] = WaterGunObject;
        seedObjects[SeedKind.Bubble]   = BubbleObject;
        seedObjects[SeedKind.Bamboo]   = BambooObject;
    }

    // 更新処理
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseRay.HitCheck();

            if(mouseRay.IsHit)
            {
                if(mouseRay.HitInfo.collider.tag == "Seed")
                {
                    Destroy(mouseRay.HitInfo.collider.gameObject);
                }
                else if(mouseRay.HitInfo.collider.tag == "Ground")
                {
                    Instantiate(seedObjects[seedKind], mousePointer.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public void OnSetIvy()
    {
        seedKind = SeedKind.Ivy;
    }

    public void OnSetWaterGun()
    {
        seedKind = SeedKind.WaterGun;
    }

    public void OnSetBubble()
    {
        seedKind = SeedKind.Bubble;
    }

    public void OnSetBamboo()
    {
        seedKind = SeedKind.Bamboo;
    }
	#endregion
}