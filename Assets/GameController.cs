using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private HealthBarController healthInstance;
    public GameObject healthBarController;

    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        //gameOver = false;



        GameObject gameControlObject = GameObject.FindWithTag("UI");
        if (gameControlObject != null)
        {
            //gameOverScript = gameControlObject.GetComponent<GameOverScript>();
            healthInstance = healthBarController.GetComponent<HealthBarController>();
            healthInstance.setMaxHealth(100.0f);
            healthInstance.setHealth(100.0f);
        }
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseHealth(float dmg)
    {
        health -= dmg;
        updateHealth(health);
        if (health <= 0)
        {
            //gameOverScript.GameOver();
        }

    }
    public void increaseHealth()
    {
        if (health <= 80)
            health += 20;
        else
            health = 100;
        updateHealth(health);
    }
    void updateHealth(float health2)
    {
        healthInstance.setHealth(health2);
    }

}
