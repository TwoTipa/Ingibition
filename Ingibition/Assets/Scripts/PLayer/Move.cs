using System;
using UnityEngine;

namespace PLayer
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class Move : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 _dir;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _dir = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void FixedUpdate()
        {
            //_rigidbody.MovePosition((Vector2)transform.position+(_dir.normalized * speed));
            _rigidbody.velocity = _dir * (speed * Time.fixedDeltaTime);
        }
    }
}
