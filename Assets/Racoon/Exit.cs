using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject gradient;
    
    void Start()
    {
        gradient.SetActive(false);
    }
    public void OpenDoor() {
        Debug.Log("OPEN DOOR");
        gradient.SetActive(true);
    }
}
