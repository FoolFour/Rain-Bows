using UnityEngine;
using System.Collections;

public class WaterFlower : MonoBehaviour {


    private Vector3 rotPos = new Vector3 (5,5,0);

    [SerializeField]
    private GameObject Water;
    [SerializeField]
    private GameObject PlayerBullet;

    float time;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
       
        //プレイヤーが入っていたらカウント開始
        if (PlayerBullet != null)
        {
            time += Time.deltaTime;
        }

        //時間がたったら発射する
        if (time >= 3)
        {
            GameObject soapBubble = (GameObject)Instantiate(
                                        Water, transform.position, transform.rotation);
            
            PlayerBullet.transform.parent = soapBubble.transform;
            soapBubble.GetComponent<waterBall>().RotPos = rotPos;
            PlayerBullet.transform.localPosition = Vector3.zero;

            Wither();//枯らせる
        }
	}
    public void PlayerBulletSet(GameObject Player)
    {
        PlayerBullet = Player;
    }

    void Wither()
    {
        //種に戻す
        //
        Destroy(transform.root.gameObject);
    }

    public void LookOn(Vector3 pos)//種の時に飛ぶ方向を持ってくる
    {
        rotPos = pos;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && transform.childCount == 2)
        {

            col.transform.parent = transform;
            col.transform.localPosition = Vector3.zero;
            PlayerBullet = col.transform.gameObject;
        }
    }
}
