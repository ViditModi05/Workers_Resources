using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask resourceLayer;
    [SerializeField] private GameObject resourcePopUp;
    [SerializeField] private GameObject deathAudio;
    private GameObject bloodAltar;
    private Resource currentResource;
    private AudioSource pickAudio;
    [Header("Settings")]
    [SerializeField] private float collectDistance;
    [SerializeField] private float timeBetweenCollect;
    [SerializeField] private int collectionAmount;
    [SerializeField] private float distanceToAltar;
    private float nextCollectTime;
    private bool isSelected;

    private void Start()
    {
        pickAudio = GetComponent<AudioSource>();
        bloodAltar = GameObject.FindGameObjectWithTag("altar");
    }

    
    private void Update()
    {
        if(isSelected == true)
        { 
            //If worker is selected then setting its position to wherever the player drags it to
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
        }
        else
        {
            if(Vector3.Distance(transform.position, bloodAltar.transform.position) <= distanceToAltar)
            {
                ResourceManager.instance.AddSacrificeNumber();
                Destroy(gameObject);
                Instantiate(deathAudio);
                
            }
            Collider2D collider = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if(collider != null && currentResource == null)
            {
                currentResource = collider.GetComponent<Resource>();
            }
            else
            {
                currentResource = null;
            }

            if(currentResource != null)
            {
                if(Time.time > nextCollectTime)
                {
                    CollectResource();
                    nextCollectTime = Time.time + timeBetweenCollect;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        pickAudio.Play();
        isSelected = true;

    }

    private void OnMouseUp()
    {
        isSelected = false;
    }

    private void CollectResource()
    {
        currentResource.resourceAmount -= collectionAmount;
        ResourceManager.instance.AddResource(currentResource.resourceType, collectionAmount);
        Instantiate(resourcePopUp, transform.position, Quaternion.identity);
        Debug.Log("Resource: " + currentResource.resourceType + " Amount: " + currentResource.resourceAmount + " Collected: " + collectionAmount);
        Debug.Log ("Wood: " + ResourceManager.instance.wood + " Crystal: " + ResourceManager.instance.crystal + " Blood: " + ResourceManager.instance.blood);
    } 
}
