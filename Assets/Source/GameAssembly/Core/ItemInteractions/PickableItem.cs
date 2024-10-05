using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class PickableItem : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData itemData;

        private Inventory inventory;

        public string Text => "Pick up";

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract()
        {
            if (!inventory.TryAddItem(itemData)) return false;
            Destroy(gameObject);
            return true;
        }

        public bool TryInteract(out string message)
        {
            message = null;

            if (!inventory.TryAddItem(itemData))
            {
                message = "My inventory is full";
                return false;
            }

            Destroy(gameObject);
            return true;
        }
    }
}
