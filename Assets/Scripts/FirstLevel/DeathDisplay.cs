using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathDisplay : MonoBehaviour {
    public TextMeshProUGUI deathTextObject;
    public DeathTracker dt;

    void Update() {
        deathTextObject.text = $"Deaths: {dt.GetDeaths()}";
    }
}
