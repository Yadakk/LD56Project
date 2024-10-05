using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public static class ItemUser
    {
        public static void UseItem(ItemData itemData)
        {
            switch(itemData.Usage)
            {
                case ItemData.UseType.Pill:
                    Debug.Log("Pill");
                    break;
            }
        }
    }
}
