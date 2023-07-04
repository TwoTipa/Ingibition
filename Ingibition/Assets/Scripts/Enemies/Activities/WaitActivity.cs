using FSM;
using UnityEngine;

namespace Enemies.Activities
{
    [CreateAssetMenu(fileName = "WaitActivity", menuName = "AI/Activity/WaitActivity")]
    public class WaitActivity : Activity
    {
        public override void Enter(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(BaseStateMachine machine)
        {
            
        }

        public override void Exit(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }
    }
    
}