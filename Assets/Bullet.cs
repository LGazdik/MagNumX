using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject boom = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(boom, 2f);
        AudioSource ac = GetComponent<AudioSource>();
        ac.Play();

        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.Restart();
            movement jo = collision.gameObject.GetComponent<movement>();
            if (jo != null)
            {
                jo.Die();
                Debug.Log("We aredead");
            }
        }
        Destroy(gameObject/*,0.5f*/);

    }
}
