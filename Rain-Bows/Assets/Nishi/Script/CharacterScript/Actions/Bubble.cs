using UnityEngine;
using System.Collections;

public class Bubble : ICharaState {

    public void Start()
    {

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.transform.SetParent(m_HitObject.transform,false);
    }

    public void Update()
    {
        if (gameObject.transform.parent == null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            m_next = StateName.Default;
            m_isDead = true;
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

    public override void HitSend(GameObject hit)
    {
        m_HitObject = hit;
    }

    public override GameObject HitCall()
    {
        return m_HitObject;
    }
}
