using UnityEngine;
using System.Collections;

public class BamBooTop : MonoBehaviour {

    private Vector3 defaultScale = Vector3.zero;
    private GameObject _BamBooMain;
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";

    [SerializeField]
    private bool Camerain = false; //カメラに映っているか

    public int UpDown = 0;

    void Start () 
    {
        defaultScale = transform.lossyScale;
        _BamBooMain = transform.root.gameObject;
        transform.root.gameObject.transform.Rotate(0, 0, UpDown);
    }
    
    void Update () 
    {


        Vector3 lossScale = transform.lossyScale;
        Vector3 localScale = transform.localScale;
        transform.localScale = new Vector3(
                localScale.x / lossScale.x * defaultScale.x,
                localScale.y / lossScale.y * defaultScale.y,
                localScale.z / lossScale.z * defaultScale.z);

        if (Camerain == true)
        {
            _BamBooMain.transform.localScale += new Vector3(0, 0.1f , 0);

            //float pos =(_BamBooMain.transform.localScale.y /2) - _BamBooMain.transform.position.y;
            //transform.position = new Vector3(transform.position.x, pos, transform.position.z);

        }

    }
    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            Camerain = true;
        }
    }
    private void OnBecameInvisible()
    {
        Camerain = false;
        //Destroy(gameObject);
    }
}