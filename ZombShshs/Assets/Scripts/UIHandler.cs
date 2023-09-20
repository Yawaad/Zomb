using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] GameObject MainMenu, PlayButton, ShopButton, OptionsButton, PatchesButton, QuitButton, PlaySelectionPanel,
        Campaign, Infinite, Multiplayer;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(PlayButton, 39.9f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -11.20972f, 1.5f).setDelay(.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -62.31939f, 1.5f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -113.4291f, 1.5f).setDelay(.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -164.4291f, 1.5f).setDelay(1f).setEase(LeanTweenType.easeOutCubic);
    }


    public void PlayMenu()
    {
        Invoke(nameof(MainMenuDelayPlay), 2f);
        Invoke(nameof(PlayMenuDelay), 2f);
        LeanTween.moveLocalY(PlayButton, -283.7f, 1.5f).setDelay(.8f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -334.8097f, 1.5f).setDelay(.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -385.9194f, 1.5f).setDelay(.4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -437.0291f, 1.5f).setDelay(.2f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -488.1388f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Campaign, -250f, 2f).setDelay(2.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Infinite, 0f, 2f).setDelay(2.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Multiplayer, 250f, 2f).setDelay(2.75f).setEase(LeanTweenType.easeOutCubic);
    }

    public void QuitPlayMenu()
    {

    }
    public void InfiniteMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void MainMenuDelayPlay()
    {
        MainMenu.SetActive(false);
    }

    private void PlayMenuDelay()
    {
        PlaySelectionPanel.SetActive(true);
    }
}
