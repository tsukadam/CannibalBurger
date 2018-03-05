using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
public class Glower : MonoBehaviour {
    //ステータス表示オブジェクトの取得
    public GameObject Customer;//自分自身
    

    public void Glow()
    {
        DOTween.To(
                    () => Customer.GetComponent<GlowImage>().glowSize,
        (x) => Customer.GetComponent<GlowImage>().glowSize = (-32 * x * (x - 1))+0.5f,
                    1,
                    2.0f
                    ).SetLoops(-1);
    }

    public void GlowStop()
    {

        DOTween.Kill(Customer.GetComponent<GlowImage>().glowSize);
        Customer.GetComponent<GlowImage>().glowSize = 0;
    }

    // Use this for initialization
    void Start () {
        Glow();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
