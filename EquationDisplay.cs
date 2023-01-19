using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquationDisplay : MonoBehaviour
{
    private Text text;
    public Charge chargeScript;
    private float a,t,c,vf,vi,E,sigma,F,m;

    // Start is called before the first frame update
    void awake()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        a = 0;
        t = 0;
        c = 0;
        vf = 0;
        vi = 0;
        F = 0;

    }

    // Update is called once per frame
    void Update()
    {
        a = chargeScript.acceleration;
        F = chargeScript.force;
        c = chargeScript.chargeValue;
            

        text.text = "a"+a;
        print(a);
    }
}
