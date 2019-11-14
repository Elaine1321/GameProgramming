using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits =16f;

    Vector2 paddlePosition;
    // Start is called before the first frame update
    void Start()
    {
        //set the paddle position to its starting position
         paddlePosition = new Vector2 (transform.position.x, transform.position.y);
      
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos= Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //set the paddle position according to the mouse position
        float limitiMousePos = Mathf.Clamp(mousePos,1f, 15f);
        paddlePosition= new Vector2(limitiMousePos, transform.position.y);
        
        transform.position = paddlePosition;
        
    }
}
