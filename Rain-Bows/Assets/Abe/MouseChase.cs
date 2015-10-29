// ----- ----- ----- ----- -----
//
// MouseChase
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

[AddComponentMenu("MyScript/MouseChase")]
public class MouseChase : MonoBehaviour
{
	#region 変数
	
	[HideInInspector]
	public bool isChase = true;

    private ParticleSystem particleSystem;
    
    #endregion


    #region プロパティ

    #endregion


    #region メソッド

    //初期化処理
    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    //更新前処理
    void Start()
    {
        particleSystem.Clear();
        particleSystem.Stop();
    }

    // 更新処理
    void Update()
    {
		if (!isChase)
		{
			return;
		}

        if(Input.GetMouseButtonDown(0))
        {
            particleSystem.Play();
            particleSystem.startLifetime = 60 * 60 * 60 * 24;
        }

        if(Input.GetMouseButtonUp(0))
		{
			particleSystem.startLifetime = 0;
            particleSystem.Pause();
            isChase = false;
		}

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;

		Vector3 position = Camera.main.ScreenToWorldPoint (mousePos);

		transform.position = position;
    }
	#endregion
}