using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    [CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }

        [field: SerializeField]
        public string Name { get; private set; }
    }
}