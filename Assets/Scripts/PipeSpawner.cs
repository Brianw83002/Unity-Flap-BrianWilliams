using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;     //refers to the pipe
    private float timer = 0;
    public LogicScript logic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //spawns a pip when started
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return; // pause check

        float spawnRate = logic.spawnRate; 
        //Spawn pipe when timer hits the spawnrate
        if (timer < spawnRate)
        {
           timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float heightOffset = 10;
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;

        //gets a random Y position
        float randomY = Random.Range(minHeight, maxHeight);

        //Create a vector3 for so Instatiant() knows where to be 
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);


        Instantiate(pipe, spawnPosition, transform.rotation);
    }
}
