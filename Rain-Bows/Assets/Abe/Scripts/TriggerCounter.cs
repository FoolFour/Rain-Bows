// ----- ----- ----- ----- -----
//
// TriggerCounter
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

[AddComponentMenu("MyScript/TriggerCounter")]
public class TriggerCounter : MonoBehaviour
{
	#region 変数

    private List<GameObject> players = new List<GameObject>();

    

    #endregion


    #region プロパティ

    public List<GameObject> Players
    {
        get{ return players; }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            players.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            players.Remove(other.gameObject);
        }
    }
	#endregion
}