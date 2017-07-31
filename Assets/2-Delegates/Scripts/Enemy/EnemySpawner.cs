using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform orc;
        public Transform troll;
        public int minAmount = 0, maxAmount = 20;
        public float spawnRate = 1;

        delegate void EnemyType(int amount);
        private List<EnemyType> types = new List<EnemyType>();

        void Start()
        {
            types.Add(SpawnOrc);
            types.Add(SpawnTroll);
        }

        void SpawnTroll(int amount)
        {
            Instantiate(troll);
        }

        void SpawnOrc(int amount)
        {
            Instantiate(orc);
        }

        void Update()
        {

        }
    }
}
