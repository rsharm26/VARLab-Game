using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
    private float timer = 0.0f;
    public TextMeshProUGUI timerTextObject;

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime; // Frame time or regular time?
        TimeSpan time = TimeSpan.FromSeconds(timer);

        timerTextObject.text = $"{time.Minutes:D2}:{time.Seconds:D2}";
    }
}
