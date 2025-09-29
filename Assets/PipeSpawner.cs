using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;     //refers to the pipe
    public float spawnRate = 4; //timer counts to spawn rate, then spawns. (Lower number means faster spawn)
    private float timer = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawns a pip when started
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn pipe when timer hits the spawnrate
        if(timer < spawnRate)
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
