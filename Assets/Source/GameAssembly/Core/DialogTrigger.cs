using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class DialogTrigger : MonoBehaviour
    {
        [SerializeField]
        private LayerMask triggerLayers;

        [SerializeField]
        [TextArea]
        private string dialog;

        private AnimatedText animatedText;

        private void Start()
        {
            animatedText = ServiceLocator.ForSceneOf(this).Get<AnimatedText>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!triggerLayers.HasLayer(other.gameObject.layer)) return;
            animatedText.Animate(dialog);
            Destroy(gameObject);
        }
    }
}
