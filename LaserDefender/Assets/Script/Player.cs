using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

[SerializeField] float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private float MoveX()
    {
         //get the movement on the x-axis
        float deltaX =Input.GetAxis("Horizontal")* Time.deltaTime * movementSpeed;
        //set the x pos to the current position + deltaX
        float newXPos = transform.position.x + deltaX;

        return newXPos;

    }
    private float MoveY()
    {
           //get the movement on the y-axis
        var deltaY =Input.GetAxis("Vertical")* Time.deltaTime * movementSpeed;
        //set the Y pos to the current position + deltaX
        var newYPos = transform.position.y + deltaY;

        return newYPos;
    }
    
    
    private void Move()
    {
        //update player position
        transform.position = new Vector2(MoveX(), MoveY());
    }
}