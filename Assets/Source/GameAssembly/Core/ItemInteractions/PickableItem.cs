using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class PickableItem : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData itemData;

        [SerializeField]
        private AudioClip pickSound;

        private Inventory inventory;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        [TextArea]
        private string pickupDialogue;

        private AnimatedText animatedText;

        public string Text => "Pick up " + itemData.Name;

        private void Start()
        {
            animatedText = ServiceLocator.ForSceneOf(this).Get<AnimatedText>();
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract(out string message)
        {
            message = null;

            if (!inventory.TryAddItem(itemData))
            {
                message = "My inventory is full";
                return false;
            }

            if (pickSound != null) audioSource.PlayOneShot(pickSound);
            animatedText.Animate(pickupDialogue);
            Destroy(gameObject);
            return true;
        }
    }
}
