using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class Summoner : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private ItemData requiredItem;

        [SerializeField]
        private string sceneName;

        private Inventory inventory;

        public string Text => "I need " + requiredItem.Name + " for the ritual";

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract(out string message)
        {
            if (!ItemRaycastUser.TryUse(inventory, requiredItem, out message)) return false;
            SceneManager.LoadScene(sceneName);
            return true;
        }
    }
}