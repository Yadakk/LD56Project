using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public static class LayerMaskComparatorExt
    {
        public static bool HasLayer(this LayerMask thisLayerMask, int layer)
        {
            return thisLayerMask == (thisLayerMask | (1 << layer));
        }
    }
}
