using UnityEngine;

namespace FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void Enter(BaseStateMachine machine)
        {
            Debug.Log($"{this} Enter");
        }
        public virtual void Execute(BaseStateMachine machine)
        {
            
        }
        public virtual void Exit(BaseStateMachine machine)
        {
            Debug.Log($"{this} Exit");
        }
    }
}