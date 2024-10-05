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
        private AnimatedText animatedText;

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
            animatedText = ServiceLocator.ForSceneOf(this).Get<AnimatedText>();
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
                interactibleInCrosshair.TryInteract(out string message);
                animatedText.Animate(message);
            }
            else
            {
                animatedText.Animate(UseInteraction());
            }
        }

        private string UseInteraction()
        {
            ItemData selectedItem = inventory.GetSelected();
            if (selectedItem == null) return "I am not holding an item right now";
            if (!selectedItem.CanBeUsed) return "I probably need to find an object to use this";

            if (selectedItem.ConsumedUponUse) inventory.RemoveSelected();
            OnItemUsed?.Invoke(selectedItem.Usage);
            return null;
        }
    }
}
