using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Ups : MonoBehaviour
{
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;
    public GameObject powerUp4;
    public GameObject powerUp5;
    public GameObject powerUp6;
    public float timeGap;
    private GameObject clone;
    private float timer = 0.00f;
    public Obstacles obstaclesScript;
    private float yPosition;
    public Transform spawnPoint;
    private Rigidbody2D rbClone;
    public float starSpeed;
    private int randomValue;
    private GameObject powerUp;

    void Start()
    {
        timer = Time.time;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > timeGap)
        {
            float rand = Mathf.Round(Random.Range(0, 2));
            if (rand == 0)
            {
                powerUp = powerUp1;
            }
            else 
            {
                powerUp = powerUp2;
            }
            obstaclesScript.randomPosition();
            obstaclesScript.Spawn(powerUp);

            timer = Time.time;
        }
       

    }

   

}
