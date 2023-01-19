using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{

    //trail
    public Transform targetDir;
    public LineRenderer lineRend;
    private List<Vector3> positions;
    private int length = 1;
    public float targetDistance;
    public float smoothSpeed;
    private List<Vector3> segmentV;

    public static List<GameObject> segments;
    public static Vector2 positionSignal;
    public static Vector3 dirPass = Vector3.zero;
    private Vector3 trailMovevector = Vector3.zero;
    private Vector3 reference;

    //addobjectmethod
    public float distance;
    public int initialPos;
    private Vector2 instantiatePosition;
    public GameObject trailNeutron;
    private AudioSource source;
    void Start()
    {

        //trail
        lineRend.positionCount = length;
        segments = new List<GameObject>();
        positions = new List<Vector3>(length);
        segmentV = new List<Vector3>(length);
        segments.Add(gameObject);
        positions.Add(gameObject.transform.position);
        segmentV.Add(gameObject.transform.position);
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        length = segments.Count;


        Debug.Log(segments.Count);
        Debug.Log(positions.Count);
        Debug.Log(segmentV.Count);
        Debug.Log(lineRend.positionCount);
        //follow trail

        positions[0] = targetDir.position;
        segmentV[0] = positions[0];
        lineRend.SetPosition(initialPos, targetDir.position);


        for (int i = 1; i < positions.Count; i++)
        {
            reference = segmentV[i];
            positions[i] = Vector3.SmoothDamp(positions[i], positions[i-1] , ref reference, smoothSpeed);

            segments[i].transform.position = positions[i];
            lineRend.SetPosition(i, positions[i]);
        }

    }

    public void addTrailObject()
    {
     
        GameObject newObject =  Instantiate(trailNeutron,positions[positions.Count - 1], Quaternion.identity);
        segments.Add(newObject);
        positions.Add(newObject.transform.position);
        segmentV.Add(newObject.transform.position);
        lineRend.positionCount++;
        Debug.Log(newObject.GetComponent<Rigidbody2D>().velocity);
        source.Play();

    }

}
