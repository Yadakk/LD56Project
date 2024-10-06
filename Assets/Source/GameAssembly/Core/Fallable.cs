using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class Fallable : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private float fallDistance = 3f;

        [SerializeField]
        private float fallDuration = 0.5f;

        private MoverBetweenPositions mover;

        public string Text => "Remove";

        private void Update()
        {
            mover?.FrameMove();
        }

        public bool TryInteract(out string message)
        {
            message = null;
            mover = new(transform, transform.position, transform.position - new Vector3(0f, fallDistance, 0f), fallDuration);
            return true;
        }
    }
}
