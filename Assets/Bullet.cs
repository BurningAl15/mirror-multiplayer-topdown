using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace inart.TopDown2D
{
    public class Bullet : MonoBehaviour
    {
        public GameObject hitEffect;

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