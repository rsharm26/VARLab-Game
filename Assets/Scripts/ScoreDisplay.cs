using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public TextMeshProUGUI scoreTextObject;
    public ScoreTracker st;

    void Update() {
        scoreTextObject.text = $"Score: {st.GetScore()}";
    }
}
