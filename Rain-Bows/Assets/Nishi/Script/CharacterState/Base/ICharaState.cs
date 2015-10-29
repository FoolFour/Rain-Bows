using UnityEngine;
using System.Collections;

public abstract class ICharaState
{
    protected GameObject m_GameObject;
    protected bool m_isDead;
    protected StateName m_next;


    public ICharaState(GameObject gameobj)
    {
        this.m_GameObject = gameobj;
    }

    public abstract void Enter();
    public abstract void Action();
    public abstract void Exit();
    public virtual void CollisionEnter(Collision2D other) { }
    public virtual void CollisionStay(Collision2D other) { }
    public virtual void CollisionExit(Collision2D other) { }
    public abstract bool IsDead();
    public abstract StateName Next();


}
