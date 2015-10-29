using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Slime;

    public int MonsterRest;
    public float SpawnerTime;
    public float SpawnerInterval;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {


        if ( MonsterRest > 0 && SpawnerTime<=0)
        {
            MonsterRest--;
            GameObject slime = (GameObject)Instantiate(Slime, transform.position, transform.rotation);
        }
	}
}
