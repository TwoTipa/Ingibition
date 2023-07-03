using System;
using UnityEngine;

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState initState;
        public BaseState CurrentState { get; set; }

        private void Awake()
        {
            CurrentState = initState;
        }

        private void Start()
        {
            CurrentState.Enter(this);
        }

        private void Update()
        {
            CurrentState.Execute(this);
        }
    }
}