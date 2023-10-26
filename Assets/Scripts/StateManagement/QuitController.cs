using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitController : MonoBehaviour {
    public void ExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exit in development.
        #endif

        Application.Quit(); // Exit in production.
    }
}
