using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject, 2f);
            Destroy(collision.gameObject, 2f);
            Debug.Log("122");
        }
    }
}
