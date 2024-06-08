using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Gold1000,
        Gold2000,
        Gold5000,
        Gold10000,
        Gold50000,
       
        NoAds
    }

    public ItemType itemType;

    
    void Start()
    {
        
        StartCoroutine(LoadPriceRoutine());
    }

   public void Clickbuy()
    {
        switch (itemType)
        {
            case ItemType.Gold1000:
               
                
                break;
            case ItemType.Gold2000:
            
              
                break;
            case ItemType.Gold5000:
               
               
                break;
            case ItemType.Gold10000:
                
                break;
            case ItemType.Gold50000:
               
                break;
            case ItemType.NoAds:

                break; 
        }
    }

   
    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
        {
            yield return null;
        }

        string loadedPrice = "";
        switch (itemType)
        {
            case ItemType.Gold1000:
               loadedPrice= IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.Gold_1000);
                break;
            case ItemType.Gold2000:
              loadedPrice=  IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.Gold_2000);
                break;
            case ItemType.Gold5000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.Gold_5000);
                break;
            case ItemType.Gold10000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.Gold_10000);
                break;
            case ItemType.Gold50000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.Gold_50000);
               
                break;
            case ItemType.NoAds:
               loadedPrice= IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.NO_ADS);
                break;

        }

       
    }
}
