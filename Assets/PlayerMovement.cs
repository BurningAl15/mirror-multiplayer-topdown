using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Mirror;


namespace inart.TopDown2D
{
    public class PlayerMovement : NetworkBehaviour
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

        [SerializeField] private Shooting _shooting;

        private void Awake()
        {
            cam = Camera.main;
        }

        void Update()
        {
            if (knockBackCounter <= 0)
            {
                if (!cantMove)
                {
                    //Horizontal Movement
                    if (isLocalPlayer)
                    {
                        Movement_Input();
                        _shooting.ShootAction();
                    }
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;
                rgb.velocity = -_direction * knockBackForce.x;
            }
        }

        void Movement_Input()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
        private void FixedUpdate()
        {
            if (knockBackCounter <= 0)
            {
                if (isLocalPlayer)
                {
                    Rotate();
                }
            }
        }

        void Rotate()
        {
            rgb.MovePosition(rgb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookdir = mousePos - rgb.position;
            float angle = Mathf.Atan2(lookdir.y,lookdir.x)*Mathf.Rad2Deg - 90f;
            rgb.rotation = angle;
        }
        
        public void KnockBack(Vector2 targetPos)
        {
            knockBackCounter = knockBackLength;
            _direction = targetPos - new Vector2(transform.position.x, transform.position.y);
            // rgb.velocity = new Vector2(0, knockBackForce.y);
        }
    }
}
