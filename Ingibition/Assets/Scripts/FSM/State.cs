using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(fileName = "State", menuName = "FSM/State", order = 0)]
    public sealed class State : BaseState
    {
        public List<Activity> activities = new();
        public List<Transition> transitions = new();

        public override void Enter(BaseStateMachine machine)
        {
            base.Enter(machine);
            foreach (var activity in activities)
            {
                activity.Enter(machine);
            }
        }

        public override void Execute(BaseStateMachine machine)
        {
            base.Execute(machine);
            foreach (var activity in activities)
            {
                activity.Execute(machine);
            }
        }

        public override void Exit(BaseStateMachine machine)
        {
            base.Exit(machine);
            foreach (var activity in activities)
            {
                activity.Exit(machine);
            }
        }
    }
}