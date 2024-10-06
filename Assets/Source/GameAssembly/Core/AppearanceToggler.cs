using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class AppearanceToggler : MonoBehaviour
    {
        [SerializeField]
        private bool isShown;

        private void Start()
        {
            SetShown(isShown);
        }

        public void Toggle()
        {
            SetShown(!isShown);
        }

        private void SetShown(bool shown)
        {
            gameObject.SetActive(shown);
            isShown = shown;
        }
    }
}
