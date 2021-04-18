using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt;

public class itemAccept : MonoBehaviour
{
    #region

    public float RNG;
    public GameObject productPrefab;
    public GameObject spawn;
    public string Tag;
    public string productName;
    public GameObject ratings;
    public ratingManager rm;
    public GameObject wrongEffectPrefab;
    public GameObject correctEffectPrefab;
    public float KarenCurrent;
    public float KarenNew;

    #endregion

    #region
    public string product0Tag;
    public string p0Spawner;
    public string product0Name;
    public GameObject prefab0;
    public GameObject product0spawn;
    public string product1Tag;
    public string p1Spawner;
    public string product1Name;
    public GameObject prefab1;
    public GameObject product1spawn;
    public string product2Tag;
    public string p2Spawner;
    public string product2Name;
    public GameObject prefab2;
    public GameObject product2spawn;
    public string product3Tag;
    public string p3Spawner;
    public string product3Name;
    public GameObject prefab3;
    public GameObject product3spawn;
    public string product4Tag;
    public string p4Spawner;
    public string product4Name;
    public GameObject prefab4;
    public GameObject product4spawn;
    public string product5Tag;
    public string p5Spawner;
    public string product5Name;
    public GameObject prefab5;
    public GameObject product5spawn;
    public string product6Tag;
    public string p6Spawner;
    public string product6Name;
    public GameObject prefab6;
    public GameObject product6spawn;
    public string product7Tag;
    public string p7Spawner;
    public string product7Name;
    public GameObject prefab7;
    public GameObject product7spawn;
    public string product8Tag;
    public string p8Spawner;
    public string product8Name;
    public GameObject prefab8;
    public GameObject product8spawn;
    public string product9Tag;
    public string p9Spawner;
    public string product9Name;
    public GameObject prefab9;
    public GameObject product9spawn;
    #endregion

    void Awake()
    {
        ratings = GameObject.Find("Rating Manager");
        rm = ratings.GetComponent<ratingManager>();
        
    
        RNG = Random.Range(0, 10);

        #region

        product0spawn = GameObject.Find(p0Spawner);
        product1spawn = GameObject.Find(p1Spawner);
        product2spawn = GameObject.Find(p2Spawner);
        product3spawn = GameObject.Find(p3Spawner);
        product4spawn = GameObject.Find(p4Spawner);
        product5spawn = GameObject.Find(p5Spawner);
        product6spawn = GameObject.Find(p6Spawner);
        product7spawn = GameObject.Find(p7Spawner);
        product8spawn = GameObject.Find(p8Spawner);
        product9spawn = GameObject.Find(p9Spawner);

        #endregion

        #region

        if (RNG == 0)
        {
            Tag = product0Tag;
            productPrefab = prefab0;
            productName = product0Name;
            spawn = product0spawn;
        }
        if(RNG == 1)
        {
            Tag = product1Tag;
            productPrefab = prefab1;
            productName = product1Name;
            spawn = product1spawn;
        }
        if(RNG == 2)
        {
            Tag = product2Tag;
            productPrefab = prefab2;
            productName = product2Name;
            spawn = product2spawn;
        }
        if(RNG == 3)
        {
            Tag = product3Tag;
            productPrefab = prefab3;
            productName = product3Name;
            spawn = product3spawn;
        }
        if(RNG == 4)
        {
            Tag = product4Tag;
            productPrefab = prefab4;
            productName = product4Name;
            spawn = product4spawn;
        }
        if(RNG == 5)
        {
            Tag = product5Tag;
            productPrefab = prefab5;
            productName = product5Name;
            spawn = product5spawn;
        }
        if(RNG == 6)
        {
            Tag = product6Tag;
            productPrefab = prefab6;
            productName = product6Name;
            spawn = product6spawn;
        }
        if(RNG == 7)
        {
            Tag = product7Tag;
            productPrefab = prefab7;
            productName = product7Name;
            spawn = product7spawn;
        }
        if(RNG == 8)
        {
            Tag = product8Tag;
            productPrefab = prefab8;
            productName = product8Name;
            spawn = product8spawn;
        }
        if(RNG == 9)
        {
            Tag = product9Tag;
            productPrefab = prefab9;
            productName = product9Name;
            spawn = product9spawn;
        }

        #endregion
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(Tag))
        {
            Debug.Log("Product collected");
            Instantiate(productPrefab, spawn.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            rm.rating = rm.rating + 1;
            rm.score = rm.score + 1f;
            Instantiate(correctEffectPrefab, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
            
        } else
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Enviroment") && !other.CompareTag("PickupTrigger") && !other.CompareTag("Karen"))
            {
                Debug.Log("Wrong product");
                Destroy(other.gameObject);
                rm.rating = rm.rating - 2;
                Instantiate(wrongEffectPrefab, transform.position, transform.rotation);

                #region

                if (other.CompareTag(product0Tag))
                {
                    Instantiate(prefab0, product0spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product1Tag))
                {
                    Instantiate(prefab1, product1spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product2Tag))
                {
                    Instantiate(prefab2, product2spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product3Tag))
                {
                    Instantiate(prefab3, product3spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product4Tag))
                {
                    Instantiate(prefab4, product4spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product5Tag))
                {
                    Instantiate(prefab5, product5spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product6Tag))
                {
                    Instantiate(prefab6, product6spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product7Tag))
                {
                    Instantiate(prefab7, product7spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product8Tag))
                {
                    Instantiate(prefab0, product0spawn.transform.position, Quaternion.identity);
                }

                if (other.CompareTag(product9Tag))
                {
                    Instantiate(prefab9, product9spawn.transform.position, Quaternion.identity);
                }

                #endregion

                Destroy(transform.parent.gameObject);
            }
        }
    }

    public void wrongProduct()
    {
        Debug.Log("Times up!");
        rm.rating = rm.rating - 2;
        Instantiate(wrongEffectPrefab, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }

    

}