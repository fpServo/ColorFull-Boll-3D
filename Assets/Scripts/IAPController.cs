using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;

public class IAPController : MonoBehaviour, IStoreListener
{
    public UiManager uimanager;
    public Sound sounds;
    IStoreController controller;

    public string[] product;

    public void Start()
    {
        IAPStart();
    }

    public void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (string item in product)
        {
            builder.AddProduct(item, ProductType.Consumable);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Failed initiliaze");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchuase failed");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, product[0], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 2500);
            uimanager.CoinTextUpdate();
            sounds.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[1], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5000);
            uimanager.CoinTextUpdate();
            sounds.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 10000);
            uimanager.CoinTextUpdate();
            sounds.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[3], StringComparison.Ordinal))
        {
            if (PlayerPrefs.HasKey("NoAds") == true)
            {
                PlayerPrefs.SetInt("NoAds", 1);
                uimanager.NoAdsRemove();
                sounds.CashSound();
            }
            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }

    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if (product != null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else
            Debug.Log("Not Buying");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }
}

    //Consumble
    //Non-Consumble