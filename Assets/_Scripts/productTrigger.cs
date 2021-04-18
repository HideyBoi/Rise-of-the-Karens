using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productTrigger : MonoBehaviour
{
    
    public product Item;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Player can pickup this product");
            Item.isPlayerNear = true;
            playerMovement pm = other.GetComponent<playerMovement>();

            if (pm != null)
            {
                Item.PlayerMovement = pm;
            }
        }
        
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Player can't pickup this product");
        Item.isPlayerNear = false;
    }

}
