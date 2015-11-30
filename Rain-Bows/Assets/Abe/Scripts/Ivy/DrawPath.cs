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
public class DrawPath : ISeed
{
	#region 変数

    [SerializeField, Tooltip("パスの移動が完了する時間")]
    private float time;

    private GameObject dotParticle;
    private CreatePath createPath;
    private Hashtable  hashTable = new Hashtable();
    private TrailRendererWith2DCollider trail;

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        dotParticle = transform.parent.Find("DotDrawer").gameObject;
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
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnGrow();
        }
#endif
    }

    public override void OnGrow()
    {
        transform.position = createPath.Path[0];
        hashTable.Add("path", createPath.Path);
        hashTable.Add("time", time);
        hashTable.Add("easetype", iTween.EaseType.easeOutSine);
        hashTable.Add("oncompletetarget", gameObject);
        hashTable.Add("oncomplete", "Complete");

        iTween.MoveTo(gameObject, hashTable);

        StartCoroutine(Reset());
        dotParticle.GetComponent<DrawDotLine>().EraseDot();
    }

    IEnumerator Reset()
    {
        yield return null;
        trail.lifeTime = 30;
    }

    private void Complete()
    {
        trail.pausing = true;
        enabled = false;
    }
	#endregion
}