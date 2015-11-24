using UnityEngine;
using System.Collections;

public class Water : ICharaState {

    public void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.transform.SetParent(m_HitObject.transform, false);
    }

    public void Update()
    {
        if (gameObject.transform.parent == null)
        {
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
