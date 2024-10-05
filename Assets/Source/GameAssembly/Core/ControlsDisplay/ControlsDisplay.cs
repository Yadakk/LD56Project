using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class ControlsDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject tooltip;

        [SerializeField]
        private GameObject display;

        private bool isDisplayed;

        private void Awake()
        {
            SetDisplay(isDisplayed);
        }

        public void OnToggleControlsDisplay()
        {
            isDisplayed = !isDisplayed;
            SetDisplay(isDisplayed);
        }

        public void SetDisplay(bool isDisplayed)
        {
            tooltip.SetActive(!isDisplayed);
            display.SetActive(isDisplayed);
        }
    }
}
