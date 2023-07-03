using FSM;
using UnityEngine;

namespace Enemies.Activities
{
    [CreateAssetMenu(fileName = "CombatActivity", menuName = "AI/CombatActivity", order = 0)]
    public class CombatActivity : Activity
    {
        public float dmg;
        
        public override void Enter(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }

        public override void Exit(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }
    }
}