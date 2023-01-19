using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricField : MonoBehaviour
{
    public GameObject negativePlate;
    public GameObject positivePlate;
    public static int botPlateSign;
    private float eFieldValue;
    public float efieldpass;
    private Rigidbody2D topRb;
    private Rigidbody2D botRb;
    private float epselon = (float)(8.854 * (Mathf.Pow(10f , -12f)));
    public float chargeDensity;
    public static float Efield;
    private GameObject botPlate;

    //sound
    private AudioSource source;
   
        
    void Start()
    {
        //setting electric field value  
        botPlate = GameObject.Find("PositivePlate");
        eFieldValue = chargeDensity / epselon;
        Efield = eFieldValue;
        botPlateSign = 1;
        source = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (negativePlate.transform.position.y < 0)
        {
            botPlate = negativePlate;
            
        }
        if (positivePlate.transform.position.y < 0)
        {
            botPlate = positivePlate;
            
        }
        efieldpass = eFieldValue;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.Play();
        }
    }
}
