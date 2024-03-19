using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public float fillDuration = 5f; // Time taken to fill from 0 to 1
    private float currentValue = 0f; // Current value
    [SerializeField] Image loadingBar;

    private void Start()
    {
        // Start the filling process
        StartCoroutine(FillOverTime());
    }

    private System.Collections.IEnumerator FillOverTime()
    {
        float timer = 0f;

        while (timer < fillDuration)
        {
            // Calculate the progress ratio
            float progress = timer / fillDuration;

            // Update the current value
            currentValue = Mathf.Lerp(0f, 1f, progress);
            loadingBar.fillAmount = currentValue;
            // Increase timer
            timer += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the value is exactly 1 at the end
        currentValue = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
