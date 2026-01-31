using UnityEngine;

public class penisScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool playerAlive = true;

    //Kills player if position = these bounds
    int upperBound =  24;
    int lowerBound = -23;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If SPACE is pressed jump
        if (Input.GetKeyDown(KeyCode.Space) == true && playerAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        //Checks if Player is too high or too low, Ends game if too high
        if (transform.position.y >= upperBound || transform.position.y <= lowerBound)
        {
            // End the game
            playerAlive = false;
            logic.gameOver();
            playerAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        playerAlive = false;
    }




}