using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityServiceLocator;

namespace LD56Project.GameAssembly
{
    public class ItemUsedListener : MonoBehaviour
    {
        //Serialized
        [SerializeField]
        private ItemData.UseType usage;

        [SerializeField]
        private UnityEvent OnItemUsed;

        //ServiceLocator Get
        private PlayerInteractor interactor;

        private void Start()
        {
            interactor = ServiceLocator.ForSceneOf(this).Get<PlayerInteractor>();
            interactor.OnItemUsed += OnItemUsedHandler;
        }

        private void OnItemUsedHandler(ItemData.UseType usage)
        {
            OnItemUsed.Invoke();
        }
    }
}
