using UnityEngine;
using System.Collections;

public class Bubble : ICharaState {

    public Bubble(GameObject obj) : base(obj){ }

    public override void Enter()
    {

    }

    public override void Action()
    {
    }

    public override void Exit()
    {

    }

    public override void CollisionEnter(Collision2D other)
    {
        base.CollisionEnter(other);
    }

    public override void TriggerEnter(Collider2D other)
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
