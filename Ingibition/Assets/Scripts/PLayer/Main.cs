using System;
using UnityEngine;

namespace PLayer
{
    [RequireComponent(typeof(Move))]
    public class Main : MonoBehaviour
    {
        private Move _move;

        private void Awake()
        {
            _move = GetComponent<Move>();
        }
    }
}