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
    private MouseLineCast    mouseRay;

    private RaycastHit? hitInfo;
        
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
        mouseRay           = GetComponent<MouseLineCast>();
    }

    // 更新前処理
    void Start()
    {
        particleSystem.Clear();
        particleSystem.Stop();

        DrawBegin(); 
    }

    // 更新処理
    void Update()
    {
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



        if(mouseRay.IsHit)
        {
            hitInfo = mouseRay.HitInfo;
        }
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
        createPath.PathEnd();
    }

    void LimitTotalDistance()
    {
        //書ける線の距離
        if(mouseTotalDistance.TotalDistance > limitDistance)
        {
            mouseChase.enabled = false;
            return;
        }

        //レイを飛ばす
        mouseRay.HitCheck();

        if(mouseRay.IsHit)
        {
            //クリックしたときに当たっているオブジェクトで判定しないように
            if(!hitInfo.HasValue)
            {
                mouseChase.enabled = false;
                hitInfo = mouseRay.HitInfo;
                createPath.PathAdd(hitInfo.Value.point);
                
                return;
            }
        }

        if(hitInfo.HasValue)
        {
            //これをしないとクリックしたときのオブジェクトから離れてまた当たった時に判定してくれない
            hitInfo = null;
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