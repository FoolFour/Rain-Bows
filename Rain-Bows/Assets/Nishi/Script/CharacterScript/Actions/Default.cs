using UnityEngine;
using System.Collections;

public class Default : ICharaState
{
    private Transform m_GroundCheck;

    public void Start()
    {
        m_GroundCheck = gameObject.transform.GetChild(0);
    }

    public void Update()
    {
        if (IsGround())
        {
            gameObject.transform.position += new Vector3(0.1f, 0.0f, 0.0f) * m_dir;
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
        if(collision.gameObject.tag == "Wall")
        {
            m_dir *= -1;
        }
        if (collision.gameObject.tag == "Ivy")
        {
            m_next = StateName.Rope;
            m_isDead = true;
        }
        if (collision.gameObject.tag == "Bubble")
        {
            m_next = StateName.Bubble;
            m_isDead = true;
        }
        if (collision.gameObject.tag == "Water")
        {
            m_next = StateName.Water;
            m_isDead = true;
        }
    }

    bool IsGround()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(m_GroundCheck.position, 1, layerMask);
        return (hit != null);
    }
}
