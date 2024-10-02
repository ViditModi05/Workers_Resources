using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject buildEffects;
    [SerializeField] GameObject buildSound;
    private Animator camAnimator;

    private void Start()
    {
        camAnimator = Camera.main.GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0))
        {
            camAnimator.SetTrigger("shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Instantiate(buildEffects, transform.position, Quaternion.identity);
            Instantiate(buildSound);
            Destroy(gameObject);
        }
        
    }

}
