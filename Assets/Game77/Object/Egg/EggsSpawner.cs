using Assets.Game77.Tool;
using UnityEngine;

namespace Assets.Game77.Object.Egg
{
    public class EggsSpawner : MonoBehaviour
    {
        [SerializeField] private float timeSpawn = 3f;
        [SerializeField] private float incTime = 1.5f;
        [SerializeField] private Transform left;
        [SerializeField] private Transform right;
        private float xLeft;
        private float yLeft;
        private float xRight;
        private float timeCount;

        private void Start()
        {
            timeCount = timeSpawn;
            xLeft = left.position.x;
            yLeft = left.position.y;
            xRight = right.position.x;
        }

        private void FixedUpdate()
        {
            if (timeCount < 0)
            {
                PoolID id = PoolID.Egg1;
                int ran = Random.Range(1, 3);
                switch (ran)
                {
                    case 1 : id = PoolID.Egg1;
                        break;
                    case 2 : id = PoolID.Egg2;
                        break;
                }

                GameObject newEgg = ObjectPool.Instance.SpawnInPool(id);
                float ranX = Random.Range(xLeft, xRight);
                newEgg.transform.position = new Vector3(ranX, yLeft, 0f);

                timeCount = timeSpawn + Random.Range(-incTime, incTime);
            }
            else
            {
                timeCount -= Time.fixedDeltaTime;
            }
        }
    }
}