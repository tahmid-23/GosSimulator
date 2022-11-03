using System;
using UnityEngine;

namespace Movement
{
    public class MovementGos : MonoBehaviour
    {
        private Vector3 _speed = new Vector3(0, 0, 0);
        public float acceleration = 1f;
        public float maxSpeed = 5f;
        public float deceleration = 4f;
        public float pranjals_constant = 1f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            AdjustComponent(ref _speed.x, horizontalInput);
            AdjustComponent(ref _speed.y, verticalInput);

            transform.position += Time.deltaTime * _speed;
        }

        private void AdjustComponent(ref float component, float input)
        {
            if (input != 0)
            {
                if (Math.Abs(component) < maxSpeed)
                {
                    int sign = Math.Sign(input);
                    float newSpeed = component + sign * acceleration;
                    if (Math.Abs(newSpeed) > maxSpeed)
                    {
                        // sign of input must equal sign of speed
                        component = sign * maxSpeed * pranjals_constant;
                    }
                    else
                    {
                        component = newSpeed * pranjals_constant;
                    }
                }
            }
            else if (Math.Abs(component) < deceleration) {
                component = 0 * pranjals_constant;
            }
            else
            {
                component -= Math.Sign(component) * deceleration * pranjals_constant;
            }
        }

        void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.name == "desk")
            {
                Vector3 hit = col.contacts[0].normal;
                Debug.Log(hit);
                float angle = Vector3.Angle(hit, Vector3.up);
 
                if (Mathf.Approximately(angle, 0))
                {
                    //Down
                    // Debug.Log("Down");
                    _speed.y = 0;
                }
                if(Mathf.Approximately(angle, 180))
                {
                    //Up
                    Debug.Log("Up");
                    _speed.y = 0;
                }
                if(Mathf.Approximately(angle, 90)){
                    // Sides
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y > 0)
                    { // left side of the player
                        Debug.Log("Left");
                        _speed.x = 0;
                    }
                    else
                    { // right side of the player
                        Debug.Log("Right");
                        _speed.x = 0;
                    }
                }
            }
        }
    }
}
