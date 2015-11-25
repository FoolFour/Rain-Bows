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

    [SerializeField, Tooltip("消える時の時間"),Range(0, 1)]
    private float erase;

    private ParticleSystem     particleSystem;

    private MouseChase         mouseChase;
    private MouseTotalDistance mouseTotalDistance;
    private CreatePath         createPath;
    private MouseLineCast      mouseRay;

    private bool        hit;   
    

    #endregion

    #region プロパティ

    public float LimitDistance
    {
        get
        {
            return limitDistance;
        }
    }

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

        hit = true;
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
        EraseDot();
    }

    void LimitTotalDistance()
    {
        Debug.Log(mouseRay.IsHit);
        //書ける線の距離
        if(mouseTotalDistance.TotalDistance > limitDistance)
        {
            mouseChase.enabled = false;
            return;
        }

        //レイを飛ばす
        mouseRay.HitCheck();

        if(mouseRay.IsHit && !hit)
        {
            //クリックしたときに当たっているオブジェクトで判定しないように
            mouseChase.enabled = false;
            return;
        }

        if(hit)
        {
            //これをしないとクリックしたときのオブジェクトから離れてまた当たった時に判定してくれない
            hit = mouseRay.IsHit;
        }
    }

    public void EraseDot()
    {
        StartCoroutine(Erase());
    }

    IEnumerator Erase()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] particles;

	    particleSystem = GetComponent<ParticleSystem>();
        
        //現在のパーティクルの数を取得
        particles = new ParticleSystem.Particle[particleSystem.maxParticles]; 

        //現在のパーティクルの状態を取得
        int numParticlesAlive = particleSystem.GetParticles(particles);

        while(true)
        {
            //パーティクルのアルファを下げる
            for (int i = 0; i < numParticlesAlive; i++)
		    {
			    particles[i].color -= new Color(0, 0, 0, erase);
		    }

            //状態を反映
            particleSystem.SetParticles(particles, numParticlesAlive);

            if(particles[0].color.a <= 0)
            {
                //終了処理
                particleSystem.Stop();
                yield break;
            }
            yield return null;
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