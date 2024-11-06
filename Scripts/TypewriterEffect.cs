using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace ARChemistry.Typography.Typewriter
{
    [RequireComponent(typeof(TMP_Text))]
    public class TypewriterEffect : MonoBehaviour
    {
        private TMP_Text _textBox;
        private int _currentVisibleCharacterIndex;
        private Coroutine _typewriterCoroutine;
        private bool _currentlySkipping = false;

        [Header("Typewriter Settings")]
        [SerializeField] private float charactersPerSecond = 20;
        [SerializeField] private float interpunctuationDelay = 0.5f;

        private WaitForSeconds _simpleDelay;
        private WaitForSeconds _interpunctuationDelayTime;

        // Skipping Functionality
        private WaitForSeconds _skipDelay;
        [SerializeField][Min(1)] private int skipSpeedup = 5;

        private WaitForSeconds _textboxFullEventDelay;
        [SerializeField][Range(0.1f, 0.5f)] private float sendDoneDelay = 0.25f;

        public static event Action CompleteTextRevealed;
        public static event Action<char> CharacterRevealed;

        private void Awake()
        {
            _textBox = GetComponent<TMP_Text>();
            _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
            _interpunctuationDelayTime = new WaitForSeconds(interpunctuationDelay);
            _skipDelay = new WaitForSeconds(1 / (charactersPerSecond * skipSpeedup));
            _textboxFullEventDelay = new WaitForSeconds(sendDoneDelay);
        }

        public void StartTyping()
        {
            if (_textBox.textInfo.characterCount == 0)
                return;

            if (_typewriterCoroutine != null)
                StopCoroutine(_typewriterCoroutine);

            _currentVisibleCharacterIndex = 0;
            _textBox.maxVisibleCharacters = 0;
            _currentlySkipping = false;

            _typewriterCoroutine = StartCoroutine(Typewriter());
        }

        private IEnumerator Typewriter()
        {
            TMP_TextInfo textInfo = _textBox.textInfo;

            while (_currentVisibleCharacterIndex < textInfo.characterCount)
            {
                char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;
                _textBox.maxVisibleCharacters++;

                if (!CurrentlySkipping() &&
                    (character == '?' || character == '.' || character == ',' || character == ':' ||
                     character == ';' || character == '!' || character == '-'))
                {
                    yield return _interpunctuationDelayTime;
                }
                else
                {
                    yield return CurrentlySkipping() ? _skipDelay : _simpleDelay;
                }

                CharacterRevealed?.Invoke(character);
                _currentVisibleCharacterIndex++;
            }

            // Once typing is finished, trigger event
            CompleteTextRevealed?.Invoke();
        }

        public void Skip(bool quickSkip = false)
        {
            if (_currentlySkipping)
                return;

            _currentlySkipping = true;

            if (quickSkip)
            {
                StopCoroutine(_typewriterCoroutine);
                _textBox.maxVisibleCharacters = _textBox.textInfo.characterCount;
                CompleteTextRevealed?.Invoke();
            }
            else
            {
                StartCoroutine(SkipSpeedupReset());
            }
        }

        private IEnumerator SkipSpeedupReset()
        {
            yield return new WaitUntil(() => _textBox.maxVisibleCharacters == _textBox.textInfo.characterCount - 1);
            _currentlySkipping = false;
        }

        public bool CurrentlySkipping()
        {
            return _currentlySkipping;
        }
    }
}
