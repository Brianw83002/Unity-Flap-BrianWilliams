using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    float DeadZone = -60;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePipe();
        if (transform.position.x < DeadZone)
        {
            Destroy(gameObject);
        }
    }

    void movePipe()
    {
        //moves Pipes to the left of the screen @ moveSpeed. deltatime so it moves at time rather than fps
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
