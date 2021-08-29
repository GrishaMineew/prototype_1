using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonStartPosition : MonoBehaviour
{
    public PathAgent racoonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate<PathAgent>(racoonPrefab);
    }
}
