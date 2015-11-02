// ----- ----- ----- ----- -----
//
// DrawDotLine
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using System.Collections;
using UnityEngine;

[AddComponentMenu("MyScript/DrawDotLine")]
public class DrawDotLine : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("線の制限")]
	private float limitDistance;

    private ParticleSystem     particleSystem;
    private MouseChase         mouseChase;
    private MouseTotalDistance mouseTotalDistance;
    private CreatePath         createPath;

    public float LimitDistance
    {
        get
        {
            return limitDistance;
        }
    }

    #endregion

    #region プロパティ



    #endregion

    #region メソッド

    // 初期化処理
    void Awake()
    {
        particleSystem     = GetComponent<ParticleSystem>();
        mouseChase         = GetComponent<MouseChase>();
        mouseTotalDistance = GetComponent<MouseTotalDistance>();
        createPath         = GetComponent<CreatePath>();
    }

    // 更新前処理
    void Start()
    {
        particleSystem.Clear();
        particleSystem.Stop();

        //無駄な処理をさせないように
        mouseTotalDistance.enabled = false;
        createPath.enabled = false;
    }

    // 更新処理
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { DrawBegin();          }
        if(Input.GetMouseButton    (0)) { LimitTotalDistance(); }
        if(Input.GetMouseButtonUp  (0)) { DrawEnd();            }
    }

    void DrawBegin()
    {
        //初期化
        createPath.enabled = true;

        mouseTotalDistance.enabled = true;
        mouseTotalDistance.ResetTotalDistance();

        mouseChase.SyncMousePosition();

        particleSystem.Play();

        mouseChase.SyncMousePosition();
        particleSystem.startLifetime = 60 * 60 * 60 * 24; //24時間
        particleSystem.startColor = new Color(1, 1, 1, 0);
        StartCoroutine(Reset());
    }

    void DrawEnd()
    {
        //念のため
		particleSystem.startLifetime = 0;

        //Pauseで画面に残る
        particleSystem.Pause();
        mouseChase.enabled         = false;
        mouseTotalDistance.enabled = false;
        this.enabled               = false;
    }

    void LimitTotalDistance()
    {
        //書ける線の距離
        if(mouseTotalDistance.TotalDistance > limitDistance)
        {
            mouseChase.enabled = false;
        }
        
    }

    IEnumerator Reset()
    {
        yield return null;
        particleSystem.Clear();
        particleSystem.startColor = new Color(1, 1, 1, 1);
    }
	#endregion
}