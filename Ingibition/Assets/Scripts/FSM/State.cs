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
            Debug.Log("Вошёл в " + machine.CurrentState);
            foreach (var activity in activities)
            {
                activity.Enter(machine);
            }
        }

        public override void Execute(BaseStateMachine machine)
        {
            base.Execute(machine);
            Debug.Log("Обновляю " + machine.CurrentState);
            foreach (var activity in activities)
            {
                activity.Execute(machine);
            }
            foreach (var transition in transitions)
            {
                transition.Execute(machine);
            }
        }

        public override void Exit(BaseStateMachine machine)
        {
            base.Exit(machine);
            Debug.Log("Вышел из " + machine.CurrentState);
            foreach (var activity in activities)
            {
                activity.Exit(machine);
            }
        }
    }
}