using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public static class MainRaycaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("TypeSafety", "UNT0014:Invalid type for call to GetComponent", Justification = "<ќжидание>")]
        public static bool TryRaycast<T>(out T result, float maxDistance)
        {
            result = default;
            Ray ray = Camera.main.ScreenPointToRay(Vector2.zero);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance)) return false;
            if (!hitInfo.collider.TryGetComponent(out result)) return false;
            return true;
        }
    }
}
