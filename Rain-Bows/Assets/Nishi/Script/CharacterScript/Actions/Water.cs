using UnityEngine;
using System.Collections;

public class Water : ICharaState {

    public void Start()
    {

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
}
