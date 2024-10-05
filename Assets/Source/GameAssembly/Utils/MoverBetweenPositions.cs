using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class MoverBetweenPositions
    {
        //Ctor params
        private readonly Transform transform;

        //Internal
        private Vector3 source;
        private Vector3 target;
        private float duration;

        private float progress;

        public MoverBetweenPositions(Transform transform, Vector3 source, Vector3 target, float duration)
        {
            this.transform = transform;
        }

        public bool FrameMove()
        {
            if (progress >= 1f)
            {
                return false;
            }

            progress += Time.deltaTime / duration;

            transform.position = Vector3.Lerp(source, target, progress);
            return true;
        }

        public void SetPoints(Vector3 source, Vector3 target)
        {
            progress = 0f;
            this.source = source;
            this.target = target;
        }

        public void SetDuration(float duration)
        {
            this.duration = duration;
        }
    }
}
