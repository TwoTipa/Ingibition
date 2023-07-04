using FSM;
using UnityEngine;

namespace Enemies.Activities
{
    [CreateAssetMenu(fileName = "ChaseActivity", menuName = "AI/Activity/ChaseActivity", order = 0)]
    public class ChaseActivity : Activity
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private string targetTag = "Player";
        private Transform _target;
        private Transform _transform;
        private Rigidbody2D _rigidBody;
        
        public override void Enter(BaseStateMachine machine)
        {
            _target = GameObject.FindWithTag(targetTag).transform;
            _rigidBody = machine.GetComponent<Rigidbody2D>();
            _transform = machine.GetComponent<Transform>();
        }

        public override void Execute(BaseStateMachine machine)
        {
            //_transform.LookAt(_target);
            Vector2 dir = (_target.transform.position - machine.transform.position).normalized;
            _rigidBody.velocity = dir * (speed * Time.deltaTime);
        }

        public override void Exit(BaseStateMachine machine)
        {
            throw new System.NotImplementedException();
        }
    }
}