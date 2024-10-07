using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class Cockroach : MonoBehaviour
    {
        //Serialized
        [SerializeField]
        private float minDistance = 0.5f;

        [SerializeField]
        private float maxDistance = 2f;

        [SerializeField]
        private float minDuration = 0.5f;

        [SerializeField]
        private float maxDuration = 2f;

        //Composition
        private MoverBetweenPositions mover;

        //Internal
        private float distance;

        void Update()
        {
            Vector3 source = transform.position;
            Vector3 target = NextTarget();
            float duration = Random.Range(minDuration, maxDuration);

            mover ??= new(transform, source, target, duration);

            if (!mover.FrameMove())
            {
                transform.rotation = Quaternion.LookRotation(target - source, transform.up);
                mover = new(transform, source, target, duration);
            }
        }

        private Vector3 NextTarget()
        {
            distance = Random.Range(minDistance, maxDistance);

            Quaternion quaternionDirection = Quaternion.AngleAxis(Random.Range(0f, 360f), transform.up);
            Vector3 direction = quaternionDirection * transform.forward;
            Vector3 newTarget = transform.parent.position + distance * Random.Range(0f, 1f) * direction;
            return newTarget;
        }
    }
}
