using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishJuice : MonoBehaviour
{
    public GameObject Menu;
    public string NextLevelScene;

    private float finishtimer = 3f;

    int WaterNumber;

    public int GiveShoot;
    public int GiveUpgrade;
    public int GiveChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            WaterNumber++;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            finishtimer -= Time.deltaTime;
            if (finishtimer < 0)
            {
                Menu.SetActive(true);

                

                Time.timeScale = 0;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            if (WaterNumber >0)
            {
                WaterNumber--;
            }
            if (WaterNumber <=0)
            {
                finishtimer = 3f;
            }
            
        }
    }

    public void NextLevel()
    {
        CompleteLevel();    
        int a = PlayerPrefs.GetInt("Upgrade");
        int b = PlayerPrefs.GetInt("Shoot");
        int c = PlayerPrefs.GetInt("Change");
        PlayerPrefs.SetInt("Upgrade", a + GiveUpgrade);
        PlayerPrefs.SetInt("Shoot", b + GiveShoot);
        PlayerPrefs.SetInt("Change", c + GiveChange);
        Time.timeScale = 1;
        SceneManager.LoadScene(NextLevelScene);
    }
    public void CompleteLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("SavedLevel", nextLevel);



    }
}
