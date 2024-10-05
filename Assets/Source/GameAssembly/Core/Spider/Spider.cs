using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class Spider : MonoBehaviour
    {
        [SerializeField]
        private LayerMask triggerLayers;

        private void OnTriggerEnter(Collider other)
        {
            if (!triggerLayers.HasLayer(other.gameObject.layer)) return;
        }

        private void Show()
        {

        }
    }
}
