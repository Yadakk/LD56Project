using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;
using TMPro;

namespace LD56Project.GameAssembly
{
    public class PlayerInteractor : MonoBehaviour
    {
        //Serialized
        [SerializeField]
        private float maxDistance = 5f;

        [SerializeField]
        private TextMeshProUGUI tmpu;

        //ServiceLocatorGet
        private Inventory inventory;

        //Internal
        private IInteractible interactibleInCrosshair;

        //Events
        public event System.Action<ItemData.UseType> OnItemUsed;

        private void Awake()
        {
            ServiceLocator.ForSceneOf(this).Register(this);
        }

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

            if (interactibleInCrosshair != null)
            {
                interactibleInCrosshair.TryInteract();
            }
            else
            {
                UseInteraction();
            }
        }

        private bool UseInteraction()
        {
            ItemData selectedItem = inventory.GetSelected();
            if (selectedItem == null) return false;

            if (selectedItem.ConsumedUponUse) inventory.RemoveSelected();
            OnItemUsed?.Invoke(selectedItem.Usage);
            return true;
        }
    }
}
