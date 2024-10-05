using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class NeedItemToInteract : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData RequiredItem;

        private Inventory inventory;

        public string Text => "I need " + RequiredItem.Name + " to use that";

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public virtual void Interact()
        {
            if (inventory.GetSelected() != RequiredItem) return;
            inventory.RemoveSelected();
        }
    }
}
