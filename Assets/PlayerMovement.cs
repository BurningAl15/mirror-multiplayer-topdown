using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace inart.TopDown2D
{
    public class PlayerMovement : MonoBehaviour
    {
        [FormerlySerializedAs("canMove")] [SerializeField] private bool cantMove;
        public float moveSpeed = 5f;
        public Rigidbody2D rgb;

        public Camera cam;

        Vector2 movement;

        Vector2 mousePos;
        
        [Header("Knockback Effect Variables")] 
        public float knockBackLength;
        public Vector2 knockBackForce;
        public float knockBackCounter;

        private Vector2 _direction;

        void Update()
        {
            if (knockBackCounter <= 0)
            {
                if (!cantMove)
                {
                    //Horizontal Movement
                    Movement();
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;
                rgb.velocity = -_direction * knockBackForce.x;
            }
        }

        void Movement()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
        private void FixedUpdate()
        {
            if (knockBackCounter <= 0)
            {
                rgb.MovePosition(rgb.position + movement * moveSpeed * Time.fixedDeltaTime);

                Vector2 lookdir = mousePos - rgb.position;
                float angle = Mathf.Atan2(lookdir.y,lookdir.x)*Mathf.Rad2Deg - 90f;
                rgb.rotation = angle;
            }
        }
        
        public void KnockBack(Vector2 targetPos)
        {
            knockBackCounter = knockBackLength;
            _direction = targetPos - new Vector2(transform.position.x, transform.position.y);
            // rgb.velocity = new Vector2(0, knockBackForce.y);
        }
    }
}
