using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    public GameObject LevelDoneUI;
    public Slider uiSlider; // Reference to the UI Slider
    public float duration = 20f; // Duration to fill the slider

    private float elapsedTime = 0f; // Track elapsed time
    private bool isFilling = true; // Track if the slider is currently filling

    void Start()
    {
        // Ensure the slider is at the starting value
        uiSlider.value = 0f;
    }

    void Update()
    {
        if (isFilling && elapsedTime < duration)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the slider value based on elapsed time
            uiSlider.value = Mathf.Clamp01(elapsedTime / duration);
        }
        else if (isFilling && elapsedTime >= duration)
        {
            // Handle completion
            OnFillComplete();
        }
    }

    void OnFillComplete()
    {
        isFilling = false;
        Debug.Log("Level Completed!");
        // Add any additional logic for when the fill is complete
        LevelCompleted();
    }

    public void RestartFill()
    {
        elapsedTime = 0f;
        isFilling = true;
        uiSlider.value = 0f;
    }

    void LevelCompleted()
    {
        // Implement your level completion logic here
        Debug.Log("You can load the next level or show a completion message.");
        LevelDoneUI.SetActive(true);
        StartCoroutine(StopGame());
        // Example: Load the next level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator StopGame()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
}
