using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGos : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontal_input * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }
}
