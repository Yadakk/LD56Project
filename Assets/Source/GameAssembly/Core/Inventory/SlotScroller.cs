using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class SlotScroller : MonoBehaviour
    {
        private Inventory inventory;

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public void OnScrollSlots(InputValue value)
        {
            float scrollDir = value.Get<float>();
            if (scrollDir > 0) inventory.SelectNext();
            else if (scrollDir < 0) inventory.SelectPrevious();
        }
    }
}