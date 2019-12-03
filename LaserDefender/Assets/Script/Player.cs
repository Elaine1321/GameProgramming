using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour

{
[SerializeField] GameObject playerLaser;
[SerializeField] float movementSpeed = 10f;
[SerializeField] float laserSpeed = 10f;
[SerializeField] float laserSpawnTime = 1f;

Coroutine fireCoroutine;

float xMin , xMax, yMin , yMax;

float padding= 0.5f;
Slider healthSlider;
TextMeshProUGUI healthText;
int PlayerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
        SetupHealth();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void SetupHealth()
    {
        healthText = GameObject.Find("HealthPoint").GetComponent<TextMeshProUGUI>();
        healthSlider = GameObject.FindObjectOfType<Slider>();
        healthText.text=PlayerHealth.ToString();
        healthSlider.value = PlayerHealth;
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

    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y+padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y-padding;
    }

    private void UpdateHealth()
    {
        healthSlider = GameObject.FindObjectOfType<Slider>();
        healthSlider.value = PlayerHealth;
    }

    private void OnTriggeredEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "enemyLaser")
        {
            PlayerHealth -=10;
            UpdateHealth();
            Destroy(collider.gameObject);

            if (PlayerHealth <= 0){

                SceneManager.LoadScene("LoseScene");
            }
        }
    }

    private void Fire()
    {
        //if mouse is clicked
        if (Input.GetButtonDown("Fire1"))
         {
             fireCoroutine = StartCoroutine(FireContinuously());
         }
            
      

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
 
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject laser =Instantiate(playerLaser, transform.position,transform.rotation); 
            laser.GetComponent<Rigidbody2D>().velocity =new Vector2(0,laserSpeed);
            yield return new WaitForSeconds(laserSpawnTime);
        }
        
    }
}