using Assets.Game77.Data;
using Assets.Game77.Dinosaur;
using Assets.Game77.Object;
using Assets.Game77.Tool;
using UnityEngine;

namespace Assets.Game77.asteroid
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private PoolID id;
        [SerializeField] private Transform orient;
        private AsteroidInfor asteroidInfor;
        private float speed = 1f;
        private float minScale;
        private float maxScale;
        private int damage;
        

        public void Setup(float hard, Vector2 spawnPos, Vector2 targetPos)
        {
            if (asteroidInfor == null)
            {
                asteroidInfor = GameDataManager.Instance.asteroidSo.FindAsteroidInforWithId(id);
            }
            speed = asteroidInfor.Speed * hard * Time.fixedDeltaTime;
            damage = asteroidInfor.Damage;
            minScale = asteroidInfor.MinRange;
            maxScale = asteroidInfor.MaxRange;
            float ran = Random.Range(minScale, maxScale);
            transform.position = spawnPos;
            transform.localScale = new Vector3(ran, ran, ran);
        }

        private void FixedUpdate()
        {
            transform.position += speed * orient.up;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            bool isDino = col.CompareTag("Dino");
            if( isDino || col.CompareTag("Ground"))
            {
                if (isDino)
                {
                    col.GetComponent<Dino>().Damaged(damage);
                }
                GameObject effect = ObjectPool.Instance.SpawnInPool(PoolID.DestroyEffect);
                effect.transform.position = transform.position;
                gameObject.SetActive(false);
            }

        }
    }
}