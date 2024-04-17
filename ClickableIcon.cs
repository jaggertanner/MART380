using UnityEngine;

public class ClickableIcon : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    void Start()
    {
        // Get the MeshRenderer component attached to the object
        meshRenderer = GetComponent<MeshRenderer>();

        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();

        // Disable the MeshRenderer to hide the object
        meshRenderer.enabled = false;

        // Disable the AudioSource to prevent it from playing automatically
        if (audioSource != null)
        {
            audioSource.enabled = false;
        }
    }

    // Called when the mouse pointer enters the object's collider
    void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        // Enable the MeshRenderer to show the object
        meshRenderer.enabled = true;
    }

    // Called when the mouse pointer exits the object's collider
    void OnMouseExit()
    {
        // Disable the MeshRenderer to hide the object
        meshRenderer.enabled = false;
    }

    // Called when the object is clicked
    void OnMouseDown()
    {
        // Check if an AudioSource is attached and if it has an audio clip
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the attached audio clip
            audioSource.Play();
        }
    }
}
