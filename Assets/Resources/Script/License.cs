using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class License : MonoBehaviour
{

    //各画面
    public GameObject Menu;
    public GameObject Game;
    public GameObject HighScore;
    public GameObject Library;
    public GameObject Setting;

    public GameObject LicenseAll;

    public GameObject LinkJF20;
    public GameObject LinkJF68;
    public GameObject LinkPixel;
    public GameObject LinkMob;
    public GameObject LinkKoka;

    public GameObject LinkLetterSpacing;
    public GameObject LinkCSV;

    public void LinkDraw()
    {
        LinkJF20.SetActive(false);
        LinkJF68.SetActive(false);
        LinkPixel.SetActive(false);
        LinkMob.SetActive(false);
        LinkKoka.SetActive(false);
        LinkLetterSpacing.SetActive(false);
        LinkCSV.SetActive(false);

#if UNITY_EDITOR
        Debug.Log("android");
        LinkJF20.SetActive(true);
        LinkJF68.SetActive(true);
        LinkPixel.SetActive(true);
        LinkMob.SetActive(true);
        LinkKoka.SetActive(true);
        LinkLetterSpacing.SetActive(true);
        LinkCSV.SetActive(true);


#elif UNITY_ANDROID
        Debug.Log("android");
        LinkJF20.SetActive(true);
        LinkJF68.SetActive(true);
        LinkPixel.SetActive(true);
        LinkMob.SetActive(true);
        LinkKoka.SetActive(true);
        LinkLetterSpacing.SetActive(true);
        LinkCSV.SetActive(true);
#else
#endif

    }

    public void Gosetting()
    {
        Menu.SetActive(false);
        Game.SetActive(false);
        HighScore.SetActive(false);
        Setting.SetActive(true);

        LicenseAll.SetActive(false);
    }

    public void OpenLicense()
    {
        LinkDraw();
        LicenseAll.SetActive(true);
    }

    public void CloseLicense()
    {
        LicenseAll.SetActive(false);
    }


    public void OpenJF20()
    {
#if UNITY_ANDROID
        string url = "http://jikasei.me/font/jf-dotfont/";
        //Debug.Log("LINK");
        Application.OpenURL(url);
#endif
    }
    public void OpenJF68()
    {
#if UNITY_ANDROID
        string url = "http://jikasei.me/font/jf-dotfont/";
        Application.OpenURL(url);
#endif
    }
    public void OpenPixel()
    {
#if UNITY_ANDROID
        string url = "http://itouhiro.hatenablog.com/entry/20130602/font";
        Application.OpenURL(url);
#endif
    }
    public void OpenMob()
    {
#if UNITY_ANDROID
        string url = "https://github.com/mob-sakai/UIEffect";
        Application.OpenURL(url);
#endif
    }
    public void OpenKoka()
    {
#if UNITY_ANDROID
        string url = "https://soundeffect-lab.info/sound/various/";
        Application.OpenURL(url);
#endif
    }
    public void OpenLetterSpacing()
    {
#if UNITY_ANDROID
        string url = "https://forum.unity.com/threads/adjustable-character-spacing-free-script.288277/#post-2768776";
        Application.OpenURL(url);
#endif
    }
    public void OpenCSV()
    {
#if UNITY_ANDROID
        string url = "https://qiita.com/Akematty/items/2fbb61b55132ced4a3be";
        Application.OpenURL(url);
#endif
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
