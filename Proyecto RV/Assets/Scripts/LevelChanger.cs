using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger instance;

    public Image fadeImage;
    public Animator fadeAnimator;
    private int levelToLoad;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    

public void WhiteFadeOut()
    {
        fadeImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        fadeAnimator.SetTrigger("FadeOut");
    }

    public void BlackFadeOut()
    {
        fadeImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        fadeAnimator.SetTrigger("FadeOut");
    }

    public void FadeToLevel (int levelIndex, int fadeC)
    {
        levelToLoad = levelIndex;

        if (fadeC == 0)
            BlackFadeOut();
        else
            WhiteFadeOut();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
        //Debug.Log("debería cambiar");
    }
}
