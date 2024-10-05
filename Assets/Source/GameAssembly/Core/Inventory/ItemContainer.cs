using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling.Memory.Experimental;
using UnityEngine.UI;

namespace LD56Project.GameAssembly
{
    public class ItemContainer : MonoBehaviour
    {
        private Image image;

        private ItemData data;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetData(ItemData data)
        {
            if (data == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
                image.sprite = data.Sprite;
            }

            this.data = data;
        }

        public ItemData GetData()
        {
            return data;
        }
    }
}