using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public static class MainRaycaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("TypeSafety", "UNT0014:Invalid type for call to GetComponent", Justification = "Components can inherit from interface")]
        public static bool TryRaycast<T>(out T result, float maxDistance)
        {
            result = default;
            Ray ray = Camera.main.ViewportPointToRay(Vector2.one / 2);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance)) return false;
            if (!hitInfo.collider.TryGetComponent(out result)) return false;
            return true;
        }
    }
}
