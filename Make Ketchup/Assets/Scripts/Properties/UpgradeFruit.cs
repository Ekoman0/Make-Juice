using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFruit : MonoBehaviour
{
    public bool canUpgrade= false;

    public GameObject Menu;
    public Camera cam;

    public Rewarded RewardedAds;

    public TextMeshProUGUI NumberText;
    public Image WatchadsImage;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Upgrade"))
        {
            PlayerPrefs.SetInt("Upgrade", 1);
            WatchadsImage.gameObject.SetActive(false);
            NumberText.gameObject.SetActive(true);
            NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("Upgrade")>0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
                NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();
            }
            else
            {
                    WatchadsImage.gameObject.SetActive(true );
                    NumberText.gameObject.SetActive(false);

            }
        }
        
    }
    public void UpgradeButton()
    {
        if (PlayerPrefs.GetInt("Upgrade") > 0)
        {
            canUpgrade = true;
            Menu.SetActive(true);
        }
        else
        {
            RewardedAds.ShowUpgradeRewardedAd();
            NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();
            if (PlayerPrefs.GetInt("Upgrade") > 0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
            }

        }

    }

    void Update()
    {
        if (canUpgrade && Input.GetMouseButtonDown(0))
        {

            int layer9 = 9; // Layer 9
            int layerMask = 1 << layer9;

            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, Mathf.Infinity, layerMask);


            if (hit.collider != null && hit.collider.gameObject.layer == 9)
            {

                int a = PlayerPrefs.GetInt("Upgrade");

                PlayerPrefs.SetInt("Upgrade", a - 1);

                hit.collider.gameObject.GetComponent<FruitTrigger>().UpgradeFruits();
                canUpgrade = false;
                Menu.SetActive(false);

                if (PlayerPrefs.GetInt("Upgrade") <=0)
                {
                    WatchadsImage.gameObject.SetActive(true);
                    NumberText.gameObject.SetActive(false);  
                }

               NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();
            }
            else
            {
                canUpgrade = false;
                Menu.SetActive(false);
                
              
            }
        }
    }
}
