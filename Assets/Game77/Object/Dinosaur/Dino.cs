using System;
using System.Diagnostics;
using Assets.Game77.Object;
using Sirenix.Serialization;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Game77.Dinosaur
{
    public class Dino : Dinosaur
    {
        [SerializeField] private int health = 10;
        private bool leftMove;
        private bool rightMove;
        private float horizontalMove;
        private Rigidbody2D rb;
        private Animator animator;
        public Action<int> changeHealth;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            leftMove = false;
            rightMove = false;
        }
        
        private void FixedUpdate()
        {
            Move();
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        }

        protected override void Move()
        {
            if (leftMove)
            {
                horizontalMove = -runSpeed;
            }
            else if(rightMove)
            {
                horizontalMove = runSpeed;
            }
            else
            {
                horizontalMove = 0;
            }
        }

        public void DownLeft()
        {
            if(rightMove) return;
            leftMove = true;
            animator.SetBool("isMove", true);
            animator.SetBool("isLeft", true);
        }

        public void DownRight()
        {
            if (leftMove) return;
            rightMove = true;
            animator.SetBool("isMove", true);
            animator.SetBool("isLeft", false);
        }

        public void UpLeft()
        {
            if(!leftMove) return;
            leftMove = false;
            animator.SetBool("isMove", false);
        }

        public void UpRight()
        {
            if(!rightMove) return;
            rightMove = false;
            animator.SetBool("isMove", false);
        }
        
        public void Damaged(int i)
        {
            GameManager.Instance.GameOver();
        }
    }
}