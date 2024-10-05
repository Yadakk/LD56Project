using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class Cockroach : MonoBehaviour
    {
        [SerializeField]
        private float minDistance = 0.5f;

        [SerializeField]
        private float maxDistance = 2f;

        [SerializeField]
        private float minSpeed = 0.5f;

        [SerializeField]
        private float maxSpeed = 2f;

        private Transform origin;
        private Vector3 source;
        private Vector3 target;
        private float t;
        private float speed;
        private float distance;

        private void Awake()
        {
            origin = transform.parent;
            target = NextTarget();
        }

        void Update()
        {
            if (t >= 1f)
            {
                target = NextTarget();
                t = 0f;
            }

            t += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(source, target, t);
        }

        private Vector3 NextTarget()
        {
            speed = Random.Range(minSpeed, maxSpeed);
            distance = Random.Range(minDistance, maxDistance);

            source = transform.position;
            Quaternion quaternionDirection = Quaternion.AngleAxis(Random.Range(0f, 360f), transform.up);
            Vector3 direction = quaternionDirection * transform.forward;
            Vector3 newTarget = origin.position + distance * Random.Range(0f, 1f) * direction;
            transform.rotation = Quaternion.LookRotation(newTarget - source, transform.up);
            return newTarget;
        }
    }
}
