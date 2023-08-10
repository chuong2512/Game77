using System;
using System.Collections.Generic;
using Assets.Game77.Tool;
using UnityEngine;

namespace Assets.Game77.Data
{
    [CreateAssetMenu(fileName = "Data Asteroid", menuName = "ScriptableObjects/AsteroidSO", order = 1)]
    public class AsteroidSO : ScriptableObject
    {
        [SerializeField] private AsteroidInfor[] asteroidInfors;

        public AsteroidInfor FindAsteroidInforWithId(PoolID id)
        {
            int n = asteroidInfors.Length;
            for (int i = 0; i < n; i++)
            {
                if (asteroidInfors[i].Id == id)
                {
                    return asteroidInfors[i];
                }
            }

            return null;
        }
    }

    [Serializable]
    public class AsteroidInfor
    {
        [SerializeField] private PoolID id;
        [SerializeField] private float speed = 6;
        [SerializeField] private float minRange = 0.05f;
        [SerializeField] private float maxRange = 0.06f;
        [SerializeField] private int damage = 10;

        public int Damage => damage;

        public PoolID Id => id;

        public float Speed => speed;

        public float MinRange => minRange;

        public float MaxRange => maxRange;
    }
}