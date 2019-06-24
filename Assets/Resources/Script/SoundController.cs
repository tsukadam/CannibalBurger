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
    public AudioClip SETapButtonHigh1;
    public AudioClip SETapButtonHigh2;
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
    public AudioClip SEMahouHoly;
    public AudioClip SEBadEnd;
    public AudioClip SEGoodEnd;

    public AudioClip SEVoiceMan;
    public AudioClip SEVoiceMan2;
    public AudioClip SEVoiceWoman;
    public AudioClip SEVoiceOld;
    public AudioClip SENoVoice;
    public AudioClip SEKachi;

    public AudioClip SEWaku;

    //フェードインアウト設定
    public float SEVolume = 1;
    public float BgmVolume = 1;


    //ボタンを押した音
    public void ButtonMenuSE()    {        PlaySE("TapButtonDai");    }
    public void ButtonCloseInfo() { PlaySE("TapButton"); }
    public void ButtonOpenInfo() { PlaySE("TapButtonHigh1"); }
    public void ButtonReset() { PlaySE("SEMahouHoly"); }
    public void Button4ItemSE()    {        PlaySE("TapButton");    }
    public void Button6ItemSE()    {        PlaySE("TapButton");    }
    public void ButtonSaveSusOKSE() { PlaySE("TapButtonHigh1"); }
    public void ButtonSelectOKSE()    {        PlaySE("TapButtonHigh1");    }
    public void ButtonSelectWakuSE()    {        PlaySE("SEWaku");    }
    public void ButtonHiroiItemOKSE()    {        PlaySE("TapButton");    }
    public void ButtonDisposeOKSE()    {        PlaySE("TapButtonHigh1");    }
    public void ButtonCancelSE()   {        PlaySE("TapButton");    }
    public void ButtonResultOKSE()    {        PlaySE("TapButton");    }
    public void ButtonNoSaveSE()    {        PlaySE("TapButton");    }
    public void ButtonSaveSE()    {        PlaySE("TapButtonDai");    }
    public void ButtonLvUpOKSE()    {        PlaySE("TapButtonHigh1");    }
    public void ButtonGameOverOKSE()    {        PlaySE("TapButtonDai");    }
    public void ButtonGoResultSE()    {        PlaySE("TapButtonHigh1");    }
    public void ButtonLoadSE()    {        PlaySE("TapButtonDai");    }
    public void ButtonNoLoadSE()    {        PlaySE("TapButton");    }
    public void ButtonPlaceSE() { PlaySE("TapButton"); }
    public void ButtonActionSE() { PlaySE("TapButtonHigh1"); }
    public void ButtonStoryReadSE() { PlaySE("TapButton"); }
    public void ButtonStoryEndSE() { PlaySE("TapButtonHigh1"); }
    public void Buttontyuudan() { PlaySE("TapButton"); }
    public void ButtonScoreBack() { PlaySE("TapButton"); }
    public void ButtonHand() { PlaySE("SEKachi"); }
    public void ButtonTutorialRead() { PlaySE("TapButtonHigh1"); }
    public void ButtonRankIn() { PlaySE("TapButtonHigh1"); }



    //キーを送るとクリップを返す
    public AudioClip GetNameSE(string SEName)
    {
        AudioClip UseSE = SETapButton;//宣言で入れるデフォ値、指定された番号のSEがないとこれが鳴ってしまう

        if (SEName == "GGet") { UseSE = SEGGet; }
        else if (SEName == "DoorOpen") { UseSE = SEDoorOpen; }
        else if (SEName == "CustomerVoice") { UseSE = SECustomerVoice; }
        else if (SEName == "Kill") { UseSE = SEKill; }
        else if (SEName == "TapButton") { UseSE = SETapButton; }
        else if (SEName == "TapButtonDai") { UseSE = SETapButtonDai; }
        else if (SEName == "TapButtonHigh1") { UseSE = SETapButtonHigh1; }
        else if (SEName == "TapButtonHigh2") { UseSE = SETapButtonHigh2; }
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
        else if (SEName == "SEMahouHoly") { UseSE = SEMahouHoly; }
        else if (SEName == "SEGoodEnd") { UseSE = SEGoodEnd; }
        else if (SEName == "SEBadEnd") { UseSE = SEBadEnd; }
        else if (SEName == "SEWaku") { UseSE = SEWaku; }
        else if (SEName == "SEVoiceNone") { UseSE = SENoVoice; }
        else if (SEName == "SEKachi") { UseSE = SEKachi; }
        else { Debug.Log("指定された番号のSEはありません"); }

        return UseSE;
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
        SESource.volume = 1.0f;
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
