using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    public int wood;
    public int crystal;
    public int blood;
    public int numberOfWorkersSacrificed;
    [SerializeField] private int sacrificeGoal;
    

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

    public void AddSacrificeNumber()
    {
        numberOfWorkersSacrificed++;
        ResourceUI.instance.sacrificedWorkersText.text = numberOfWorkersSacrificed + " / " + sacrificeGoal;

        if(numberOfWorkersSacrificed >= sacrificeGoal)
        {
            print("You Have Won!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
