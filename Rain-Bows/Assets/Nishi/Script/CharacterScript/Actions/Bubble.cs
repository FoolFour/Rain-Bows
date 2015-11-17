using UnityEngine;
using System.Collections;

public class Bubble : ICharaState {

    public void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        gameObject.transform.SetParent(m_HitObject.transform,false);
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
}
