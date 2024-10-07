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

        private AudioSource audioSource;

        public string Text => "Pick up " + itemData.Name;

        private void Awake()
        {
            if (pickSound != null) audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
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
            Destroy(gameObject);
            return true;
        }
    }
}
