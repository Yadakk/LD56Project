using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD56Project.GameAssembly
{
    public class Slot : MonoBehaviour
    {
        private ItemContainer itemContainer;
        private Image image;

        private void Awake()
        {
            itemContainer = GetComponentInChildren<ItemContainer>();
            image = GetComponent<Image>();
        }

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public ItemData GetData()
        {
            return itemContainer.GetData();
        }

        public void SetData(ItemData data)
        {
            itemContainer.SetData(data);
        }

        public ItemContainer GetItemContainer()
        {
            return itemContainer;
        }
    }
}