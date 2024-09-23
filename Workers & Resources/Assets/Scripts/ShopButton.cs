using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [Header("References")]
    private Button button;

    [Header("Settings")]
    public int bloodCost;
    public int woodCost;
    public int crystalCost;

    private void Start()
    {
        button = GetComponent<Button>(); //Getting the button component of the game object
    }

    private void Update()
    {
        if(ResourceManager.instance.blood < bloodCost || ResourceManager.instance.wood < woodCost || ResourceManager.instance.crystal < crystalCost)
        {
            button.interactable =  false;
        }
        else
        {
            button.interactable =  true;
        }
    }

    public void RemoveResource()
    {
        ResourceManager.instance.AddResource("Blood", -bloodCost);
        ResourceManager.instance.AddResource("Wood", -woodCost);
        ResourceManager.instance.AddResource("Crystal", -crystalCost);
    }

}
