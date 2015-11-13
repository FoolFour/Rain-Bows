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
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        DestroyTime -= Time.deltaTime;

        if (time >= SoapBubbleInterval)
        {
            time = 0;
            //シャボン生成
            GameObject soapBubble = (GameObject)Instantiate(
                                        SoapBubble, transform.position + new Vector3(0,2,0), transform.rotation);
            soapBubble.transform.Rotate(0, 0, slope * 45);//シャボンの方向返還
        }
	}
}
