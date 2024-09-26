using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text bloodText;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text crystalText;
    public TMP_Text sacrificedWorkersText;

    public static ResourceUI instance;

    private void Awake()
    {
        instance = this;

    }

    public void SetText()
    {
       bloodText.text = ResourceManager.instance.blood.ToString();
       woodText.text = ResourceManager.instance.wood.ToString();
       crystalText.text = ResourceManager.instance.crystal.ToString();

    }


}
