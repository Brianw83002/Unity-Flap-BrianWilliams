using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    private float timer = 0;
    float spawnRate = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn pipe when timer hits the spawnrate
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            timer = 0;
        }
    }

    void spawnCloud()
    {
        float heightOffset = 10;
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;

        //gets a random Y position
        float randomY = Random.Range(minHeight, maxHeight);

        //Create a vector3 for so Instatiant() knows where to be 
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 10);


        Instantiate(cloud, spawnPosition, transform.rotation);
    }
}
