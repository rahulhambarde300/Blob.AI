using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private HealthBarController healthInstance;
    private PowerBarController powerInstance;
    public GameObject healthBarController;
    public GameObject powerBarController;

    private float health;
    private float power;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        power = 100;
        //gameOver = false;



        GameObject gameControlObject = GameObject.FindWithTag("UI");
        if (gameControlObject != null)
        {
            //gameOverScript = gameControlObject.GetComponent<GameOverScript>();
            healthInstance = healthBarController.GetComponent<HealthBarController>();
            powerInstance = powerBarController.GetComponent<PowerBarController>();
            
            healthInstance.setMaxHealth(100.0f);
            healthInstance.setHealth(100.0f);

            powerInstance.setMaxPower(100.0f);
            powerInstance.setPower(100.0f);
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
            health += 30;
        else
            health = 100;
        updateHealth(health);
    }
    void updateHealth(float health2)
    {
        healthInstance.setHealth(health2);
    }

    public void increasePower(float power2)
    {
        if (power <= 99)
            power += power2;
        else
            power = power2;
        updatePower(power);
    }

    public void decreasePower(float power2)
    {
        if (power > 0)
            power -= power2;
        updatePower(power);
    }

    void updatePower(float power)
    {
        powerInstance.setPower(power);
    }

}
