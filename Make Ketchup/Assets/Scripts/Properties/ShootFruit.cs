using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootFruit : MonoBehaviour
{
    
    public bool canDestroy = false;
    private int ShootNumber =1;

    public GameObject Menu;
    public Camera cam;

    public Rewarded RewardedAds;

    public TextMeshProUGUI NumberText;
    public Image WatchadsImage;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Shoot"))
        {
            PlayerPrefs.SetInt("Shoot", 1);
            WatchadsImage.gameObject.SetActive(false);
            NumberText.gameObject.SetActive(true);
            NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("Shoot") > 0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
                NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();
            }
            else
            {
                WatchadsImage.gameObject.SetActive(true);
                NumberText.gameObject.SetActive(false);

            }
        }

    }
    public void ShootButton()
    {

        if (PlayerPrefs.GetInt("Shoot") > 0)
        {
            canDestroy = true;
            Menu.SetActive(true);
        }
        else
        {
            RewardedAds.ShowRewardedAd();
            NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();
            if (PlayerPrefs.GetInt("Shoot") > 0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
            }

        }

    }

    void Update()
    {
        if (canDestroy && Input.GetMouseButtonDown(0))
        {
            int layer9 = 9; // Layer 9
            int layerMask = 1 << layer9;

            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null && hit.collider.gameObject.layer == 9)
            {
                int a = PlayerPrefs.GetInt("Shoot");

                PlayerPrefs.SetInt("Shoot", a - 1);

                Destroy(hit.collider.gameObject);
                
                canDestroy = false;
                Menu.SetActive(false);

                if (PlayerPrefs.GetInt("Shoot") <= 0)
                {
                    WatchadsImage.gameObject.SetActive(true);
                    NumberText.gameObject.SetActive(false);
                }

                NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();

            }
            else
            {
                canDestroy = false;
                Menu.SetActive(false);

            }
        }
    }
}
