using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Game over!!");
    }
   
}
