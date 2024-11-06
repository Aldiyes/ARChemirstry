using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScenePanelController : MonoBehaviour
{
    [SerializeField] private Button buttonName;
    [SerializeField] private GameObject prevPanel;

    public void ButtonNextPanel(GameObject nextPanel)
    {
        prevPanel.gameObject.SetActive(false);
        nextPanel.gameObject.SetActive(true);
    }

    public void ButtonChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
