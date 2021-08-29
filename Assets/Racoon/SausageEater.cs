using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SausageEater : MonoBehaviour
{
    public Exit exit;

    private int sausageMax = 0;
    private int sausageCount = 0;

    void Start()
    {
        sausageMax = FindObjectsOfType<Sausage>().Length;
        exit = FindObjectOfType<Exit>();
        if(exit == null)
        {
            Debug.LogWarning("Exit not exists");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EATER " + other.gameObject.name);
        if (other.gameObject.GetComponent<Sausage>() != null)
        {
            sausageCount++;
            if (sausageCount == sausageMax && exit != null)
            {
                exit.OpenDoor();
            }

            Destroy(other.gameObject);

        }
        else if (other.gameObject.GetComponent<Exit>() != null)
        {
            if (sausageCount == sausageMax)
            {
                Debug.Log("EXIT OPEN");
                StartCoroutine(LoadNextScene());
            }
            else
            {
                Debug.Log("EXIT CLOSED");
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        yield return SceneManager.UnloadSceneAsync(currentScene);
        yield return SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        yield break;
    }
}
