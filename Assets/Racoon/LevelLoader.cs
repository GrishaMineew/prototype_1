using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance {get;set;}

    public string[] levels;
    public GameObject canvas;
    public GameObject winMenu;

    private string currentLevelname;

    void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(int levelNum) {
        Debug.Log("LOAD " + currentLevelname);
        currentLevelname = levels[levelNum];
        canvas.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(currentLevelname, LoadSceneMode.Additive);
    }

    public void OnFail() {
        Debug.Log("ON FAIL");
        // StartCoroutine(LoadScene(currentLevelname));
        Replay();
    }

    public void OnSuccess() {
        Debug.Log("ON SUCCESS");
        StartCoroutine(LoadScene(levels[1]));
        // winMenu.SetActive(true);
    }

    public void InstanceReplay() {
        Replay();
    }

    public static void Replay() {
        string current = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(current);
    }

    public void NextLevel() {
        StartCoroutine(LoadScene(levels[1]));
    }

    public void Exit() {
        Application.Quit();
    }

    IEnumerator LoadScene(string sceneName) {
        yield return SceneManager.UnloadSceneAsync(currentLevelname);
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield break;
    }

}
