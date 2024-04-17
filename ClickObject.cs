using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
    This version was created by following the tutorial at https://www.youtube.com/watch?v=pfkQDGhd8_A

    Instead of the cube, this script is placed on the camera.
    When you click on the screen, it will check if the object clicked is the cube.
*/
public class ClickObject : MonoBehaviour
{
    public GameObject cube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cube == GetClickedObject(out RaycastHit hit))
            {
                print("clicked/touched!");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("Mouse is off!");
        }
    }

    // Get the object clicked
    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
   /* // Check if the pointer is over a UI object (Not necessary for my code, just included in the video tutorial)
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
    */
}