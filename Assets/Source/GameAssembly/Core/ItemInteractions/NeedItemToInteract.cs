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
    }
}
