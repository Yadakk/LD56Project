using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class NeedItemToInteract : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData RequiredItem;

        private Inventory inventory;

        [SerializeField]
        private UnityEvent OnInteract;

        public string Text => "I need " + RequiredItem.Name + " to use that";

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract()
        {
            var selectedItem = inventory.GetSelected();
            if (selectedItem != RequiredItem) return false;

            if (selectedItem.ConsumedUponUse) inventory.RemoveSelected();
            OnInteract.Invoke();
            return true;
        }

        public bool TryInteract(out string message)
        {
            message = null;

            var selectedItem = inventory.GetSelected();

            if (selectedItem == null)
            {
                message = "I can't use this with bare hands";
                return false;
            }

            if (selectedItem != RequiredItem)
            {
                message = "This item does not fit here";
                return false;
            }

            if (selectedItem.ConsumedUponUse) inventory.RemoveSelected();
            OnInteract.Invoke();
            return true;
        }
    }
}
