using UnityEngine;

namespace FSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decied(BaseStateMachine machine);
        
        
    }
}