using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] EnemyShip;

    public int row;
    public int columm;


    public float movementSpeed;
    private Vector3 direct=Vector2.right;

    public int TotalEnemy => this.row*this.columm;
    public int KilledEnemy;

    public static Enemies instance;

    

    void Start()
    {

        if(instance==null)
        {
           instance=this;
        }
        

         for(int rows=0; rows<this.row;rows++)
        {
                float width=1.5f*(this.columm-1);
                float height=1.5f*(this.row-1);
                Vector2 center=new Vector2(-width/2,-height/2);
            Vector3 rowPosition=new Vector3(center.x,center.y+(rows*1.5f),0.0f);
              for(int col=0; col<this.columm;col++)
        {
            GameObject enemyShip= Instantiate(this.EnemyShip[rows],this.transform);
            Vector3 position=rowPosition;
            position.x+=col*1.5f;
            enemyShip.transform.localPosition=position;
        }


        }
    }


    void Update()
    {
        //Right move
        this.transform.position+=direct*this.movementSpeed*Time.deltaTime;

            Vector3 SolKenar=Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 SagKenar=Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform enemy in this.transform)
        {
           

           if(!enemy.gameObject.activeInHierarchy)
           {
               continue;
           }

           if(direct==Vector3.right&& enemy.position.x >= (SagKenar.x-1))
           {
          GooEnemyGoo();
           }
           else if(direct==Vector3.left&& enemy.position.x <= (SolKenar.x+1))
           {
          GooEnemyGoo();
           }
        }
    }


    private void GooEnemyGoo()
    {
        direct.x*=-1.0f;

        Vector3 position=this.transform.position;
        position.y-=1f;
        this.transform.position=position;
    }

    public void KillingEnemy()
    {
       KilledEnemy++;
    }

   
}
