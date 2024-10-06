using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public interface IInteractible
    {
        public string Text { get; }

        bool TryInteract(out string message);
    }
}
