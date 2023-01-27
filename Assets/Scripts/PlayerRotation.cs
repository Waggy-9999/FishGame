using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        Quaternion lookQuaternion = transform.rotation * Quaternion.AngleAxis(180, Vector3.up);
        transform.rotation = lookQuaternion;
    }

}
