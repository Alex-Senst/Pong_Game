using UnityEngine;

public class CanvasToggle : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Drag your CanvasGroup here in the Inspector.

    void Start()
    {
        canvasGroup.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle visibility
            ToggleCanvasVisibility();
        }
    }

    public void ToggleCanvasVisibility()
    {
        // Check if the canvas is currently visible
        if (canvasGroup.alpha == 1)
        {
            // Hide the canvas
            canvasGroup.alpha = 0;             // Make it invisible
            canvasGroup.interactable = false; // Disable interaction
            canvasGroup.blocksRaycasts = false; // Disable raycasting
        }
        else
        {
            // Show the canvas
            canvasGroup.alpha = 1;             // Make it visible
            canvasGroup.interactable = true;  // Enable interaction
            canvasGroup.blocksRaycasts = true; // Enable raycasting
        }
    }
}
