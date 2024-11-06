using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelControllerScene2 : MonoBehaviour
{

    [SerializeField] private Button btnPlay, btnNext;
    [SerializeField] private GameObject header, content;
    [SerializeField] private GameObject panel;
    private string[] arrayHeader = { "Ini adalah scene 2", "POKOKNYA SCENE 2", "header 3" };
    private string[] arrayContent = { "Siapkan Marker", "Arahkan kamera ke marker", "Jika sudah muncul objek 3D, klik tombol Play Animation" };
    private int currentIndex = 0;

    private void Start()
    {
        btnPlay.gameObject.SetActive(false);
        TextMeshProUGUI headerText = header.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI contentText = content.GetComponent<TextMeshProUGUI>();

        headerText.SetText(arrayHeader[currentIndex]);
        contentText.SetText(arrayContent[currentIndex]);
    }

    public void UpdateContent()
    {
        currentIndex = currentIndex + 1;
        if (currentIndex == arrayContent.Length - 1)
        {
            btnNext.GetComponentInChildren<TextMeshProUGUI>().SetText("Mulai");
        }
        if (currentIndex == arrayContent.Length)
        {
            btnNext.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            btnPlay.gameObject.SetActive(true);
        }
        else
        {
            TextMeshProUGUI headerText = header.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI contentText = content.GetComponent<TextMeshProUGUI>();

            headerText.SetText(arrayHeader[currentIndex]);
            contentText.SetText(arrayContent[currentIndex]);
        }

    }
}