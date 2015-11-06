// ----- ----- ----- ----- -----
//
// DrawPath
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

[AddComponentMenu("MyScript/DrawPath")]
public class DrawPath : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("説明文")]
    GameObject dotParticle;

    [SerializeField, Tooltip("パスの移動が完了する時間")]
    private float time;

    private CreatePath createPath;
    private Hashtable  hashTable = new Hashtable();
    TrailRendererWith2DCollider trail;

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        trail = GetComponent<TrailRendererWith2DCollider>();
        createPath = dotParticle.GetComponent<CreatePath>();
    }

    // 更新前処理
    void Start()
    {
        trail.lifeTime = 0;
    }

    // 更新処理
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnDraw();
        }
    }

    public void OnDraw()
    {
        transform.position = createPath.Path[0];
        hashTable.Add("path", createPath.Path);
        hashTable.Add("time", time);
        hashTable.Add("easetype", iTween.EaseType.easeOutSine);
        iTween.MoveTo(gameObject, hashTable);
        StartCoroutine(Reset());
        StartCoroutine(Complete());
    }

    IEnumerator Reset()
    {
        yield return null;
        trail.lifeTime = 30;
    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(time);
        trail.pausing = true;
    }
	#endregion
}