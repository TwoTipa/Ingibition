using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class PlayerMove : MonoBehaviour, IWalkable
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 dir)
        {
            _rigidbody.velocity = dir * (speed * Time.fixedDeltaTime);
        }
    }
}
