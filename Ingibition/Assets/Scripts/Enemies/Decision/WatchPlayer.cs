using FSM;
using UnityEngine;

namespace Enemies.Decision
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "AI/Decision/WatchDecision", order = 0)]
    public class WatchPlayer : FSM.Decision
    {
        public override bool Decied(BaseStateMachine machine)
        {
            return true;
        }
    }
}