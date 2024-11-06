using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HomeScenePrevNextController : MonoBehaviour
{
    [SerializeField] private Button prevButton, nextButton;
    [SerializeField] private GameObject header, content;
    [SerializeField] private string[] textHeader, textContent;
    private int currentIndex = 0;

    private void Start()
    {
        prevButton.interactable = false;
        nextButton.interactable = true;
        TextMeshProUGUI headerText = header.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI contentText = content.GetComponent<TextMeshProUGUI>();

        headerText.SetText(textHeader[currentIndex]);
        contentText.SetText(textContent[currentIndex]);
    }

    public void NextButtonClicked()
    {
        prevButton.interactable = true;
        currentIndex = currentIndex + 1;

        TextMeshProUGUI headerText = header.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI contentText = content.GetComponent<TextMeshProUGUI>();

        headerText.SetText(textHeader[currentIndex]);
        contentText.SetText(textContent[currentIndex]);

        if (currentIndex == textContent.Length - 1)
        {
            nextButton.interactable = false;
        }
    }

    public void PrevButtonClicked()
    {
        nextButton.interactable = true;
        currentIndex = currentIndex - 1;

        TextMeshProUGUI headerText = header.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI contentText = content.GetComponent<TextMeshProUGUI>();

        headerText.SetText(textHeader[currentIndex]);
        contentText.SetText(textContent[currentIndex]);

        if (currentIndex == 0)
        {
            prevButton.interactable = false;
        }
    }
}
