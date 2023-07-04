using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private Vector3 damagePosition;
    [SerializeField] private float damageRadius;
    [SerializeField] private LayerMask damageLayer;
    [SerializeField] private float zoneLifeTime;
    private float damageCount;
    private readonly CompositeDisposable _disposable = new();

    public void Damage(float count)
    {
        damageCount = count;

        _disposable.Clear();
        List<Collider2D> hittedEnemies = new List<Collider2D>();
        float time = zoneLifeTime;
        Observable.EveryFixedUpdate()
            .Subscribe(_ => {
                if (time <= 0)
                {
                    _disposable.Clear();
                }
                time -= Time.fixedDeltaTime;

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position+damagePosition, damageRadius, damageLayer);

                foreach (var hit in hitEnemies)
                {
                    if (!hittedEnemies.Contains(hit))
                    {
                        Debug.Log($"{hit.name} hitted.");
                        hittedEnemies.Add(hit);
                    }
                }

        }).AddTo(_disposable);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Damage(10);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position+damagePosition, damageRadius);
    }
}
