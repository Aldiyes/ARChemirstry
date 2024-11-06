using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 prefabOffset;
    [SerializeField] private string animationTrigger;

    private GameObject scene;
    private ARTrackedImageManager arTrackedImageManager;
    private Animator animator;

    private Button buttonPlay;

    private void OnEnable()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;

        buttonPlay = GameObject.Find("BtnPlay").GetComponent<Button>();
        buttonPlay.onClick.AddListener(PlayAnimation);

    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added)
        {
            scene = Instantiate(prefab, image.transform);
            scene.transform.position += prefabOffset;

            // Get the Animator component from the instantiated prefab
            animator = scene.GetComponent<Animator>();
        }
    }

    private void PlayAnimation()
    {
        // If the animator exists and the animation trigger is set, play it
        if (animator != null && !string.IsNullOrEmpty(animationTrigger))
        {
            animator.SetTrigger(animationTrigger);
        }
    }
}