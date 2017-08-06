using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orc;
        public GameObject troll;
        public int minAmount = 0, maxAmount = 20;
        public float spawnRate = 1;

        private int num;

        delegate void EnemyType(int amount);
        private List<EnemyType> types = new List<EnemyType>();

        


        void Start()
        {
            types.Add(SpawnOrc);
            types.Add(SpawnTroll);
        }

        void SpawnTroll(int amount)
        {
            Instantiate(troll,target);
        }

        void SpawnOrc(int amount)
        {
            Instantiate(orc,target);
        }

        void Update()
        {
            num = Random.Range(minAmount, maxAmount);
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            types[num](1);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
