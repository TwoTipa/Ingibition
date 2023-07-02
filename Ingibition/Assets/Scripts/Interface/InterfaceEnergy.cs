using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceEnergy : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private PlayerEnergy playerEnergy;

    private void Start()
    {
        playerEnergy.onEnergyChanged += SetProgress;
    }
    private void SetProgress(float cur, float max)
    {
        energyBar.fillAmount = cur/max;
    }
}
