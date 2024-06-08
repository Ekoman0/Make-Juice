using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFruit : MonoBehaviour
{
    public GameObject Menu;
    public string NextLevelScene;

    private float finishtimer = 2f;

    int FruitNumber;

    private List<GameObject> collidingFruits = new List<GameObject>();

    public bool isFinishFruit;

    public Rewarded Reward;

    private void Update()
    {
        if (isFinishFruit)
        {
            if (FruitNumber >0)
            {
                finishtimer -= Time.deltaTime;
                if (finishtimer < 0)
                {
                    if (isFinishFruit)
                    {

                        Menu.SetActive(true);
                        finishtimer = 3f;
                        Time.timeScale = 0;
                    }

                }
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (isFinishFruit)
            {
                FruitNumber++;
            }
            else
            {
                collidingFruits.Add(collision.gameObject);
            }
            
           
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.gameObject.layer == 9)
        {
            finishtimer -= Time.deltaTime;
            if (finishtimer < 0)
            {
                if (isFinishFruit)
                {

                    Menu.SetActive(true);
                    finishtimer = 3f;
                    Time.timeScale = 0;
                }
                
            }

        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (isFinishFruit)
            {
                if (FruitNumber > 0)
                {
                    FruitNumber--;
                  
                }
                if (FruitNumber <= 0)
                {
                    finishtimer = 2f;
                }
            }
            else
            {
                collidingFruits.Remove(collision.gameObject);

            }
           

        }
    }

    public void TryAgainLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NextLevelScene);
    }

    public void WatchAdsLevel()
    {
        
        DestroyFruits();

        Time.timeScale = 1;
       
        Menu.SetActive(false);
    }
    public void WatchAdsButton()
    {
        Reward.ShowAgainRewardedAd();
    }
    public void DestroyFruits()
    {
        
        for (int i = 0; i < collidingFruits.Count;)
        {
            
            Destroy(collidingFruits[i]);
        }
    }
}
