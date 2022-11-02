using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    [SerializeField]float rotSpeed = 5f;
    Vector3 rotation = Vector3.zero;
    void Update()
    {
        rotation.z += rotSpeed * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }
}
