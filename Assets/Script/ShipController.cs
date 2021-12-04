using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private float ShipSpeed;
    [SerializeField]private float ScreenLimits=7.99f;
    [SerializeField]private Transform bulletPosition;
    [SerializeField]private AudioSource bulletSound;
    private float FireRate=0.4f;
    private float NextFire=0.0f;
   
    
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ShipShoot();
        PowerShoot();
    }



    private void PowerShoot()
    {
         if(Input.GetKeyDown(KeyCode.F))
         {
             if(PowerBullet.instance.amountPower>0)
    {
             PowerBullet.instance.PowerBulletOn();
           GameObject bullet=ObjectPoolBullet.instance.GetPooledObject();
        if(bullet!=null)
        {
            bullet.transform.position=bulletPosition.position;
            bullet.SetActive(true);
            bulletSound.Play();
        }
           
         }
     }
    }


    private void ShipShoot()
    {
      
       if(Input.GetKeyDown(KeyCode.Space)&&Time.time>NextFire)
       {
        NextFire=Time.time+FireRate;
       
        GameObject bullet=ObjectPoolBullet.instance.GetPooledObject();
        if(bullet!=null)
        {
            bullet.transform.position=bulletPosition.position;
            bullet.SetActive(true);
            bulletSound.Play();
        }
        //Debug.Log("Ateş Algılandı");
       }
    }






   
    private void Movement()
    {
      
      
      Vector3 position=transform.position;
      
     
      float inputh=Input.GetAxis("Horizontal");
     
      position.x+=inputh*Time.deltaTime*ShipSpeed;

    
       position.x=Mathf.Clamp(position.x,-ScreenLimits,ScreenLimits);


      transform.position=position;

    }



     void OnTriggerEnter2D(Collider2D obj)
    {
    
           if(obj.gameObject.tag=="Enemy")
         {
                GameManager.instance.GameOverSt();

                Destroy(gameObject);
               
                
         }

    }




}
