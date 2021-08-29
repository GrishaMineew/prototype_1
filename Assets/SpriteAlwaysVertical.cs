using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAlwaysVertical : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * -transform.rotation.z);
    }
}
