using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Ghost")]
    public Ghost worker;
    public Ghost tree;
    public Ghost crystal;
    public Ghost village;
    public Ghost trap;

    public void OnShopClick(string item)
    {
        if(item == "worker")
        {
            Instantiate(worker);
        }
        if(item == "tree")
        {
            Instantiate(tree);
        }
        if(item == "crystal")
        {
            Instantiate(crystal);
        }
        if(item == "village")
        {
            Instantiate(village);
        }
        if(item == "trap")
        {
            Instantiate(trap);
        }

    }
}
