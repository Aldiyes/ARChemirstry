using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ARChemistry.Typography.Typewriter
{
    [RequireComponent(typeof(TMP_Text))]
    public class SetTextToDisplay : MonoBehaviour
    {
        private TMP_Text _textBox;
        private TypewriterEffect _typewriterEffect;

        // List to store texts
        [SerializeField] private List<string> textList;
        private int currentTextIndex = 0;

        private void Awake()
        {
            _textBox = GetComponent<TMP_Text>();
            _typewriterEffect = GetComponent<TypewriterEffect>();
        }

        private void Start()
        {
            // Start with the first text
            SetNextText();
        }

        public void SetNextText(bool quickSkip = false)
        {
            if (currentTextIndex < textList.Count)
            {
                // Set the next text in the list
                string nextText = textList[currentTextIndex];
                _textBox.text = nextText;

                // Start typing effect for the new text
                _typewriterEffect.StartTyping();


                // Increment index to load the next text when the button is clicked
                currentTextIndex++;
            }
            else
            {
                Debug.Log("All texts have been displayed.");
            }
        }

    }
}
