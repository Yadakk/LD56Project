using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Graphs;
using UnityEngine;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private Sprite defaultSlotSprite;

        [SerializeField]
        private Sprite selectedSlotSprite;

        private Slot[] slots;

        public int SelectedSlotIndex { get; private set; }

        private void Awake()
        {
            slots = GetComponentsInChildren<Slot>();

            ServiceLocator.ForSceneOf(this).Register(this);
        }

        private void Start()
        {
            foreach (Slot slot in slots)
            {
                slot.SetSprite(defaultSlotSprite);
            }

            SelectSlot(0);
        }

        public void SelectSlot(int index)
        {
            if (index >= slots.Length || index < 0) return;

            slots[SelectedSlotIndex].SetSprite(defaultSlotSprite);
            slots[index].SetSprite(selectedSlotSprite);
            SelectedSlotIndex = index;
        }

        public void SelectNext()
        {
            SelectSlot(SelectedSlotIndex + 1);
        }

        public void SelectPrevious()
        {
            SelectSlot(SelectedSlotIndex - 1);
        }

        public ItemData GetSelected()
        {
            return slots[SelectedSlotIndex].GetData();
        }

        public bool TryAddItem(ItemData data)
        {
            var emptySlot = slots.FirstOrDefault(slot => slot.GetData() == null);
            if (emptySlot == null) return false;
            emptySlot.SetData(data);
            return true;
        }

        public void RemoveItem(int index)
        {
            slots[index].GetItemContainer().SetData(null);
        }
    }

}