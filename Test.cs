using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // This version of the script is meant to be put on a separate hitbox object, rather than attached to the plane with the sprite itself.
    // Basic idea is on hover, render the mesh of the 'outlined' version of the sprite
    // On click, play the audio clip attached to the hitbox object
    public MeshRenderer meshRenderer;
    public AudioSource audioSource;
    public Material normal;
    public Material highlight;


    void Start()
    {
        GetComponent<MeshRenderer>().material = normal;
        
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
        GetComponent<MeshRenderer>().material = highlight;

    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer over GameObject.");
        GetComponent<MeshRenderer>().material = normal;
    }

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
