using FSM;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies.Decision
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "AI/Decision/WatchDecision", order = 0)]
    public class WatchPlayer : FSM.Decision
    {
        public float detectionRadius = 1f; // Радиус обнаружения
        public LayerMask targetLayer;

        private Transform target;
        public override bool Decied(BaseStateMachine machine)
        {
            var position = machine.transform.position;
            Collider2D[] targets = Physics2D.OverlapCircleAll((Vector2)position, detectionRadius, targetLayer);
            Debug.Log("Ищу");
            if (targets.Length > 0)
            {
                Debug.Log("Нашёл " + targets[0].name);
                target = targets[0].transform;
                return true;
            }
            
            return false;
        }
        
    }
}