﻿using UnityEngine;
using System.Collections;
using System;

public class Default : ICharaState
{
    private Transform m_GroundCheck;
    private Transform m_Ground;

    public void Start()
    {
        m_GroundCheck = gameObject.transform.GetChild(0);
        m_Ground = gameObject.transform.GetChild(1);
    }

    public void Update()
    {
        if (IsGround())
        {
            gameObject.transform.position += new Vector3(0.1f, 0.0f, 0.0f) * m_dir;
        }

        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(m_GroundCheck.position, 1, layerMask);
        if(hit != null)
        {
            gameObject.transform.rotation = hit.gameObject.transform.rotation;
        }

        if(transform.parent != null)
        {
            if (transform.parent.tag == "Bubble")
            {
                HitSend(transform.parent.gameObject);
                m_next = StateName.Bubble;
                m_isDead = true;
            }
            if (transform.parent.tag == "Water")
            {
                HitSend(transform.parent.gameObject);
                m_next = StateName.Water;
                m_isDead = true;
            }
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            m_dir *= -1;
        }

        //if (collision.gameObject.tag == "Bubble")
        //{
        //    HitSend(collision.gameObject);
        //    m_next = StateName.Bubble;
        //    m_isDead = true;
        //}
        //if (collision.gameObject.tag == "Water")
        //{
        //    HitSend(collision.gameObject);
        //    m_next = StateName.Water;
        //    m_isDead = true;
        //}
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ivy")
        {
            HitSend(other.gameObject);
            m_next = StateName.Rope;
            m_isDead = true;
        }
        //if (other.tag == "Bubble")
        //{
        //    HitSend(other.gameObject);
        //    m_next = StateName.Bubble;
        //    m_isDead = true;
        //}
        //if (other.gameObject.tag == "Water")
        //{
        //    HitSend(other.gameObject);
        //    m_next = StateName.Water;
        //    m_isDead = true;
        //}
    }

    bool IsGround()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(m_GroundCheck.position, 1, layerMask);
        return (hit != null);
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
