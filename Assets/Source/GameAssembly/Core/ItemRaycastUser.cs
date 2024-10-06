using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public static class ItemRaycastUser
    {
        public static bool TryUse(Inventory inventory, ItemData requiredItem, out string message)
        {
            message = null;

            ItemData selectedItem = inventory.GetSelected();

            if (selectedItem == null)
            {
                message = "I can't use this with bare hands";
                return false;
            }

            if (!selectedItem.CanBeRaycasted)
            {
                message = "I can't use this on objects at all";
                return false;
            }

            if (selectedItem != requiredItem)
            {
                message = "This item does not fit here";
                return false;
            }

            if (selectedItem.ConsumedUponUse) inventory.RemoveSelected();
            return true;
        }
    }
}
