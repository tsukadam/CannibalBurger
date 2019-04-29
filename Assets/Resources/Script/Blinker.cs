using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Coffee.UIExtensions;

public class Blinker : MonoBehaviour
{
    private float nextTime;
    public float interval = 1.0f;   // 点滅周期
    public GameObject Target;
    public Color TargetCol;
    public float ColR;
    public float ColG;
    public float ColB;
    public float ColA;
    public Color BlinkCol;
    int count = 0;

    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
        nextTime = Time.time + 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        count++;
        if (count % 10 == 0)
        {
            TargetCol = Target.GetComponent<Image>().color;
            ColR = TargetCol.r;
            ColG = TargetCol.g;
            ColB = TargetCol.b;


            if (Time.time > nextTime)
            {

                if (Target.GetComponent<Image>().color == new Color(ColR, ColG, ColB, 1.0f))
                {
                    Target.GetComponent<Image>().color = new Color(ColR, ColG, ColB, 0);
                }
                else
                {
                    Target.GetComponent<Image>().color = new Color(ColR, ColG, ColB, 1.0f);
                }
                nextTime += interval;
            }
        }
    }
}
