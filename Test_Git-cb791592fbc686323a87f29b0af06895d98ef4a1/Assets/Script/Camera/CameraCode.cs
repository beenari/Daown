using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraCode : MonoBehaviour
{
    public Transform TarGet;
    public float Tum = 2f;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, TarGet.position, Time.deltaTime * Tum);
        transform.position = new Vector3(transform.position.x,transform.position.y,-10f);
    }
}
