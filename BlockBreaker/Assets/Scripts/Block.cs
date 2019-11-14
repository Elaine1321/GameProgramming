using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    [SerializeField] int maxHits;
    [SerializeField] int currentHits =0;

    [SerializeField] Sprite[] hitSprites;


    Level level;

    


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(gameObject.tag=="Breakable")
        {
            level.CountBreakableBlocks();
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         
         
         if (gameObject.tag =="Breakable")
         { 
             currentHits++;
             

             if(currentHits >= maxHits)
             {  
                 FindObjectOfType<GameStatus>().AddToScore();
         
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                  level.BlockDestroyed();

                Destroy(this.gameObject);

                 TriggerSparklesVFX();

             }
             else
             {
                 ShowNextHitSprite();
             }

           
         }
        
    }
    

    private void TriggerSparklesVFX()
    {
        //create sparkles at the position and rotation of the current block
        GameObject sparkles =Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    }


    private void ShowNextHitSprite()
    {
        int spriteIndex=currentHits -1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
