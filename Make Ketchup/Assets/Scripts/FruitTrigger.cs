using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class FruitTrigger : MonoBehaviour
{
    public GameObject UpgradeObject;
    public bool MaxFruit;
    public float scaleDuration = 1f;

    public AudioSource FruitToJuice;

    public AudioSource DropFruit;
    public bool DropFruitBool = true;

    public AudioSource FruitTriggerAus;
    public AudioClip[] FruitTriggerClip;
    int FruitTriggerNumber;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DropFruitBool)
        {
            DropFruit.Play();
           
            DropFruitBool = false;
        }
        if (this.gameObject.tag == collision.gameObject.tag)
        {
            

            if (FirstObject(collision.gameObject))//çarpan ilk objeyse
            {
                
                Vector3 a;
                
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    a = gameObject.transform.position;
                    gameObject.GetComponent<SpriteBreaker>().Break();
                    gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;

                if (MaxFruit)
                {
                    
                    Instantiate(UpgradeObject, a, Quaternion.identity);
                    FruitToJuice.Play();
                }
                else
                {
                   
                    GameObject instance = Instantiate(UpgradeObject, a, Quaternion.identity);
                    instance.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

                    instance.GetComponent<FruitTrigger>().DropFruitBool = false;
                    instance.GetComponent<FruitTrigger>().TriggerVoice();

                    StartCoroutine(ScaleUp(instance, Vector3.zero, Vector3.one, scaleDuration));

                    
                    
                }
                

            }
            else
            {
                
                Destroy(this.gameObject);
            }
           
            

        }
    }
    bool FirstObject(GameObject other)
    {
        var rb =GetComponent<Rigidbody2D>();
        var OtherRb = other.GetComponent<Rigidbody2D>();

        return gameObject.GetInstanceID() < other.gameObject.GetInstanceID();
        

  
        
        
    }
    IEnumerator ScaleUp(GameObject instance, Vector3 initialScale, Vector3 targetScale, float duration)
    {
        float elapsedTime = 0f;
        instance.transform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            if (instance != null)
            {
                instance.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
                yield return null; // Bir frame bekle

            }
            
        }

        if (instance != null)
        {
            instance.transform.localScale = targetScale; // Son durumda scale'i tam olarak 1 yap
        }
        
    }
    public void UpgradeFruits()
    {
        Vector3 a;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        gameObject.GetComponent<SpriteBreaker>().Break();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        a = gameObject.transform.position;

        if (MaxFruit)
        {
            Instantiate(UpgradeObject, a, Quaternion.identity);
        }
        else
        {

            GameObject instance = Instantiate(UpgradeObject, a, Quaternion.identity);    
            instance.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

            StartCoroutine(ScaleUp(instance, Vector3.zero, Vector3.one, scaleDuration));
        }
    }

    public void TriggerVoice()
    {
        FruitTriggerNumber = Random.Range(0, FruitTriggerClip.Length);
        FruitTriggerAus.clip = FruitTriggerClip[FruitTriggerNumber];
        FruitTriggerAus.Play();
 
    }

}
