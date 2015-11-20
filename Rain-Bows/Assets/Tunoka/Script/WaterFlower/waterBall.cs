using UnityEngine;
using System.Collections;

public class waterBall : MonoBehaviour {


    [SerializeField]
    private float walkSpeed;
    public Vector3 RotPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //飛んでいく
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + RotPos, walkSpeed * 0.01f);
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            return;
        }

        //子に何かがいたら吐き出す
        if (transform.childCount != 0)
        {
            transform.DetachChildren();
        }
        Destroy(gameObject);
    }
}
