using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD56Project.GameAssembly
{
    public class SlotScroller : MonoBehaviour
    {
        [SerializeField]
        private Image slotImage;

        private void Awake()
        {
            slotImage.sprite = null;
        }
    }
}