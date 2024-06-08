using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAnim : MonoBehaviour
{
    public Animator animation;
    public AnimationClip[] animationclip;
    private float timer;
    int a;
    
    void Start()
    {
        timer = Random.Range(0, 4);
        a = Random.Range(0, animationclip.Length);
    }

    // Update is called once per frame
    void Update()
    { 
        
        timer -= Time.deltaTime;
        if (timer < 0  )
        {
            for (int i = 0; i < animationclip.Length; i++)
            {
                if (animation.GetCurrentAnimatorStateInfo(0).IsName(animationclip[i].name))
                {
                    //Eski Anim Oynatýlýyor
                    timer = Random.Range(8, 12);
                }
                else
                {
                    animation.Play(animationclip[a].name);


                    a = Random.Range(0, animationclip.Length);
                    timer = Random.Range(8, 12);
                  
                    //Yeni Anim Oynatýldý
                   
                }
            }
           
        }
        
    }

    
}
