using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] Image fade;
    [SerializeField] Slider loadingBar;
    [SerializeField] float fadeTime;

    private BaseScene curScene;

    public BaseScene GetCurScene()
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }
        return curScene;
    }

    public T GetCurScene<T>() where T : BaseScene
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }
        return curScene as T;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        fade.gameObject.SetActive(true);
        yield return FadeOut();

        Manager.Pool.ClearPool();
       //  Manager.Sound.StopSFX();
        Manager.UI.ClearPopUpUI();
        Manager.UI.ClearWindowUI();

        BaseScene curScene = GetCurScene();

        yield return FadeIn();
        
        // curScene.OnLoadingEnd();

        Time.timeScale = 0f;
        //loadingBar.gameObject.SetActive(true);

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (oper.isDone == false)
        {
            loadingBar.value = oper.progress;
            yield return null;
        }

        Manager.UI.EnsureEventSystem();

        loadingBar.gameObject.SetActive(false);
        Time.timeScale = 1f;

        curScene = GetCurScene();
        //yield return curScene.LoadingRoutine();

        fade.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        float rate = 0;
        Color fadeOutColor = new Color(fade.color.r, fade.color.g, fade.color.b, 0f);
        Color fadeInColor = new Color(fade.color.r, fade.color.g, fade.color.b, 0f);

        while (rate <= 1)
        {
            rate += Time.deltaTime / fadeTime;
            fade.color = Color.Lerp(fadeInColor, fadeOutColor, rate);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float rate = 0;
        Color fadeOutColor = new Color(fade.color.r, fade.color.g, fade.color.b, 0f);
        Color fadeInColor = new Color(fade.color.r, fade.color.g, fade.color.b, 1f);

        while (rate <= 1)
        {
            rate += Time.deltaTime / fadeTime;
            fade.color = Color.Lerp(fadeOutColor, fadeInColor, rate);
            yield return null;
        }
    }
}
