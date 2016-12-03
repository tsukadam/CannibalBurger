using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DebugController : MonoBehaviour {

    public GameObject DebugOpen;
    public GameObject DebugAnyButton;
    public GameObject DebugStart;
    public GameObject DebugGup;

    public void DebugButtonOpen()
    {
        DebugAnyButton.SetActive(true);
        DebugOpen.SetActive(false);
    }

    public void DebugButtonClose()
    {
        DebugAnyButton.SetActive(false);
        DebugOpen.SetActive(true);
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
