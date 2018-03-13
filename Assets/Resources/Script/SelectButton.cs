using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {
    public GameObject Self;//自分自身


    public void SendTag()    // Use this for initialization
    {
        string MyTag = Self.tag;
        GameObject Script = GameObject.FindGameObjectWithTag("Script");
        Script.GetComponent<GameController>().SelectItem(MyTag);
    }


    public void UnSelect()    // Use this for initialization
    {
        string MyTag = Self.tag;
        GameObject Script = GameObject.FindGameObjectWithTag("Script");
        Script.GetComponent<GameController>().UnSelectItem(MyTag);
    }

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


    }
}
