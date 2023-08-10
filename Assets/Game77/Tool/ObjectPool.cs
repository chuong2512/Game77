using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game77.Tool
{
    [DefaultExecutionOrder(-999)]
    public class ObjectPool : MonoBehaviour
    {

        // tạo 1 danh sách có key là Pool.ID và list chứa các Pool.Prefabs
        private Dictionary<PoolID, List<GameObject>> PoolDictionary;
        [SerializeField] private List<Pool> pools;

        public static ObjectPool Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            PoolDictionary = new Dictionary<PoolID, List<GameObject>>();
            for (int i = 0; i < pools.Count; i++)
            {
                PoolDictionary.Add(pools[i].ID, new List<GameObject>());
            }
        }

        private Pool GetPoolWithID(PoolID getID)
        {
            Pool getPool = new Pool();
            for (int i = 0; i < pools.Count; i++)
            {
                if (getID == pools[i].ID)
                {
                    getPool = pools[i];
                }
            }

            return getPool;
        }

        public GameObject SpawnInPool(PoolID getID)
        {
            GameObject spawnObject = null;
            for (int i = 0; i < PoolDictionary[getID].Count; i++)
            {
                if (!PoolDictionary[getID][i].gameObject.activeSelf)
                {
                    spawnObject = PoolDictionary[getID][i];
                    break;
                }
            }

            if (spawnObject == null)
            {
                spawnObject = Instantiate(GetPoolWithID(getID).prefab, transform);
                PoolDictionary[getID].Add(spawnObject);
            }
            spawnObject.SetActive(true);
            return spawnObject;
        }

        public void RestartPool()
        {
            for (int i = 0; i < pools.Count; i++)
            {
                PoolDictionary.Clear();
            }
        }
    }
    
}