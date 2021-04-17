using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace inart.TopDown2D
{
    public class Shooting : MonoBehaviour
    {
        public Transform[] firePoints=new Transform[2];
        public GameObject bulletPrefab;

        public float bulletForce = 20f;
        int index=0;

        //Thinking in two shootpoints (right and left)
        void Shoot()
        {
            GameObject bullet= Instantiate(bulletPrefab, firePoints[index % 2 == 0 ? 0 : 1].position, firePoints[index % 2 == 0 ? 0 : 1].rotation);
            Rigidbody2D rgb = bullet.GetComponentInChildren<Rigidbody2D>();
            rgb.AddForce(firePoints[index % 2 == 0 ? 0 : 1].up * bulletForce, ForceMode2D.Impulse);
            index++;
        }

        public void ShootAction()
        {
            if (Input.GetButtonDown("Fire1"))
                Shoot();
        }
        
    }
}
