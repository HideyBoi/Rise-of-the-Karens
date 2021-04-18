using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameJolt;

public class ratingManager : MonoBehaviour
{
    public float rating;
    public GameObject notice;
    public float score;
    public float HighScore;
    public TextMeshProUGUI HS;
    public TextMeshProUGUI S;
    public float firedCurrent;
    public float firedNew;
    public float KarenCurrent;
    public float KarenNew;
    public float oldScore;
    public bool alreadyDone;
    public int karensServed;
    public bool karenTone;
    public bool karenTtwo;
    public bool karenTthree;
    public bool signedIn;

    
    void Awake()
    {
        signedIn = GameJolt.API.GameJoltAPI.Instance.CurrentUser != null;

        //HighScore = PlayerPrefs.GetFloat("HighS");
        GameJolt.API.DataStore.Get("HighS", false, (string value) => {
        if (value != null)
        {
            HighScore = float.Parse(value);
        }
        });
    }
    
    void Update()
    {
        if (rating >= 10)
        {
            rating = 10;
        }
    
        if(rating <= 0)
        {
            notice.SetActive(true);
            GameObject player = GameObject.Find("Player");
            Destroy(player);

            

            if (!alreadyDone && signedIn)
            {
                
                alreadyDone = true;

                
                GameJolt.API.DataStore.Get("fired", false, (string value) => {
                if (value != null)
                {
                    firedCurrent = float.Parse(value);
                }
                });
                firedNew = firedCurrent + 1;
                GameJolt.API.DataStore.Set("fired", firedNew.ToString(), false);

                if(firedNew >= 1)
                {
                    GameJolt.API.Trophies.TryUnlock(125483);
                }

                if(firedNew >= 50)
                {
                    GameJolt.API.Trophies.TryUnlock(125484);
                }

                if(firedNew >= 150)
                {
                    GameJolt.API.Trophies.TryUnlock(125485);
                }

                if(firedNew >= 250)
                {
                    GameJolt.API.Trophies.TryUnlock(125486);
                }
                
                string scorestring = karensServed.ToString() + " Karens Served!";

                GameJolt.API.Scores.Add(karensServed, scorestring, 525710);
            }
            
        }

        if (score >= HighScore)
        {
            HighScore = score;
            if (signedIn)
            {
                GameJolt.API.DataStore.Set("HighS", HighScore.ToString(), false);
            }

            //PlayerPrefs.SetFloat("HighS", HighScore);
        }

        HS.text = HighScore.ToString();
        S.text = score.ToString();

        #region 

        if (signedIn)
        {
            if (karensServed >= 50 && karenTone == false)
            {
                karenTone = true;
                GameJolt.API.Trophies.TryUnlock(125487);
            }

            if (karensServed >= 300 && karenTtwo == false)
            {
                karenTtwo = true;
                GameJolt.API.Trophies.TryUnlock(125488);
            }

            if (karensServed >= 500 && karenTthree == false)
            {
                karenTthree = true;
                GameJolt.API.Trophies.TryUnlock(125489);
            }
        }
        

        #endregion

        if(score > oldScore)
        {
            if (signedIn)
            {
                GameJolt.API.DataStore.Get("karensServed", false, (string value) => {
                    if (value != null)
                    {
                        KarenCurrent = float.Parse(value);
                    }
                });
                KarenNew = KarenCurrent + 1;
                GameJolt.API.DataStore.Set("karensServed", KarenNew.ToString(), false);
                karensServed++;
            }
            
            oldScore = score;
        }

    }

}
