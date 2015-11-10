using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Slime;

    [SerializeField]
    private int Dir = 1;

    public int MonsterRest;
    public float SpawnerStartTime;
    public float SpawnerInterval;
    float comma = 0;
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (MonsterRest > 0 && SpawnerStartTime <= 0)
        {
            MonsterRest--;
            SpawnerStartTime = SpawnerInterval;
            Instantiate(Slime, transform.position, transform.rotation);
            Slime.GetComponent<Parameter>().dir = Dir;
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
            SpawnerStartTime--;
            comma = 0;
        }
    }
}
