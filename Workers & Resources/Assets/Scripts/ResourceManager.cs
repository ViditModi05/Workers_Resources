using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    public int wood;
    public int crystal;
    public int blood;
    

    public static ResourceManager instance; 

    private void Awake()
    {
        instance = this;
    }

    public void AddResource(string resourceType, int amount)
    {
        if(resourceType == "Wood")
        {
            wood += amount;
            ResourceUI.instance.SetText();
        }
        if(resourceType == "Crystal")
        {
            crystal += amount;
            ResourceUI.instance.SetText();
        }
        if(resourceType == "Blood")
        {
            blood += amount;
            ResourceUI.instance.SetText();
        }
    }
}
