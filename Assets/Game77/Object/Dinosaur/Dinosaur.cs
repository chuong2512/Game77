using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Game77.Dinosaur
{
    public abstract class Dinosaur : MonoBehaviour
    {
        [SerializeField] protected float runSpeed = 10;
        protected abstract void Move();
    }
}