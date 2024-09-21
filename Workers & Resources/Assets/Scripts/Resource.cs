using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [Header("Settings")]
    public int resourceAmount;
    public string resourceType;

    private void Update()
    {
        if(resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

}
