using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float missileSpeed = 5f;
    [SerializeField] GameObject enemyModel;
    [SerializeField] ParticleSystem explosionEffect;
    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        transform.position += Vector3.right * missileSpeed * Time.deltaTime;
        enemyModel.transform.Rotate(new Vector3(0f, -190f * Time.deltaTime, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Missile"))
        {
            UiManager.instance.Kills();
            if (explosionEffect != null)
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
           
    }
}
