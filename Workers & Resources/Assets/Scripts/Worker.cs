using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [Header("Settings")]
    private bool isSelected;

    // Update is called once per frame
    private void Update()
    {
        if(isSelected == true)
        { 
            //If worker is selected then setting its position to wherever the player drags it to
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;

    }

    private void OnMouseUp()
    {
        isSelected = false;
    }
}
