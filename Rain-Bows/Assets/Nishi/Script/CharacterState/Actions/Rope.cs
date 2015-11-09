using UnityEngine;
using System.Collections;

public class Rope : ICharaState {

    private float m_Dir;
    private Parameter m_Prameter;
    private GameObject ivyObject;


    public Rope(GameObject obj) : base(obj){ }

    public override void Enter()
    {
        m_Prameter = m_GameObject.GetComponent<Parameter>();
        m_Dir = m_Prameter.dir;

    }

    //Update
    public override void Action()
    {
        if(ivyObject == null)
        {
            return;
        }
        m_GameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        Hashtable hash = new Hashtable();

        GameObject dotParticle = ivyObject.transform.Find("DotDrawer").gameObject;

        Vector3[] path = dotParticle.GetComponent<CreatePath>().Path;

        hash.Add("time", 20.0f);
        hash.Add("easeType", iTween.EaseType.linear);
        hash.Add("path", path);
        hash.Add("oncomplete", "Complete");
        hash.Add("oncompletetarget", m_GameObject);

        iTween.MoveTo(m_GameObject, hash);
        ivyObject = null;
    }

    public override void Exit()
    {

    }

    public override void TriggerEnter(Collider2D other)
    {
        base.TriggerEnter(other);
        if(other.gameObject.tag == "Ivy")
        {
            ivyObject = other.transform.parent.gameObject;
        }
    }

    public override bool IsDead()
    {
        return m_isDead;
    }

    public override StateName Next()
    {
        return m_next;
    }

    public override void Complete()
    {
        m_GameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
