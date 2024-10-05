using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;
using TMPro;

namespace LD56Project.GameAssembly
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField]
        private float maxDistance = 5f;

        [SerializeField]
        private TextMeshProUGUI tmpu;

        private Inventory inventory;

        IInteractible interactibleInCrosshair;

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

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
            ItemData selectedItem = inventory.GetSelected();

            if (selectedItem == null)
            {
                RaycastInteraction();
                return;
            }

            switch (selectedItem.Interaction)
            {
                case ItemData.InteractionType.Raycast:
                    RaycastInteraction();
                    break;

                case ItemData.InteractionType.Use:
                    ItemUser.UseItem(selectedItem);
                    break;
            }  
        }

        private void RaycastInteraction()
        {
            if (interactibleInCrosshair == null) return;
            interactibleInCrosshair.Interact();
        }
    }
}
