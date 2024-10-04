using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    [CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
    public class ItemData : ScriptableObject
    {
        public Sprite sprite;

        public enum ItemType
        {
            Pill,
        }
    }
}