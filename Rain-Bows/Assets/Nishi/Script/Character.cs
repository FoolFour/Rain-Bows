using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    private CharaStateMachine m_stateMachine;

    public void Awake()
    {
        m_stateMachine = new CharaStateMachine();
    }

    // Use this for initialization
    void Start()
    {
        m_stateMachine.AddState(StateName.Default, new Default(gameObject));
        m_stateMachine.Change(StateName.Default);

    }

    // Update is called once per frame
    void Update()
    {
        m_stateMachine.Action();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        m_stateMachine.CollisionEnter(collision);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        m_stateMachine.CollisionStay(collision);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        m_stateMachine.CollisionExit(collision);
    }
}
