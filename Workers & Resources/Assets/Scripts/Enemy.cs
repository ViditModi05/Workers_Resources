using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject blood;
    [SerializeField] private LayerMask resourceLayer;
    //[SerializeField] private GameObject deathAudio;
    private Animator camAnimator;
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minX, maxX, minY, maxY;
    private Vector3 currentTarget;
    private int amountOfResourcesDestroyed;

    private void Start()
    {
        //deathAudio = blood.GetComponent<AudioSource>();
        currentTarget = GetRandomPosition();
        camAnimator = Camera.main.GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
           transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
           currentTarget = GetRandomPosition();    
        }
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.2f, resourceLayer);
        if(collider != null && amountOfResourcesDestroyed == 0)
        {
            Destroy(collider.gameObject);
            amountOfResourcesDestroyed++;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPosition; //Calculating a random position and returning it 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(collider.tag == "Trap")
        {
            camAnimator.SetTrigger("shake");
            Destroy(collider.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            //Instantiate(deathAudio, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(collider.tag == "Human")
        {
            Destroy(collider.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            //Instantiate(deathAudio,transform.position,Quaternion.identity);
        }
    }
}
