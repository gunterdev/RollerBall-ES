using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.
        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.

        private Transform cam; // A reference to the main camera in the scenes transform
        private Vector3 camForward; // The current forward direction of the camera
        private bool jump; // whether the jump button is currently pressed
        public bool canClimb;
        private Rigidbody m_Rigidbody;

        public float maxSpeed;

        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();
            m_Rigidbody = GetComponent<Rigidbody>();


            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
            }
        }


        private void Update()
        {
            // Get the axis and jump input.

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            jump = CrossPlatformInputManager.GetButton("Jump");
            if (h == 0 && v==0)
            {
                m_Rigidbody.angularVelocity = Vector3.zero;
            }

            // calculate move direction
            if (cam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (camForward*v + cam.right*h).normalized;
                if(m_Rigidbody.velocity.magnitude > maxSpeed)
                {
                    Vector3 vel = Vector3.ClampMagnitude(m_Rigidbody.velocity,maxSpeed);
                    vel.y = m_Rigidbody.velocity.y;
                    m_Rigidbody.velocity = vel;
                }
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (v*Vector3.forward + h*Vector3.right).normalized;
            }
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            
            if(canClimb)
            {
                ball.Climb(move);
            }
            else
            {
                ball.Move(move, jump);
            }
            jump = false;
        }

        
        public void OnCollisionEnter(Collision other) {
            if(other.gameObject.tag.Equals("Wall"))
            {
                canClimb=true;
                m_Rigidbody.useGravity = false;
            }
        }
        public void OnCollisionExit(Collision other) {
            if(other.gameObject.tag.Equals("Wall"))
            {
                m_Rigidbody.useGravity = true;
                canClimb=false;
            }
        }
    }
}
