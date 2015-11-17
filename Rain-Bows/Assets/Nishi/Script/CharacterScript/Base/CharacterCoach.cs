using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterCoach : MonoBehaviour {

    private Dictionary<StateName, System.Type> m_states = new Dictionary<StateName, System.Type>();
    private ICharaState m_CurrentState;

	// Use this for initialization
	void Start () {
        m_states.Add(StateName.Default,typeof(Default));
        m_states.Add(StateName.Rope, typeof(Rope));
        m_states.Add(StateName.Bubble, typeof(Bubble));
        m_states.Add(StateName.Water, typeof(Water));
        m_CurrentState = (ICharaState)gameObject.AddComponent(m_states[StateName.Default]);
	
	}
	
	// Update is called once per frame
	void Update () {

        StateChange();
	
	}

    void StateChange()
    {
        if(m_CurrentState.IsDead())
        {
            GameObject temp = m_CurrentState.HitCall();
            Destroy(m_CurrentState);
            m_CurrentState = (ICharaState)gameObject.AddComponent(m_states[m_CurrentState.Next()]);
            m_CurrentState.HitSend(temp);
        }
    }
}
