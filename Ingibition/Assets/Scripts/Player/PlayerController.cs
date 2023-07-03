using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private KeyCode dashKey;
        [SerializeField] private KeyCode useKey;

        private PlayerEnergy _energy;
        private PlayerInteraction _interaction;
        private PlayerMove _move;
        private PlayerDash _dash;

        private void Awake()
        {
            _move = GetComponent<PlayerMove>();
            _dash = GetComponent<PlayerDash>();
            _energy = GetComponent<PlayerEnergy>();
            _interaction = GetComponent<PlayerInteraction>();
        }

        private void Update()
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _move.Move(dir);
            if (Input.GetKeyDown(dashKey))
            {
                if (_energy.ConsumeEnergy(_dash.TryDash(dir.normalized)))
                {
                    //успех
                }
            }
            if (Input.GetKeyDown(useKey))
            {
                _interaction.TryUse();
            }
        }
    }
}