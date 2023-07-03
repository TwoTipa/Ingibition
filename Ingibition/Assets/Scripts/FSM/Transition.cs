using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "AI/Transition", order = 0)]
    public sealed class Transition : ScriptableObject
    {
        public Decision  decision;
        public BaseState trueState;
        public BaseState falseState;
 
        public void Execute(BaseStateMachine stateMachine)
        {
            //...
        }
    }
}