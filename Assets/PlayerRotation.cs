using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        Quaternion rot = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z);
    }
}
