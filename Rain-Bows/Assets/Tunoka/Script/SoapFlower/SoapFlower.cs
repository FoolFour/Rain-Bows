using UnityEngine;
using System.Collections;

public class SoapFlower : MonoBehaviour {


    public int slope;
    [SerializeField]
    private GameObject SoapBubble;//出てくる泡
    [SerializeField]
    private float SoapBubbleInterval;//出てくる感覚
    [SerializeField]
    private float DestroyTime;//死ぬ時間


    float time;

	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        DestroyTime -= Time.deltaTime;//枯れるまでの時間

        if (DestroyTime <= 0){ 
            Wither();//枯らせる
        }
        if (time >= SoapBubbleInterval)
        {
            time = 0;
            //シャボン生成
            GameObject soapBubble = (GameObject)Instantiate(
                                        SoapBubble, transform.position + new Vector3(0,2,0), transform.rotation);
            soapBubble.transform.Rotate(0, 0, slope * 45);//シャボンの方向返還
        }
	}

    void Wither()
    {
        //種に戻す
        //
        Destroy(transform.root.gameObject);
    }
}
