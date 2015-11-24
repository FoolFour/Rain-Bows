using UnityEngine;
using System.Collections;

public class Water : ICharaState {

    public void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        gameObject.transform.SetParent(m_HitObject.transform, false);
    }

    public void Update()
    {
        if (gameObject.transform.parent == null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().WakeUp();
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
