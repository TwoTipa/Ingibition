using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class UiEnergy : MonoBehaviour
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
}
