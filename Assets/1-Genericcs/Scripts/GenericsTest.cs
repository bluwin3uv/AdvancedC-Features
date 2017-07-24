
using UnityEngine;

namespace Generics
{
    public class GenericsTest : MonoBehaviour
    {
        public float spawnRadius = 50f;
        public GameObject prefab;
        public int spawnAmount = 20;
        public LottyList<GameObject> gameObjects = new LottyList<GameObject>();
        void Start()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject clone = Instantiate(prefab);
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                clone.transform.position = randomPos;
                gameObjects.Add(clone);
            }
        }

        void Update()
        {

        }
    }
}
