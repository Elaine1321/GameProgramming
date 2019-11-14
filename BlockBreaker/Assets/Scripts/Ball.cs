using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle myPaddle;
    
    //array of Sounds declaration
    [SerializeField] AudioClip [] ballSounds;
    
    Vector2 paddleToBallDistance;

    bool hasStarted= false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false) //(hasStarted == false)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        int randomNumber = UnityEngine.Random.Range(0, ballSounds.Length);

        AudioClip clip = ballSounds[randomNumber];

        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))//left click
        {
            hasStarted= true;
            //shoot the ball
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,15f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition= myPaddle.transform.position;
        //set position of the ball to the paddle position + distance
        this.transform.position= paddlePosition + paddleToBallDistance;
    }
}
