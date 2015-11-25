using UnityEngine;
using System.Collections;

public class Rope : ICharaState {

    GameObject dotDrawer;

    public void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

        dotDrawer = m_HitObject.transform.parent.FindChild("DotDrawer").gameObject;
        Vector3[] path = dotDrawer.GetComponent<CreatePath>().Path;
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
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = false;
        rigidbody.AddForce(normal[normal.Length-1].xy(), ForceMode2D.Impulse);
        m_next = StateName.Default;
        m_isDead = true;
    }
}
