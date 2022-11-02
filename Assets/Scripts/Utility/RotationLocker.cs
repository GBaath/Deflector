using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLocker : MonoBehaviour
{
    public Quaternion lockedRotation;
    void LateUpdate()
    {
        transform.rotation = lockedRotation;
    }
}
