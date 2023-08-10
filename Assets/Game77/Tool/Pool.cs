using UnityEngine;

namespace Assets.Game77.Tool
{
    public enum PoolID
    {
        Egg1, Egg2, Asteroid1, Asteroid2, Asteroid3, DestroyEffect
    }
    [System.Serializable]
    public class Pool
    {
        [SerializeField] private PoolID id; 
        public GameObject prefab;

        public PoolID ID => id;
    }
}