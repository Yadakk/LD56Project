using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class Spider : MonoBehaviour
    {
        [Header("Trigger")]
        [SerializeField]
        private LayerMask triggerLayers;

        [Header("Distance")]
        [SerializeField]
        private float minDistance = 3f;

        [SerializeField]
        private float maxDistance = 3.5f;

        [Header("DurationDown")]
        [SerializeField]
        private float minDurationDown = 0.2f;

        [SerializeField]
        private float maxDurationDown = 0.3f;

        [Header("DurationUp")]
        [SerializeField]
        private float minDurationUp = 1f;

        [SerializeField]
        private float maxDurationUp = 1f;

        private MoverBetweenPositions mover;

        private MovementDirection direction = MovementDirection.None;

        private float distance;

        private void Update()
        {
            if (direction == MovementDirection.None) return;

            if (!mover.FrameMove())
            {
                switch (direction)
                {
                    case MovementDirection.Down:
                        SetDirection(MovementDirection.Up);
                        break;

                    case MovementDirection.Up:
                        SetDirection(MovementDirection.None);
                        break;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!triggerLayers.HasLayer(other.gameObject.layer)) return;
            if (direction != MovementDirection.None) return;
            distance = Random.Range(minDistance, maxDistance);
            SetDirection(MovementDirection.Down);
        }

        private void SetDirection(MovementDirection direction)
        {
            float duration;

            Vector3 source = transform.parent.position;
            Vector3 target = transform.parent.position - transform.up * distance;

            switch (direction)
            {
                case MovementDirection.Down:
                    duration = Random.Range(minDurationDown, maxDurationDown);
                    mover = new(transform, source, target, duration);
                    break;

                case MovementDirection.Up:
                    duration = Random.Range(minDurationUp, maxDurationUp);
                    mover = new(transform, target, source, duration);
                    break;
            }

            this.direction = direction;
        }

        private enum MovementDirection
        {
            None,
            Down,
            Up,
        }
    }
}