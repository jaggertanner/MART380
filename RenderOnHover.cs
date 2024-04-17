using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOnHover : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    // When the mouse hovers over the object, toggle the mesh renderer
    void OnMouseEnter()
    {
        meshRenderer.enabled = true;
    }

    void OnMouseExit()
    {
        meshRenderer.enabled = false;
    }

    void OnMouseOver() {

    }
}
