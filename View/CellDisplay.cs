using TMPro;
using UnityEngine;

namespace Scripts.Systems.GridMovement.Display
{
    public class CellDisplay : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _stepText;

        [field: SerializeField] public GameObject SelectedSkin { get; set; }
        [field: SerializeField] public GameObject WayTraceSkin { get; set; }

        protected virtual void OnDisable() {
            _stepText.text = string.Empty;
            _stepText.gameObject.SetActive(false);
        }

        public virtual void SetRemainingStepsText(int remainingStepsCount) {
            if (remainingStepsCount == 1) {
                _stepText.text = string.Empty;
                return;
            }

            _stepText.gameObject.SetActive(true);
            _stepText.text = (remainingStepsCount - 1).ToString();
        }
    }
}