using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBullet : MonoBehaviour
{
    

     public static ObjectPoolBullet instance;

     [SerializeField]private List<GameObject> pooledBulletObject=new List<GameObject>();
     [SerializeField]private int BulletToPool=20;
     [SerializeField]private GameObject bulletPrefabs;



    void Start()
    {

 if(instance==null)
        {
        instance=this;
        }

        
        for(int i=0; i<BulletToPool;i++)
        {
             GameObject objbullet=Instantiate(bulletPrefabs);
             objbullet.SetActive(false);
             pooledBulletObject.Add(objbullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public GameObject GetPooledObject()
     {
for(int i=0; i<pooledBulletObject.Count;i++)
        {
            if(!pooledBulletObject[i].activeInHierarchy)
            {
               return pooledBulletObject[i];
            }
        }


          return null;


     }


}
