using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGos : MonoBehaviour
{
    private Vector3 speed = new Vector3(0, 0, 0);
    public float acceleration = 1f;
    public float max_speed = 5f;
    public float decceleration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(horizontal_input > 0 || horizontal_input < 0 && speed.x < max_speed) {
            if(speed.x + acceleration > max_speed) {
                speed.x = max_speed;
            }
            else {
                speed.x += acceleration;
            }
        }
        else if(horizontal_input == 0) {
            if(speed.x - decceleration < 0) {
                speed.x = 0;
            }
            else {
                speed.x -= decceleration;
            }
        }

        if(verticalInput > 0 || verticalInput < 0 && speed.y < max_speed) {
            if(speed.y + acceleration > max_speed) {
                speed.y = max_speed;
            }
            else {
                speed.y += acceleration;
            }
        }
        else if(verticalInput == 0) {
            if(speed.y - decceleration < 0) {
                speed.y = 0;
            }
            else {
                speed.y -= decceleration;
            }
        }

        transform.position = transform.position + new Vector3(horizontal_input * speed* Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }
}
