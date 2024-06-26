﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
using TMPro;

public class IAPManager :MonoBehaviour,IStoreListener
{
    public static IAPManager Instance;
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

   
    public  string Gold_1000 = "gold_1000";
    public  string Gold_2000 = "gold_2000";
    public string Gold_5000 = "gold_5000";
    public string Gold_10000 = "gold_10000";
    public string Gold_50000 = "gold_50000";
   
    public  string NO_ADS = "no_ads";

    public ShootFruit ShootF;
    public UpgradeFruit UpgradeF;
    public ChangeFruit ChangeF;


    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
       
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();

        }
              
    }

    public void InitializePurchasing()
    {

        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
           
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add a product to sell / restore by way of its identifier, associating the general identifier
        // with its store-specific identifiers.
        builder.AddProduct(Gold_1000, ProductType.Consumable);
       
        builder.AddProduct(Gold_2000, ProductType.Consumable);
        builder.AddProduct(Gold_5000, ProductType.Consumable);
        builder.AddProduct(Gold_10000, ProductType.Consumable);
        builder.AddProduct(Gold_50000, ProductType.Consumable);

        // Continue adding the non-consumable product.
        builder.AddProduct(NO_ADS, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }


    public bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void Buy1000Gold()
    {
       
        BuyProductID(Gold_1000);
    }
    public void Buy2000Gold()
    {

        BuyProductID(Gold_2000);
    }
    public void Buy5000Gold()
    {

        BuyProductID(Gold_5000);
    }
    public void Buy10000Gold()
    {

        BuyProductID(Gold_10000);
    }
    public void Buy50000Gold()
    {

        BuyProductID(Gold_50000);
    }

    public void BuyNoAds()
    {
        BuyProductID(NO_ADS);
    }

    public string GetProductPriceFromStore(string id)
    {
        if (m_StoreController!=null && m_StoreController.products!=null)
        {
            return m_StoreController.products.WithID(id).metadata.localizedPriceString;

        }
        else
        {
            return ""; 
        }
    }



    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }


    //  
    // --- IStoreListener
    //

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public void OnInitializeFailed(InitializationFailureReason error,string? message)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, Gold_1000, StringComparison.Ordinal))
        {
           

            int money = PlayerPrefs.GetInt("Shoot");

            PlayerPrefs.SetInt("Shoot", money+ 5);

            ShootF.NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();
            ShootF.NumberText.gameObject.SetActive(true);
            ShootF.WatchadsImage.gameObject.SetActive(false);
            return PurchaseProcessingResult.Complete;



        }
        else if (String.Equals(args.purchasedProduct.definition.id, Gold_2000, StringComparison.Ordinal))
        {
            

            int money = PlayerPrefs.GetInt("Upgrade");

            PlayerPrefs.SetInt("Upgrade", money + 5);
            UpgradeF.NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();

            UpgradeF.NumberText.gameObject.SetActive(true);
            UpgradeF.WatchadsImage.gameObject.SetActive(false);
            return PurchaseProcessingResult.Complete;


        }
       
        else if (String.Equals(args.purchasedProduct.definition.id, Gold_5000, StringComparison.Ordinal))
        {

           
            int money = PlayerPrefs.GetInt("Change");

            PlayerPrefs.SetInt("Change", money + 5 );
            ChangeF.NumberText.text = PlayerPrefs.GetInt("Change").ToString();

            ChangeF.NumberText.gameObject.SetActive(true);
            ChangeF.WatchadsImage.gameObject.SetActive(false);
            return PurchaseProcessingResult.Complete;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, Gold_10000, StringComparison.Ordinal))
        {
           
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Gold_50000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            return PurchaseProcessingResult.Complete;
        }
        // Or ... a non-consumable product has been purchased by this user.
        else if (String.Equals(args.purchasedProduct.definition.id, NO_ADS, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("Ads", 1);

            return PurchaseProcessingResult.Complete;
        }
        // Or ... a subscription product has been purchased by this user.
       
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            return PurchaseProcessingResult.Complete;
        }

            return PurchaseProcessingResult.Complete;

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        

    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
