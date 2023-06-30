using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMove _move;
        private PlayerDash _dash;

        private void Awake()
        {
            _move = GetComponent<PlayerMove>();
            _dash = GetComponent<PlayerDash>();
        }

        private void Update()
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _move.Move(dir);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dash.TryDash(dir);
            }
        }
    }
}