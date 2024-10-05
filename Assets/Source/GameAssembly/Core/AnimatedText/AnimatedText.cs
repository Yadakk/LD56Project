using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        private TextMeshProUGUI tmpu;

        private string currentString;
        private int currentCharacter = 0;

        private void Awake()
        {
            tmpu = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Animate("Hello World!");
        }

        public void Animate(string text)
        {
            CancelInvoke(nameof(HideText));
            StopPrinting();
            ResetColor();
            currentCharacter = 0;
            currentString = text;
            InvokeRepeating(nameof(NextChar), 0f, characterRate);
        }

        private void StopPrinting()
        {
            CancelInvoke(nameof(NextChar));
        }

        private void NextChar()
        {
            currentCharacter++;
            tmpu.text = currentString[..currentCharacter];

            if (currentCharacter == currentString.Length)
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
