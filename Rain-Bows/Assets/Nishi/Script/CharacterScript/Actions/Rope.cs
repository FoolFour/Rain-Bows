using UnityEngine;
using System.Collections;

public class Rope : ICharaState {

    public void Start()
    {
        GameObject gameObj = HitObject.transform.parent.FindChild("DotDrawer").gameObject;
        Vector3[] path = gameObj.GetComponent<CreatePath>().Path;
        Hashtable hash = new Hashtable();
        hash.Add("time", 5.0f);
        hash.Add("easeType", iTween.EaseType.linear);
        hash.Add("path", path);
        iTween.MoveTo(gameObject, hash);
    }

    public void Update()
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
