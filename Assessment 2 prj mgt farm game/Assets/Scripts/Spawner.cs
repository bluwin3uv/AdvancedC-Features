using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform target;
    public GameObject sanjayPrefab;
    public GameObject julzPrefab;
    public int minAmount = 0, maxAmount = 20;
    public float spawnRate = 1;
    public bool spawned = true;
    private int num;
    private int points;
    public Transform[] spawnpoints;
    delegate void ZombieType(int amount);
    private List<ZombieType> types = new List<ZombieType>();

	void Start ()
    {
        types.Add(SpawnSanjayZombie);
        types.Add(SpawnJulzZombie);
	}

    void SpawnSanjayZombie(int amount)
    {
        GameObject clone = Instantiate(sanjayPrefab, spawnpoints[points].transform.position, spawnpoints[points].transform.rotation);
        SanjayZombie sanjay = clone.GetComponent<SanjayZombie>();
        sanjay.SetTarget(target);
    }

    void SpawnJulzZombie(int amount)
    {
        GameObject clone = Instantiate(julzPrefab, spawnpoints[points].transform.position, spawnpoints[points].transform.rotation);
        JulzZombie julz = clone.GetComponent<JulzZombie>();
        julz.SetTarget(target); 
    }
	
	void Update ()
    {
        points = Random.Range(0, spawnpoints.Length);
        if(spawned)
        {
            StartCoroutine(Spawn());
            spawned = false;
        }
	}

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnRate);
        num = Random.Range(0, types.Count);
        types[num](1);
        spawned = true;
    }
}
