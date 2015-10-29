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

    #endregion

    #region メソッド

    // 初期化処理
    void Awake()
    {
        particleSystem     = GetComponent<ParticleSystem>();
        mouseChase         = GetComponent<MouseChase>();
        mouseTotalDistance = GetComponent<MouseTotalDistance>();
    }

    // 更新前処理
    void Start()
    {
        particleSystem.Clear();
        particleSystem.Stop();

        //無駄な処理をさせないように
        mouseChase.enabled         = false;
        mouseTotalDistance.enabled = false;
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
        mouseChase.enabled = true;
        mouseChase.SyncMousePosition();

        mouseTotalDistance.enabled = true;
        mouseTotalDistance.ResetTotalDistance();

        particleSystem.Play();
        particleSystem.startLifetime = 60 * 60 * 60 * 24; //24時間
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
	#endregion
}