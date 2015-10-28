using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour
{

    [SerializeField]
    private float dir;
    [SerializeField]
    private Transform GroundCheck;

    private Vector3 velocity = new Vector3(0.1f,0f,0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //velocity = velocity * dir * speed;
        if (IsGround())
        {
            gameObject.transform.position += velocity * dir;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            dir *= -1;
        }

    }

    bool IsGround()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Ground" });
        Collider2D hit = Physics2D.OverlapCircle(GroundCheck.position,1, layerMask);
        return (hit != null);
    }

}
