using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(int sceneId)
    {
        StartCoroutine(LoadAsynchronously(sceneId));
    }

    IEnumerator LoadAsynchronously(int sceneId)
    {
        // Start loading the scene asynchronously and store the operation in 'operation'.
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        // Activate the loading screen GameObject to show the loading progress.
        loadingScreen.SetActive(true);
        // Continue looping until the loading operation is complete.
        while (!operation.isDone)
        {
            // Calculate the loading progress as a value between 0 and 1, clamped to 0-1.
            float progress = Mathf.Clamp01(operation.progress / .9f);
            // Update the slider's value to reflect the current loading progress.
            slider.value = progress;
            // Yield control back to the main game loop for one frame.
            // This is necessary to prevent the game from freezing and to allow the UI to update.
            yield return null;
        }
    }
}
