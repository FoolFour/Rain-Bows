using UnityEngine;
using System.Collections;

public class WaterSeed : MonoBehaviour {

    [SerializeField]
    private Vector3 rotPos = Vector3.zero;

    [SerializeField]
    private GameObject Water;

	// Update is called once per frame
	void Update () 
    {
        PosSet();

        if (Input.GetKey(KeyCode.Space))//ディバック用
        {
            Bloom();
        }
	}

    void PosSet()
    {
        if (rotPos != Vector3.zero)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rotPos = Input.mousePosition;
        }

    }
    public void Bloom()//咲く
    {
        GameObject WaterBubble = (GameObject)Instantiate(
                                       Water, transform.position, transform.rotation);
        WaterBubble.GetComponent<WaterFlower>().rotPos = rotPos;
        Destroy(gameObject);
    }
}
