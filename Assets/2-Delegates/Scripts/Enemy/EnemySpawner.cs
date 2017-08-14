using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Delegate
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orcPrefab;
        public GameObject trollPrefab;
        public int minAmount = 0, maxAmount = 20;
        public float spawnRate = 1;
        public bool spawned = true;
        private int num;
        public Transform spawnPoint;
        delegate void EnemyType(int amount);
        private List<EnemyType> types = new List<EnemyType>();

        


        void Start()
        {
            types.Add(SpawnOrc);
            types.Add(SpawnTroll);
        }

        void SpawnTroll(int amount)
        {
            GameObject clone = Instantiate(trollPrefab, spawnPoint.transform.position,spawnPoint.transform.rotation);
            Troll troll = clone.GetComponent<Troll>();
            troll.SetTarget(target);
        }

        void SpawnOrc(int amount)
        {
            GameObject clone = Instantiate(orcPrefab,spawnPoint.transform.position, spawnPoint.transform.rotation);
            Orc orc = clone.GetComponent<Orc>();
            orc.SetTarget(target);

        }

        void Update()
        {
            if (spawned)
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
}
