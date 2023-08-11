using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] ParticleSystem explosionEffect;
    void Update()
    {
        float _vertical = Input.GetAxis("Vertical");
        float _horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(_horizontal * speed * Time.deltaTime, 0f, _vertical * speed * Time.deltaTime);

        //transform.position.x = Mathf.Clamp(transform.position.x, -2.0f, 2.0f);
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -4.7f, 4.7f);
        pos.z = Mathf.Clamp(transform.position.z, -2.6f, 2.6f);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            gameOver();
        }
    }

    void gameOver()
    {
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        UiManager.instance.GameOver();
        Destroy(gameObject);
    }
}
