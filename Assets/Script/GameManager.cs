using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]private Text amountKillEnemyText;
    [SerializeField]private GameObject GameStateSc;
    [SerializeField]private Text GameStateText;
    [SerializeField]private GameObject PowerBulletInfo;
    public bool GameOverBool;
    public AudioSource KilledEnemySound;
    public AudioSource GameOverSound;


    public static GameManager instance;

    void Start()
    {
        if(instance==null)
        {
       instance=this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        amountKillEnemyText.text=("Killed Enemy:"+Enemies.instance.KilledEnemy);
        GameStateSet();
      if(PowerBullet.instance.amountPower==0)
      {
         PowerBulletInfo.gameObject.SetActive(false);
      }


    }

   
   public void GameStateSet()
   {
    if(Enemies.instance.KilledEnemy>=Enemies.instance.TotalEnemy)
    {
      GameStateSc.gameObject.SetActive(true);
      GameStateText.text="YOU WİN";
    }

    else if(GameOverBool==true)
    {
        GameStateSc.gameObject.SetActive(true);

      GameStateText.text="GAME OVER";
    }
    else
    {
        GameStateSc.SetActive(false);
    }


   }

   public void GameOverSt()
   {
    GameOverSound.Play();
    GameOverBool=true;
   }

   public void LoadScene()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Quit()
   {
    Application.Quit();
   }

  


}
