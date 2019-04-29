using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Floater : MonoBehaviour {
    private float nextTime;
    public float interval = 4.0f;   // 点滅周期
    public GameObject Target;
    int count = 0;
    float ForceY;
    float ForceX;
    int ForcePower;

    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
        nextTime = Time.time + 4.0f;
    }


    // Update is called once per frame
    void Update()
    {
        count++;
        if (count % 10 == 0)
        {

            if (Time.time > nextTime)
            {
                if (Random.Range(0, 1.0f) > 0.5f)
                {
                    //位置決定
                    if (Random.Range(0, 1.0f) > 0.5f)
                    {
                        ForceY = 0;
                        ForceX = Random.Range(-2.5f, 2.5f);
                    }
                    else {
                        ForceY = Random.Range(-2.5f, 2.5f);
                        ForceX = 0;
                    }
                    ForcePower = 10000;

                    Target.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceX, ForceY) * ForcePower);

                }
                nextTime += interval;
            }
        }
    }
}
