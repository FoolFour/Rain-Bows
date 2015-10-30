using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Slime;

    public int MonsterRest;
    public float SpawnerTime;
    public float SpawnerInterval;


    float comma = 0;
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (MonsterRest > 0 && SpawnerTime <= 0)
        {
            MonsterRest--;
            SpawnerTime = SpawnerInterval;
            Instantiate(Slime, transform.position, transform.rotation);
        }
        else
        {
            Clock(); 
        }
	}
    void Clock()
    {
        comma += 100 / 60;
        if (comma >= 100)
        {
            SpawnerTime--;
            comma = 0;
        }
    }
}
