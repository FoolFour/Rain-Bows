using UnityEngine;
using System.Collections;

public abstract class ICharaState : MonoBehaviour
{
    protected bool m_isDead;
    protected StateName m_next;
    protected int m_dir = 1;

    public abstract bool IsDead();
    public abstract StateName Next();


}
