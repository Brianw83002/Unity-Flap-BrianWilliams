using UnityEngine;

public class playScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool playerAlive = true;

    public AudioSource playerAudio;
    public AudioClip flapSound;

    //Kills player if position = these bounds
    int upperBound =  24;
    int lowerBound = -23;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio.clip = flapSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return; // pause check

        //If SPACE is pressed jump and play Audio
        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0)) && playerAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;

            playerAudio.Play(); //plays audio
        }

        //Ends the Game if player is too high or too low
        if (transform.position.y >= upperBound || transform.position.y <= lowerBound)
        {
            // End the game
            playerAlive = false;
            logic.gameOver();
            playerAlive = false;
        }

    }

    //If it collides with anything solid, end the game
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        playerAlive = false;
    }




}