using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD56Project.GameAssembly
{
    public class AmbientPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource ambientSource;
        [SerializeField]
        private AudioClip[] ambientArr;
        private void Awake()
        {
            ambientSource.clip = ambientArr[Random.Range(0,2)];
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }
}
