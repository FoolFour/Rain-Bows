using UnityEngine;
using System.Collections;

public class Default : ICharaState {

    private float m_Dir;
    private Transform m_GroundCheck;
    private Parameter m_Prameter;

    public Default(GameObject obj) : base(obj){ }

    public override void Enter()
    {
        m_Prameter = m_GameObject.GetComponent<Parameter>();
        m_Dir = m_Prameter.dir;
        m_GroundCheck = m_Prameter.GroundCheck;

    }

    public override void Action()
    {
        if (IsGround())
        {
            m_GameObject.transform.position += new Vector3(0.1f, 0f, 0f) * m_Dir;
        }
    }

    public override void Exit()
    {

    }

    public override void CollisionEnter(Collision2D other)
    {
        if(other.collider.tag == "Wall")
        {
            m_Dir *= -1;
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

    bool IsGround()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(m_GroundCheck.position, 1, layerMask);
        return (hit != null);
    }
}
