using UnityEngine;
using System.Collections;

public class SoapBubble : MonoBehaviour {

    [SerializeField]
    private float Speed;


	// Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        //飛んでいく
        transform.localPosition +=
           transform.right * Speed * 0.01f;
     
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (transform.childCount == 0)
            {
                col.transform.parent = transform;
                col.transform.localPosition = Vector2.zero;
                return;
            }
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
