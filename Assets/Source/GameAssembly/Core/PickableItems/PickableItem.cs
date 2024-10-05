using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class PickableItem : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData itemData;

        public string Text => "Pick up";

        public void Interact()
        {
            Debug.Log(itemData.name);
        }
    }
}
