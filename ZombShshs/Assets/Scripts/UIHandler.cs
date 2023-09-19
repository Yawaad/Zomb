using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] GameObject PlayButton, ShopButton, OptionsButton, PatchesButton, QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(PlayButton, 39.9f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -11.20972f, 1.5f).setDelay(.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -62.31939f, 1.5f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -113.4291f, 1.5f).setDelay(.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -164.4291f, 1.5f).setDelay(1f).setEase(LeanTweenType.easeOutCubic);
    }

}
