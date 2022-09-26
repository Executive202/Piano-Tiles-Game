using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public int sceneIndex;
    AsyncOperation loading;
    public Slider progress;
    public TextMeshProUGUI perecent;
    public GameObject loadingScreen;
    public GameObject menuScene;
    public bool loadScreen = false;
    public void PlayGame()
    {
        StartCoroutine(LoadSceneMenu(3));
    }
    IEnumerator LoadSceneMenu(float duration)
    {
        loadingScreen.SetActive(true);
        menuScene.SetActive(false);
        yield return new WaitForSeconds(duration);
        loadScreen = true;
        loading = SceneManager.LoadSceneAsync(sceneIndex);

    }


    // Update is called once per frame
    void Update()
    {
        if(loadScreen)
        {
            progress.value = Mathf.Clamp01(loading.progress / 0.9f);
            perecent.text = Mathf.Round(progress.value * 100) + "%";
        }
    }
}
