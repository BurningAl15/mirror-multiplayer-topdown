using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace inart.TopDown2D
{
    public class Bullet : NetworkBehaviour
    {
        public GameObject hitEffect;

        [SerializeField] private Rigidbody2D rgb;
        private PlayerMovement temp;
        // private void OnCollisionEnter2D(Collision2D collision)
        // {
        //     if (collision.gameObject.CompareTag("Player"))
        //     {
        //         // GameObject effect = Instantiate(hitEffect, this.transform.position, Quaternion.identity);
        //         // Destroy(effect, 1f);
        //         collision.gameObject.GetComponent<PlayerMovement>().KnockBack(transform.position);
        //         Destroy(this.gameObject);
        //     }
        // }
        
        public override void OnStartServer()
        {
            base.OnStartServer();
            // rgb.simulated = true;
        }

        // [ServerCallback]
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // GameObject effect = Instantiate(hitEffect, this.transform.position, Quaternion.identity);
                // Destroy(effect, 1f);
                if (temp == null)
                    temp = other.GetComponent<PlayerMovement>();
                temp.KnockBack(transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}