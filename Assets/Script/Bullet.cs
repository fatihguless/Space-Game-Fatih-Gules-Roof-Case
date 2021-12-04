using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private float BulletSpeed;
    [SerializeField]private Rigidbody2D _bulletRb;

  
     public static Bullet instance;


    void Start()
    {
       if(instance==null)
       {
          instance=this;
       }


        _bulletRb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       _bulletRb.velocity=Vector2.up*BulletSpeed;

     
       }
       
    



    private void OnTriggerEnter2D(Collider2D obj)
    {
         if(obj.gameObject.tag=="TopWall")
         {
                gameObject.SetActive(false);
         }

           if(obj.gameObject.tag=="Enemy")
         {
            
           if(PowerBullet.instance.PowerBulletBool)
           {
                 gameObject.SetActive(true);
           }

           else
           {
gameObject.SetActive(false);
           }

            Enemies.instance.KillingEnemy();
            GameManager.instance.KilledEnemySound.Play();
            Destroy(obj.gameObject);
               
                
         }

    }

     

}





