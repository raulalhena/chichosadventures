using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Chicho;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Chicho.transform.position.x;
        position.y = Chicho.transform.position.y;
        transform.position = position;
    }
}
