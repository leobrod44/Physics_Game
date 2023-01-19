using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Charge : MonoBehaviour
{

    private Rigidbody2D chargeRb;
    private int chargeSign;
    private Vector3 direction;
    public float mass;
    public float chargeValue;
    public float force;
    public float acceleration;
    public float vi;
    public float vf;
    private bool collided = false;
    private int collisionSign = 0;
    public Sprite proton;
    public Sprite electron;
    private SpriteRenderer rend;
    public GameObject bottomPlate;
    public GameObject upperPlate;
    public Neutron neutronScript;
    private float vx;
    public ParticleSystem explosion;
    private float time = 0f;
    public float restartTimer;
    public GameObject powerUp;
    public Obstacles obstaclesScript;
    float PUtimer = 0f;
    bool PU2 = false;



    public bool running = true;

    private AudioSource source;
    public AudioSource source2;

    void Start()
    { 
        chargeRb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        chargeRb.mass = mass;
        chargeValue = (float)(1.6 * Mathf.Pow(10f, -19f));
        chargeSign = 1;
        vi = 0f;
        bottomPlate = GameObject.Find("PositivePlate");
        upperPlate = GameObject.Find("NegativePlate");
        vx = 0;
        source = GetComponent<AudioSource>();
        source.Play();

    }

    void Update()
    {
        
        if (running)
        {
            time = Time.time;
        }
        
        if (!running)
        {
            Debug.Log("finished");
           
            //Debug.Log("time-time" + (Time.time - time));

            if (Time.time - time > restartTimer)
            {
                Debug.Log("restart");
                SceneManager.LoadScene("menu");
                running = false;
            }
        }
       
        if (collided == true)
        {
            chargeRb.velocity = Vector3.zero;
            vi = 0;
            vf = 0;
            
            if(collisionSign == chargeSign)
            {
                collided = false;
            }
        }
        if(PU2 && Time.time - PUtimer > 3)
            { 
           
                neutronScript.timeGap = 0.7f;
                PU2 = false;
            }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            collided = false;
            changeSign();
           
        }


        //charge's movement according to physics
        force = getForce(ElectricField.Efield, (chargeValue));
        acceleration = getAcceleration(force, mass);

        if (!collided || ((collided == true) && (chargeSign == collisionSign)))
        {
            vf = vi + acceleration * Time.deltaTime;
            chargeRb.velocity = new Vector2(vx, vf);
            vi = vf;
            vx = chargeRb.velocity.x;

        }

    }
    
    public void changeSign()
    {
        chargeSign *= -1;
        chargeValue *= -1;

        if (chargeSign == -1)
        {
            rend.sprite = electron;
        }
        if (chargeSign == 1)
        {
            rend.sprite = proton;
        }


    }
    public float getForce(float EField, float charge)
    {
        float f = EField * charge;
        return f;
    }
    public float getAcceleration(float force, float mass)
    {
        float a = force / mass;
        return a;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.name == "PositivePlate")
        {
            collisionSign = 1;
            collided = true;

        }
        if (collision.gameObject.name == "NegativePlate")
        {
            collisionSign = -1;
            collided = true;

        }
        if (collision.gameObject.layer == 13)
        {
            Destroy(GameObject.Find("spawnPoint"));
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                if (o.gameObject.tag != "MainCamera" && o.gameObject.tag != "Player" && o.gameObject.tag != "Background")
                    Destroy(o);
                

            }
            Instantiate(explosion, transform.position, Quaternion.identity);
            source2.Play();
            chargeRb.velocity = Vector3.zero;
            Destroy(rend);
            time = Time.time;
            TextDisplay.score = 0;
            running = false;
        }
        if (collision.gameObject.tag == "powerup1")
        {
                Destroy(collision.gameObject);
                obstaclesScript.Spawn2(powerUp);
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                if (o.gameObject.tag == "Obstacles")
                    Destroy(o);
            }
        }
        if (collision.gameObject.tag == "powerup2")
        {
            Destroy(collision.gameObject);

            neutronScript.timeGap = 0.05f;
            PUtimer = Time.time;
            PU2 = true;
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                if (o.gameObject.tag == "Obstacles")
                    Destroy(o);
            }
        }
    }
}

