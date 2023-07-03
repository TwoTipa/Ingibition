using System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerDash : MonoBehaviour
    {
        [SerializeField] private float dashPrice;
        public AnimationCurve jumpCurve; // Кривая анимации для плавного перемещения
        
        [SerializeField] private float dashDistance;
        [SerializeField] private float duration;
        private Rigidbody2D _rigidbody;
        private readonly CompositeDisposable _disposable = new();
        private Vector2 _initialPosition;
        private Vector2 _targetPosition;
        private float _jumpTimer;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public float TryDash(Vector2 dir)
        {
            if(_jumpTimer > 0) return 0;
            if (dir.magnitude == 0) dir = Vector2.down;
            _initialPosition = transform.position;
            _targetPosition = _initialPosition + dir * dashDistance;
            _jumpTimer = duration;
            Observable.EveryFixedUpdate().Subscribe(_ =>
            {
                float t = 1f - (_jumpTimer / duration); // Время анимации от 0 до 1
                float progress = jumpCurve.Evaluate(t); // Значение кривой анимации для данного времени

                // Плавно переместите Rigidbody2D к целевой позиции
                _rigidbody.MovePosition(Vector2.Lerp(_initialPosition, _targetPosition, progress));

                _jumpTimer -= Time.fixedDeltaTime;
                
                if (_jumpTimer <= 0)
                {
                    _disposable.Clear();
                }
            }).AddTo(_disposable);
            return dashPrice;
        }
    }
}