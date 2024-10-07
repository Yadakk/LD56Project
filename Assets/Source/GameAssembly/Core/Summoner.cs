using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class Summoner : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private List<ItemData> requiredItems;

        [SerializeField]
        private string sceneName;

        private Inventory inventory;

        private List<ItemData> remainingItems;

        public string Text => "I need " + GetRemainingItemNames() + " for the ritual";

        private void Awake()
        {
            remainingItems = new(requiredItems);
        }

        private void Start()
        {
            inventory = ServiceLocator.ForSceneOf(this).Get<Inventory>();
        }

        public bool TryInteract(out string message)
        {
            message = null;

            foreach (var item in remainingItems)
            {
                if (!ItemRaycastUser.TryUse(inventory, item, out message)) continue;
                remainingItems.Remove(item);

                if (remainingItems.Count <= 0)
                {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(sceneName);
                }

                return true;
            }

            return false;
        }

        private string GetRemainingItemNames()
        {
            StringBuilder builder = new();
            foreach(var item in remainingItems)
            {
                builder.Append(item.Name + ", ");
            }

            if (builder.Length - 2 >= 0)
            {
                builder.Remove(builder.Length - 2, 2);
            }

            return builder.ToString();
        }
    }
}