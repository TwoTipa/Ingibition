using UnityEngine;

namespace FSM
{
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine machine);
        public abstract void Execute(BaseStateMachine machine);
        public abstract void Exit(BaseStateMachine machine);
    }
}