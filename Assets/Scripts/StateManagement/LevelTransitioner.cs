using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransitioner : MonoBehaviour {
    [SerializeField] private string transitionTo;
    [SerializeField] private Slider progressBar;

    private void Start() {
        progressBar.value = 0;
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync() {
        yield return null; // Wait until Update() finishes (may not be needed).
        yield return new WaitForSeconds(5f); // ARTIFICIAL DELAY FOR DEMO, REMOVE ME.
        AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(transitionTo); // Asynchronous loading of the next level.

        while (sceneLoader.isDone == false) { // Check if async task is done.
            Debug.Log(sceneLoader.progress);
            progressBar.value = sceneLoader.progress; // Update progress bar.
            yield return new WaitForEndOfFrame(); // Wait until Unity renders everything but just before the first frame is displayed.
        }
    }
}
