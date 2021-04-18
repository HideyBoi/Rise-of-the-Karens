using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class product : MonoBehaviour
{

    public bool isPlayerNear;
    public bool showPopUp;

    public GameObject popUpInfo;
    public GameObject Player;
    public SpriteRenderer sprite;
    public Transform spriteGameO;

    public Transform playerHand;

    public playerMovement PlayerMovement;
    public bool canHold;


    
    void Awake()
    {
        GameObject hand = GameObject.Find("Player Hand");
        playerHand = hand.transform;
        Player = GameObject.Find("Player");
        spriteGameO = transform.Find("Sprite");
        sprite = spriteGameO.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isPlayerNear)
        {
            if (showPopUp)
            {
                popUpInfo.SetActive(true);
            } else
            {
                popUpInfo.SetActive(false);
            }
   
        } else
        {
            popUpInfo.SetActive(false);
        }

        
        if(Input.GetButtonDown("Fire1") && isPlayerNear)
        {
            if(PlayerMovement.holding != 1)
            {
                canHold = true;
                PlayerMovement.holding++;
            } else
            {
                canHold = false;
            }
        }
        
        if(Input.GetButton("Fire1") && canHold)
        {
            if (PlayerMovement.holding == 1)
            {
                transform.position = playerHand.position;
                showPopUp = false;
                
            }
            
        }
        if(Input.GetButtonUp("Fire1") && !showPopUp)
        {
            showPopUp = true;
            canHold = false;
            PlayerMovement.holding = PlayerMovement.holding - 1f;
        }
        if(Player.transform.position.y > transform.position.y)
        {
            sprite.sortingOrder = 11;
        } else
        {
            sprite.sortingOrder = 9;
        }

    }

    void OnDestroy()
    {
        if(canHold)
        {
            PlayerMovement.holding = 0;
        }
    }


}
