using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] GameObject MainMenu, PlayButton, ShopButton, OptionsButton, PatchesButton, QuitButton, PlaySelectionPanel,
        Campaign, Infinite, Multiplayer, PlayBack;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(PlayButton, 114f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -5.311989f, 1.5f).setDelay(.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -124.624f, 1.5f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -243.9361f, 1.5f).setDelay(.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -363.2482f, 1.5f).setDelay(1f).setEase(LeanTweenType.easeOutCubic);
    }


    public void MenuToPlay()
    {
        Invoke(nameof(MainMenuOff), 2f);
        Invoke(nameof(PlayMenuOn), 2f);
        LeanTween.moveLocalY(PlayButton, -723f, 1.5f).setDelay(.8f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -842.312f, 1.5f).setDelay(.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -961.624f, 1.5f).setDelay(.4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -1080.936f, 1.5f).setDelay(.2f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -1200.248f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Campaign, -572f, 2f).setDelay(2.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Infinite, 0f, 2f).setDelay(2.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Multiplayer, 572f, 2f).setDelay(2.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PlayBack, -446f, 2f).setDelay(2.5f).setEase(LeanTweenType.easeOutCubic);
    }

    public void PlayToMenu()
    {
        Invoke(nameof(MainMenuOn), 2.5f);
        Invoke(nameof(PlayMenuOff), 2.5f);
        LeanTween.moveLocalY(PlayButton, 114f, 1.5f).setDelay(2.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(ShopButton, -5.311989f, 1.5f).setDelay(2.95f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(OptionsButton, -124.624f, 1.5f).setDelay(3.15f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PatchesButton, -243.9361f, 1.5f).setDelay(3.35f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(QuitButton, -363.2482f, 1.5f).setDelay(3.55f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Campaign, 1348f, 2f).setDelay(.75f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Infinite, 1920f, 2f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalX(Multiplayer, 2492f, 2f).setDelay(.25f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocalY(PlayBack, -690f, 2f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
    }
    public void InfiniteMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void MainMenuOff()
    {
        MainMenu.SetActive(false);
    }

    private void PlayMenuOn()
    {
        PlaySelectionPanel.SetActive(true);
    }

    private void MainMenuOn()
    {
        MainMenu.SetActive(true);
    }

    private void PlayMenuOff()
    {
        PlaySelectionPanel.SetActive(false);
    }
}
