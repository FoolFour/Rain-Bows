using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharaStateMachine{

    private Dictionary<StateName, ICharaState> m_States = new Dictionary<StateName, ICharaState>();
    private ICharaState m_Current = null;

    public void AddState(StateName name, ICharaState state)
    {
        m_States.Add(name, state);
    }

    public void Change(StateName name)
    {
        if(m_Current != null)
        {
            m_Current.Exit();
        }
        m_Current = m_States[name];
        m_Current.Enter();
    }

    public void Action()
    {
        if (m_Current != null)
        {
            m_Current.Action();
            if (m_Current.IsDead())
            {
                Change(m_Current.Next());
            }
        }
    }

    public void CollisionEnter(Collision2D other)
    {
        m_Current.CollisionEnter(other);
    }
    public void CollisionStay(Collision2D other)
    {
        m_Current.CollisionStay(other);
    }
    public void CollisionExit(Collision2D other)
    {
        m_Current.CollisionExit(other);
    }

    public ICharaState GetCurrent()
    {
        return m_Current;
    }

}
