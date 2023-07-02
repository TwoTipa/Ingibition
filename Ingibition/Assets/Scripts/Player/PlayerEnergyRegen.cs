using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlayerEnergy))]
public class PlayerEnergyRegen : MonoBehaviour
{
    [SerializeField] private float regenCountOnTime;
    [SerializeField] private float regenTime;
    private PlayerEnergy _playerEnergy;
    private readonly CompositeDisposable _disposable = new();
    private void Start()
    {
        _playerEnergy=GetComponent<PlayerEnergy>();
        RegenEnergy();
    }

    public void RegenEnergy()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(regenTime))
        .Repeat()
        .Subscribe(_ => {
            _playerEnergy.AddEnergy(regenCountOnTime);
        }).AddTo(_disposable);
    }
}
