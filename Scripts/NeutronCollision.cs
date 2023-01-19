using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutronCollision : MonoBehaviour
{

    private Charge chargeScript;
    private TextDisplay textScript;
    private GameObject textObject;
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private ParticleSystem particles;
    private GameObject chargeObj;
    private Trail trailScript;
    



    void Start()
    {
        chargeObj = GameObject.Find("Charge");
        trailScript = chargeObj.GetComponent<Trail>();
        textObject = GameObject.Find("Math");
        textScript = textObject.GetComponent<TextDisplay>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<CircleCollider2D>();
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
        

    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 15)
        {
            textScript.addScore();
            Destroy(this.gameObject);
            trailScript.addTrailObject();
            
           
        }
    }

}
