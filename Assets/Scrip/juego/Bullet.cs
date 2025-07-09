using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Invoke(nameof(DestroyBullet), 5f);
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EsqueleEnemy>() != null)
        {
            collision.GetComponent<EsqueleEnemy>().TomarDaño(5);
            Destroy(gameObject);
        }
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
