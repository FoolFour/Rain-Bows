using UnityEngine;
using System.Collections;

public class SoapSeed : MonoBehaviour {

    

    [SerializeField]
    private GameObject SoapFlour;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))//ディバック用
        {
            Bloom();
        }
    }

    public void Bloom()//咲く
    {
        GameObject WaterBubble = (GameObject)Instantiate(
                                       SoapFlour, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

