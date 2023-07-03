using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public delegate void OnEnergyChanged(float cur, float max);
    public OnEnergyChanged onEnergyChanged;

    [SerializeField] private float currentEnergy;
    [SerializeField] private float maxEnergy;

    public bool AddEnergy(float count)
    {
        currentEnergy += count;
        if (currentEnergy>maxEnergy)
        {
            currentEnergy = maxEnergy;
            onEnergyChanged.Invoke(currentEnergy, maxEnergy);
            return false;
        }
        else
        {
            onEnergyChanged.Invoke(currentEnergy, maxEnergy);
            return true;
        }
    }

    public bool ConsumeEnergy(float count)
    {
        if (currentEnergy - count < 0)
        {
            return false;
        }
        else
        {
            currentEnergy-= count;
            onEnergyChanged.Invoke(currentEnergy, maxEnergy);
            return true;
        }
    }

    public void AddMaxEnergy(float count)
    {
        maxEnergy += count;
        onEnergyChanged.Invoke(currentEnergy, maxEnergy);
    }

    public void SetMaxEnergy(float count)
    {
        maxEnergy = count;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        onEnergyChanged.Invoke(currentEnergy, maxEnergy);
    }

    public void SetEnergy(float count)
    {
        currentEnergy = count;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        onEnergyChanged.Invoke(currentEnergy, maxEnergy);
    }
}
