using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject blood;
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minX, maxX, minY, maxY;
    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = GetRandomPosition();
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
            Destroy(collider.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
