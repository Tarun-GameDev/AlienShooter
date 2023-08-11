using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;

    [SerializeField] Vector3 posOffset;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missilePrefab,transform.position + posOffset, Quaternion.identity);
        }
    }
}
