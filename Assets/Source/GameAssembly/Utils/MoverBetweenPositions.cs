using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class MoverBetweenPositions
    {
        private readonly Transform transform;
        private Vector3 source;
        private Vector3 target;
        private readonly float duration;

        private float progress;

        public MoverBetweenPositions(Transform transform, Vector3 source, Vector3 target, float duration)
        {
            this.transform = transform;
            this.source = source;
            this.target = target;
            this.duration = duration;
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
    }
}
