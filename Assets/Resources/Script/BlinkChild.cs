using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlinkChild : MonoBehaviour {
    public GameObject Self;//自分自身
    public GameObject HideBlinker;//色参照元、これに常に合わせる
                                  // Use this for initialization
    void Start () {
        HideBlinker = GameObject.FindGameObjectWithTag("Blinker");

    }

    // Update is called once per frame
    void Update () {
        if (HideBlinker != null)
        {
            Self.GetComponent<Image>().color = HideBlinker.GetComponent<Image>().color;
        }
    }
}
