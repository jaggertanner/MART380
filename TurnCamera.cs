using UnityEngine;

public class TurnCamera : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private float screenWidth;

    // Timer variables
    private float timer = 0f;
    private float updateInterval = 0.5f; // Update interval in seconds
    private float updateMultiplier = 1f; // Update multiplier for edge areas

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * updateMultiplier; // Accumulate time passed with update multiplier

        // Check if it's time to rotate the camera
        if (timer >= updateInterval)
        {
            // Reset timer
            timer = 0f;

            // Rotate the camera based on the direction
            RotateCamera();
        }
    }

    // Method to rotate the camera
    void RotateCamera()
    {
        // Calculate the direction of scrolling based on mouse position
        float mouseX = Input.mousePosition.x;
        float normalizedMouseX = (mouseX / screenWidth);

        float direction = 0f;
        if (normalizedMouseX < 0.25f)
        {
            direction = -1f; // Scroll left if mouse is in the left 1/4 of the screen
            if (normalizedMouseX < 0.1f)
            {
                direction = -2f; // Scroll left faster if mouse is in the left 1/10 of the screen
                updateMultiplier = 2f; // Update twice as often when close to the edge
            }
            else
            {
                updateMultiplier = 1f; // Reset update multiplier if not in the edge area
            }
        }
        else if (normalizedMouseX > 0.75f)
        {
            direction = 1f; // Scroll right if mouse is in the right 1/4 of the screen
            if (normalizedMouseX > 0.9f)
            {
                direction = 2f; // Scroll right faster if mouse is in the right 1/10 of the screen
                updateMultiplier = 2f; // Update twice as often when close to the edge
            }
            else
            {
                updateMultiplier = 1f; // Reset update multiplier if not in the edge area
            }
        }
        else
        {
            updateMultiplier = 1f; // Reset update multiplier if not in the edge area
        }

        // Rotate the camera based on the direction of scrolling
        transform.Rotate(Vector3.up, scrollSpeed * direction * 30f);
    }
}
