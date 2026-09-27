using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StressLevel : MonoBehaviour
{
    public TextMeshProUGUI messageOutput = null;
    [Range(0, 100)] public float stressLevel = 0f;
    string message;
    private void Start()
    {
        message = "Stress Level: " + stressLevel;
        ShowMessage();
    }
    private void ShowMessage()
    {
        messageOutput.text = message;
    }

    public void setStressLevel(float newValue)
    {
        newValue = Mathf.Clamp(newValue, 0, 1);
        stressLevel = newValue * 100;
        float displayStressLevel = Mathf.Round(stressLevel);

        message = "Stress Level: " + displayStressLevel;
        ShowMessage();
    }
}
