using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    

    private GameObject obstacle;
    public GameObject water;
    public GameObject wood;
    public GameObject eraser;
    private GameObject clone;
    private Rigidbody2D rbClone;
    private float yPosition;
    private float timer = 0.0f;
    public float timeGap;
    public float obstacleSpeed;
    public Transform spawnPoint;
    public float rotation;
    public static float lastPos=0;
    int randomLimit = 5;
    private float[]Ypositions;
    private int lastPosIndex=0;
    private int posIndex=0;

    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        //rbClone = clone.GetComponent<Rigidbody>();
        timer = Time.time;
        Ypositions = new float[] { -26, -13, -2, 11, 24 };
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > timeGap)
        {

            float rand = Mathf.Round(Random.Range(0, 3));
            if (rand == 0)
            {
                obstacle = eraser;
            }
            else if (rand == 1)
            {
                obstacle = water;
            }
            else
            {
                obstacle = wood;
            }

            Spawn(obstacle);
            rbClone.AddTorque(Random.Range(-rotation, rotation));

            timer = Time.time;
        }
       

        
    }
        public void Spawn(GameObject obstacle)
    {


        randomPosition();
        spawnPoint.position = new Vector3(spawnPoint.position.x, yPosition, spawnPoint.position.z);
        clone = Instantiate(obstacle, spawnPoint.position, Quaternion.identity );
        rbClone = clone.GetComponent<Rigidbody2D>();
        rbClone.AddForce(new Vector3(-obstacleSpeed * rbClone.mass, 0f), ForceMode2D.Impulse);


    }
    public void Spawn2(GameObject obstacle)
    {


        randomPosition();
        spawnPoint.position = new Vector3(spawnPoint.position.x, yPosition, spawnPoint.position.z);
        clone = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        Rigidbody2D[] rbClones = clone.GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D o in rbClones)
        {
            o.AddForce(new Vector3(-obstacleSpeed * o.mass, 0f), ForceMode2D.Impulse);
        }
        


    }
    public void SpawnAt(GameObject o, float x, float y)
    {
        clone = Instantiate(o, new Vector3(x,y,spawnPoint.position.z), Quaternion.identity);
        rbClone = clone.GetComponent<Rigidbody2D>();
        rbClone.AddForce(new Vector3(-obstacleSpeed * rbClone.mass, 0f), ForceMode2D.Impulse);
    }
    public void randomPosition()
    {
        List<float> randomYpos = new List<float> { -26, -13, -2, 11, 24 };

        posIndex = Random.Range(0, randomYpos.Count);

        if (posIndex != lastPosIndex)
        {
            lastPosIndex = posIndex;
            yPosition = randomYpos[posIndex];
        }
        else
        {

            List<float> newRandomYPos = new List<float>(randomYpos);
            newRandomYPos.Remove(lastPosIndex);

            int index = Random.Range(0, 3);


            lastPosIndex = randomYpos.IndexOf(newRandomYPos[index]);
            yPosition = newRandomYPos[index];
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            source.Play();
        }
    }

}
