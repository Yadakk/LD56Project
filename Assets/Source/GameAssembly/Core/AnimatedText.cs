using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServiceLocator;
using TMPro;

namespace LD56Project.GameAssembly
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AnimatedText : MonoBehaviour
    {
        [SerializeField]
        private float characterRate = 0.3f;

        [SerializeField]
        private float textDisappearDelay = 5f;

        [SerializeField]
        private AudioSource sfxSource;

        [SerializeField]
        private AudioClip[] audioClipArr;

        private TextMeshProUGUI tmpu;

        private string currentString;
        private int currentCharacter = 0;

        private void Awake()
        {
            tmpu = GetComponent<TextMeshProUGUI>();
            ServiceLocator.ForSceneOf(this).Register(this);
        }

        public void Animate(string text)
        {
            if (text == null) return;
            if (text.Length == 0) return;

            CancelInvoke(nameof(HideText));
            StopPrinting();
            ResetColor();
            currentCharacter = 0;
            currentString = text;
            InvokeRepeating(nameof(NextChar), 0f, characterRate);
            sfxSource.clip = audioClipArr[Random.Range(0, 8)];
            sfxSource.Play();
        }

        private void StopPrinting()
        {
            CancelInvoke(nameof(NextChar));
        }

        private void NextChar()
        {
            currentCharacter++;
            tmpu.text = currentString[..currentCharacter];

            if (currentCharacter >= currentString.Length)
            {
                StopPrinting();
                InvokeRepeating(nameof(HideText), textDisappearDelay, Time.deltaTime);
            }
        }

        private void HideText()
        {
            Color newColor = tmpu.color;
            newColor.a -= Time.deltaTime;
            tmpu.color = newColor;
        }

        private void ResetColor()
        {
            Color newColor = tmpu.color;
            newColor.a = 1f;
            tmpu.color = newColor;
        }
    }
}
