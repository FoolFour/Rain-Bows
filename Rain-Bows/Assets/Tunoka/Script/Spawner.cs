using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Slime;

    [SerializeField]
    private int Dir = 1;//プレイヤーの進む初期方向

    public int MonsterRest;//出る数
    public float SpawnerStartTime;//最初に出る数
    public float SpawnerInterval;//一回出てからのInterval
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
            GameObject slime = (GameObject)Instantiate(
                                        Slime, transform.position, transform.rotation);
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
