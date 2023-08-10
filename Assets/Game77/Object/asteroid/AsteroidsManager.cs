using System.Collections;
using Assets.Game77.Object;
using Assets.Game77.Tool;
using UnityEngine;

namespace Assets.Game77.asteroid
{
    public class AsteroidsManager : MonoBehaviour
    {
        [SerializeField] private float timeSpawnWave;
        [SerializeField] private float incHard;
        [SerializeField] private float incHardTime;

        [SerializeField] private Transform leftUpTransform;
        [SerializeField] private Transform leftDownTransform;
        [SerializeField] private Transform rightUpTransform;
        [SerializeField] private Transform rightDownTransform;
        
        private Vector2 leftUp;
        private Vector2 rightUp;
        private Vector2 leftDown;
        private Vector2 rightDown;
        
        private float countTime = 0;
        private float timeWave = 0.5f;
        private float timeBetween = 0.25f;
        private float timeToSpawn = 0;
        private int asteroidsAmount = 1;
        private int countAsteroid;
        private float hard = 1f;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.Instance;
            StartCoroutine(IncreaseHard());
            leftDown = leftDownTransform.position;
            leftUp = leftUpTransform.position;
            rightDown = rightDownTransform.position;
            rightUp = rightUpTransform.position;
        }

        private void FixedUpdate()
        {
            if (timeWave < 0)
            {
                SpawnAsteroids();
                //Debug.Log("hello");
                return;
            }
            timeWave -= Time.fixedDeltaTime;
        }

        private IEnumerator IncreaseHard()
        {
            while (gameManager.DinoAlive)
            {
                yield return new WaitForSeconds(incHardTime);
                hard += incHard;
                if (countTime > 5)
                {
                    asteroidsAmount = 2;
                } else if (countTime > 15)
                {
                    asteroidsAmount = 3;
                }else if (countTime > 35)
                {
                    asteroidsAmount = 4;
                }else if (countTime > 50)
                {
                    asteroidsAmount = 5;
                }
            }
            
        }

        private void SpawnAsteroids()
        {
            if (countAsteroid >= asteroidsAmount)
            {
                countAsteroid = 0;
                timeWave = timeSpawnWave / hard;
                return;
            }
            if(timeToSpawn > 0)
            {
                timeToSpawn -= Time.fixedDeltaTime;
                return;
            }

            timeToSpawn = Random.Range(0f, timeBetween);
            PoolID id = PoolID.Asteroid1;
            int ran = Random.Range(1, 4);
            switch (ran)
            {
                case 1 : id = PoolID.Asteroid1;
                    break;
                case 2 : id = PoolID.Asteroid2;
                    break;
                case 3 : id = PoolID.Asteroid3;
                    break;
            }

            float ranX = Random.Range(leftUp.x, rightUp.x);
            Vector2 ranSpawn = new Vector2(ranX, leftUp.y);
            ranX = Random.Range(leftDown.x, rightDown.x);
            Vector2 ranTarget = new Vector2(ranX, leftDown.x);
            Asteroid asteroid = ObjectPool.Instance.SpawnInPool(id).GetComponent<Asteroid>();
            asteroid.Setup(hard, ranSpawn, ranTarget);
            countAsteroid++;
            
            
        }
        
    }
}