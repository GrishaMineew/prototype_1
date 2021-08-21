using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SausageEater : MonoBehaviour
{
    public Exit exit;
    public string sceneNext;

    private int sausageMax = 0;
    private int sausageCount = 0;

    void Start()
    {
        sausageMax = FindObjectsOfType<Sausage>().Length;
        exit = FindObjectOfType<Exit>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Sausage>() != null)
        {
            sausageCount++;
            if (sausageCount == sausageMax)
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
        string currentScene = SceneManager.GetActiveScene().name;
        yield return SceneManager.UnloadSceneAsync(currentScene);
        yield return SceneManager.LoadSceneAsync(sceneNext);
        yield break;
    }
}
