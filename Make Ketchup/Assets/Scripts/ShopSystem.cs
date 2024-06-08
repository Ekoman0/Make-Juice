using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShopSystem : MonoBehaviour
{
    public GameObject Shop;

    public void OpenShop() 
    {
        Shop.gameObject.SetActive(true);
        
    }
    public void CloseShop()
    {

        Shop.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            this.gameObject.SetActive(ClickingSelfOrChild());
        }
    }
    private bool ClickingSelfOrChild()
    {
        RectTransform[] rectTransforms = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform rectTransform in rectTransforms)
        {
            if (EventSystem.current.currentSelectedGameObject == rectTransform.gameObject)
            {
                return true;
            };
        }
        return false;
    }
}
