using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour
{

    [SerializeField]
    private float dir = 0.1f;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Transform GroundCheck;

    private Vector3 velocity = new Vector3(1f,0f,0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround())
        {
            transform.position += velocity * dir * speed;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            dir *= -1;
        }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision == null)
        {
            velocity = Vector3.zero;
        }
        
    }

    bool IsGround()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(GroundCheck.position,1, layerMask);
        return (hit != null);
    }

}
