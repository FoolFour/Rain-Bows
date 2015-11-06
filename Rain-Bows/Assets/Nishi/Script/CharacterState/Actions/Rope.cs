﻿using UnityEngine;
using System.Collections;

public class Rope : ICharaState {

    private float m_Dir;
    private Parameter m_Prameter;

    public Rope(GameObject obj) : base(obj){ }

    public override void Enter()
    {
        m_Prameter = m_GameObject.GetComponent<Parameter>();
        m_Dir = m_Prameter.dir;

    }

    public override void Action()
    {
        
    }

    public override void Exit()
    {

    }

    public override void CollisionEnter(Collision2D other)
    {
        if (other.transform.tag == "Ivy")
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("time", 0.7f);
            hashtable.Add("easetype", iTween.EaseType.linear);
            hashtable.Add("path", other.transform.GetChild(0).GetComponent<CreatePath>().Path);
            iTween.MoveTo(m_GameObject, hashtable);
        }
        base.CollisionEnter(other);
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
