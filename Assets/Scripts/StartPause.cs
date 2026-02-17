using UnityEngine;

public class StartPause : MonoBehaviour
{
    bool gameStarted;

    public float pulseSpeed = 3f;     // how fast it pulses
    public float pulseAmount = 0.2f;  // how much it grows/shrinks
    private Vector3 originalScale;
    private RectTransform rectTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Time.timeScale = 0f; // pause game
        gameStarted = false;

        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
            originalScale = rectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            // pulse animation
            float scale = 1 + Mathf.Sin(Time.unscaledTime * pulseSpeed) * pulseAmount;
            rectTransform.localScale = originalScale * scale;
        }

        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        gameObject.SetActive(false); // hide the Text
        Time.timeScale = 1f;         // unpause game
    }

}
