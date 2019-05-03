using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

//音関係の演出

public class SoundController : MonoBehaviour {
    //必要なもの
    public GameObject StatGame;

    public AudioSource BgmSource;
    public GameObject BgmObj;
    public AudioSource SESource;
    public AudioMixer Mixer;

    //メインbgmの切り替えフラグ
    //0=再生してない　1=再生待ち　2=再生中
    public int BgmFlag1=0;
    public int BgmFlag2 = 0;

    //bgmに使うクリップ
    public AudioClip StoreBgm1;
    public AudioClip StoreBgm2;

    //seに使うクリップ
    public AudioClip SEGGet;
    public AudioClip SEDoorOpen;
    public AudioClip SECustomerVoice;
    public AudioClip SEKill;
    public AudioClip SETapButton;
    public AudioClip SETapButtonDai;
    public AudioClip SECustomerSelect;
    public AudioClip SEGGetOne;
    public AudioClip SELvUp;
    public AudioClip SEHeart;
    public AudioClip SEBansDon;
    public AudioClip SEBurger;
    public AudioClip SEBans;
    public AudioClip SEBansSteam;
    public AudioClip SEMahou;

    public AudioClip SEVoiceMan;
    public AudioClip SEVoiceMan2;
    public AudioClip SEVoiceWoman;
    public AudioClip SEVoiceOld;

    //フェードインアウト設定
    public float SEVolume = 1;
    public float BgmVolume = 1;


    //ボタンを押した音
    public void ButtonMenuSE()    {        PlaySE("TapButtonDai");    }
    public void Button4ItemSE()    {        PlaySE("TapButton");    }
    public void Button6ItemSE()    {        PlaySE("TapButton");    }
    public void ButtonSelectOKSE()    {        PlaySE("TapButton");    }
    public void ButtonSelectWakuSE()    {        PlaySE("TapButton");    }
    public void ButtonHiroiItemOKSE()    {        PlaySE("TapButton");    }
    public void ButtonDisposeOKSE()    {        PlaySE("TapButton");    }
    public void ButtonCancelSE()   {        PlaySE("TapButton");    }
    public void ButtonResultOKSE()    {        PlaySE("TapButton");    }
    public void ButtonNoSaveSE()    {        PlaySE("TapButton");    }
    public void ButtonSaveSE()    {        PlaySE("TapButton");    }
    public void ButtonLvUpOKSE()    {        PlaySE("TapButton");    }
    public void ButtonGameOverOKSE()    {        PlaySE("TapButton");    }
    public void ButtonGoResultSE()    {        PlaySE("TapButton");    }
    public void ButtonLoadSE()    {        PlaySE("TapButton");    }
    public void ButtonNoLoadSE()    {        PlaySE("TapButton");    }



    //キーを送るとクリップを返す
    public AudioClip GetNameSE(string SEName)
    {
        AudioClip UseSE = SEGGet;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        if (SEName == "GGet") { UseSE = SEGGet; }
        else if (SEName == "DoorOpen") { UseSE = SEDoorOpen; }
        else if (SEName == "CustomerVoice") { UseSE = SECustomerVoice; }
        else if (SEName == "Kill") { UseSE = SEKill; }
        else if (SEName == "TapButton") { UseSE = SETapButton; }
        else if (SEName == "TapButtonDai") { UseSE = SETapButtonDai; }
        else if (SEName == "CustomerSelect") { UseSE = SECustomerSelect; }
        else if (SEName == "GGetOne") { UseSE = SEGGetOne; }
        else if (SEName == "LvUp") { UseSE = SELvUp; }
        else if (SEName == "Heart") { UseSE = SEHeart; }
        else if (SEName == "BansDon") { UseSE = SEBansDon; }
        else if (SEName == "Burger") { UseSE = SEBurger; }
        else if (SEName == "Bans") { UseSE = SEBans; }
        else if (SEName == "BansSteam") { UseSE = SEBansSteam; }
        else if (SEName == "SEVoiceMan") { UseSE = SEVoiceMan; }
        else if (SEName == "SEVoiceMan2") { UseSE = SEVoiceMan2; }
        else if (SEName == "SEVoiceWoman") { UseSE = SEVoiceWoman; }
        else if (SEName == "SEVoiceOld") { UseSE = SEVoiceOld; }
        else if (SEName == "SEMahou") { UseSE = SEMahou; }
        else if (SEName == "SEVoiceNone") { UseSE = SEVoiceMan2; }
        else { Debug.Log("指定された番号のSEはありません"); }

        return UseSE;
    }

    //キーを送ると音量とピッチを返す
    public float[] GetVol(string SEName)
    {
        float UseVol = 1.0f;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう
        float UsePitch = 1.0f;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        float VolBig = 1.0f;
        float VolSmall = 0.1f;


        if (SEName == "GGet") { UseVol = VolSmall; }
        else if (SEName == "DoorOpen") { UseVol = VolSmall; }
        else if (SEName == "CustomerVoice") { UseVol = VolSmall; }
        else if (SEName == "Kill") { UseVol = VolBig; }
        else if (SEName == "TapButton") { UseVol = VolBig; }
        else if (SEName == "TapButtonDai") { UseVol = VolBig; }
        else if (SEName == "CustomerSelect") { UseVol = VolBig; }
        else if (SEName == "GGetOne") { UseVol = VolSmall; }
        else if (SEName == "LvUp") { UseVol = VolBig; }
        else if (SEName == "Heart") { UseVol = VolBig; }
        else if (SEName == "BansDon") { UseVol = VolSmall; }
        else if (SEName == "Burger") { UseVol = VolBig; }
        else if (SEName == "Bans") { UseVol = VolSmall; }
        else if (SEName == "BansSteam") { UseVol = VolBig; }
        else if (SEName == "SEVoiceMan") { UseVol = VolBig; }
        else if (SEName == "SEVoiceMan2") { UseVol = VolBig; }
        else if (SEName == "SEVoiceWoman") { UseVol = VolBig; }
        else if (SEName == "SEVoiceOld") { UseVol = VolBig; }
        else if (SEName == "SEMahou") { UseVol = VolBig;}
        else if (SEName == "SEVoiceNone") { UseVol = 0; }
        else { Debug.Log("指定された番号のSEはありません"); }

        float[] ReturnVol = new float[2];
        ReturnVol[0] = UseVol;
        ReturnVol[1] = UsePitch;

        return ReturnVol;
    }



    public AudioClip GetNameBgm(string BgmName)
    {
        AudioClip UseBgm = StoreBgm1;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        if (BgmName == "StoreBgm1") { UseBgm = StoreBgm1; }
        else if (BgmName == "StoreBgm2") { UseBgm = StoreBgm2; }

        else { Debug.Log("指定された番号のBGMはありません"); }

        return UseBgm;
    }

    //通常音量でSE
    public void PlaySE(string SEName)
    {
        float[] UseStat = GetVol(SEName);
        SESource.volume = UseStat[0];
        //SESource.pitch = UseStat[1];
        AudioClip UseSE = GetNameSE(SEName);

        SESource.PlayOneShot(UseSE);
        //Debug.Log("Sound-"+SEName+":"+ SESource.volume+":"+SESource.pitch);
    }


    //フェードイン・アウトでSE
    public void FadeInOutSE(string SEName,float FadeInTime, float MaxTime, float FadeOutTime, float MaxVolume)
    {
        SESource.volume = 0;
        AudioClip UseSE = GetNameSE(SEName);
//        SESource.DOFade(MaxVolume, FadeInTime).SetEase(Ease.InCubic);
//        SESource.DOFade(0.0f, FadeOutTime).SetDelay(MaxTime + FadeInTime);
        SESource.PlayOneShot(UseSE);

    }

    //通常音量でBgm
    public void PlayStoreBgm(string BgmName)
    {
            BgmSource.clip = GetNameBgm(BgmName);
        BgmSource.Play();

    }

    //前の曲をフェードアウトしてフェードインするBgm
    public void FadeInOutBgm(string BgmName, float FadeOutTime, float WaitTime, float FadeInTime)
    {
  //      SESource.DOFade(0.0f, FadeOutTime).SetEase(Ease.InCubic);//まず前の曲をフェードアウト

  //      DOVirtual.DelayedCall(WaitTime + FadeOutTime, () => {//曲を切り替える
            BgmSource.clip = GetNameBgm(BgmName);
            BgmSource.Play();
//        });

   //     SESource.DOFade(BgmVolume, FadeInTime).SetDelay(WaitTime+FadeOutTime) ;//Delayで無音の時間のあと、フェードイン
 
    }

public void StopStoreBgm()
    {
        BgmSource.Stop();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 拍に来たフレームで true になる

        if (Music.IsJustChangedBar()&BgmFlag2==1)
        {
            BgmFlag2 = 2;
                 PlayStoreBgm("StoreBgm2");
        }



    }
}
