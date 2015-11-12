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


    //シードを入れておくオブジェクト
    private Dictionary<SeedKind, GameObject> seedObjects = new Dictionary<SeedKind, GameObject>();

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
        seedObjects[SeedKind.Ivy]    = IvyObject;
        seedObjects[SeedKind.WaterGun] = WaterGunObject;
    }

    // 更新処理
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool hit = Physics.Raycast(ray, 100, LayerMask.GetMask(new string[] { "GreenField" }));

            if(hit)
            {
                Instantiate(seedObjects[seedKind], mousePointer.transform.position, Quaternion.identity);
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
	#endregion
}