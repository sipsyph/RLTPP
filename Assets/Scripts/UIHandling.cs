using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandling : MonoBehaviour
{
    public Button resetPosBtn;
    void Start()
    {
        SetUpEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpEvents()
    {
        resetPosBtn.onClick.AddListener(() =>
        {
            PlayerMovement.shouldResetPosition = true;
        });
    }
}
