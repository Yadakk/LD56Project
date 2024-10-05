using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace LD56Project.GameAssembly
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField]
        private float maxDistance = 5f;

        [SerializeField]
        private TextMeshProUGUI tmpu;

        IInteractible interactibleInCrosshair;

        private void Update()
        {
            if (!MainRaycaster.TryRaycast(out IInteractible interactibe, maxDistance))
            {
                tmpu.text = null;
                interactibleInCrosshair = null;
                return;
            }

            tmpu.text = interactibe.Text;
            interactibleInCrosshair = interactibe;
        }

        public void OnInteract()
        {
            if (interactibleInCrosshair == null) return;
            interactibleInCrosshair.Interact();
        }
    }
}
