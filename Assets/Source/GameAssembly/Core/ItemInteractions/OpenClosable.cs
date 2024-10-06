using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    [RequireComponent(typeof(Animator))]
    public class OpenClosable : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData requiredItem;

        [SerializeField]
        private bool isLocked;

        private bool isOpen;

        private Inventory inventory;

        private Animator animator;

        public string Text => isLocked ? "I need " + requiredItem.Name + " to unlock this" : "Open/Close";

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract(out string message)
        {
            if (isLocked)
            {
                return TryUnlock(out message);
            }
            else
            {
                OpenClose();
                message = null;
                return true;
            }
        }

        private bool TryUnlock(out string message)
        {
            if (!ItemRaycastUser.TryUse(inventory, requiredItem, out message)) return false;
            isLocked = false;
            return true;
        }

        private void OpenClose()
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);
        }
    }
}
