using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float missileSpeed = 5f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += Vector3.right * missileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
