using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
   

}
