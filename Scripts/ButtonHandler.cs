using ARChemistry.Typography.Typewriter;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [Header("References")]
    public GameObject contentGameObject;  // Reference to content GameObject
    private SetTextToDisplay setTextToDisplay;  // Reference to SetTextToDisplay script
    private TypewriterEffect typewriterEffect;  // Reference to TypewriterEffect script

    private void Start()
    {
        // Get references to SetTextToDisplay and TypewriterEffect from content GameObject
        setTextToDisplay = contentGameObject.GetComponent<SetTextToDisplay>();
        typewriterEffect = contentGameObject.GetComponent<TypewriterEffect>();
    }

    // Called when the Next Button is clicked
    public void OnNextButtonClicked()
    {
        if (typewriterEffect != null)
        {
            if (!typewriterEffect.CurrentlySkipping())
            {
                // If typing is in progress, finish it immediately
                setTextToDisplay.SetNextText(quickSkip: true);
            }
            else
            {
                // If typing is done, load the next text
                setTextToDisplay.SetNextText();
            }
        }
    }

}
