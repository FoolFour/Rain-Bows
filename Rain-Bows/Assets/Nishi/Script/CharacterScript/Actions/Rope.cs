using UnityEngine;
using System.Collections;

public class Rope : ICharaState {

    Transform dotDrawer;
    new Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        rigidbody.isKinematic = true;

        dotDrawer = m_HitObject.transform.parent.FindChild("DotDrawer");
        
        Vector3[] path;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -Vector3.up);

        //colliderがあれば当たっている
        try
        {
            if(hitInfo.collider.tag == "Ground") //nullと仮定
            {
                path = dotDrawer.GetComponent<CreatePath>().Path;
            }
            else
            {
                throw null;
            }
        }
        catch
        {
            //同じ処理
        }

        if(GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            path = dotDrawer.GetComponent<CreatePath>().Path;
        }
        else
        {
            path = dotDrawer.GetComponent<CreatePath>().GetRoute(transform.position, m_dir);
        }
        
        Hashtable hash = new Hashtable();
        hash.Add("time", 5.0f);
        hash.Add("easeType", iTween.EaseType.linear);
        hash.Add("oncompletetarget", gameObject);
        hash.Add("oncomplete", "ChageState");
        hash.Add("path", path);
        iTween.MoveTo(gameObject, hash);
    }

    public void Update()
    {

    }

    public override bool IsDead()
    {
        return m_isDead;
    }

    public override StateName Next()
    {
        return m_next;
    }

    public override void HitSend(GameObject hit)
    {
        m_HitObject = hit;
    }

    public override GameObject HitCall()
    {
        return m_HitObject;
    }

    public void ChageState()
    {
        Vector3[] normal = dotDrawer.GetComponent<CreatePath>().Normal;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(normal[normal.Length-1].xy(), ForceMode2D.Impulse);
        m_next = StateName.Default;
        m_isDead = true;
    }
}
