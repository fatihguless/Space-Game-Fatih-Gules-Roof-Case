using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
{
     public bool PowerBulletBool;
     public int amountPower=1;
     public AudioSource PowerBulletSound;
    
    public static PowerBullet instance;
//Press F powerbullet on
    void Start()
    {
        if(instance==null)
        {
           instance=this;
        }
    }

public void Update()
{
    if(PowerBulletBool)
    {
        StartCoroutine( PowerBulletSet() );
    }

}


public void PowerBulletOn()
{

       PowerBulletBool=true;
       amountPower--;
       PowerBulletSound.Play();

}


 

private IEnumerator PowerBulletSet()
{

  PowerBulletBool = true;  
    yield return new WaitForSeconds( 1.0f );
    PowerBulletBool = false;
    
}
}
