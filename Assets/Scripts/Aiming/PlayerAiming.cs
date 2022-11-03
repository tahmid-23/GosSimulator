using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{

    private bool _isAiming;
    private Transform _player;
    public Camera camera;
    private float _angle;
    
    //TEMPORARY VARIABLE
    private int direction = 0;
    //VALUE WILL BE OBTAINED FROM MOVEMENT SCRIPT
    
    private const int R = 5;

    // Start is called before the first frame update
    void Start()
    {
        _isAiming = false;
        _player = transform;
        _angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        testInput();
        drawTestCone(direction);
        _angle = Mathf.Clamp(getAngle(), (2*direction-1)*Mathf.PI/8, (2*direction+1)*Mathf.PI/8);
        Vector3 endpoint = new Vector3(R*Mathf.Cos(_angle), R*Mathf.Sin(_angle), 0);
        Debug.DrawLine(_player.position, endpoint, Color.red, Time.deltaTime);
        
    }
    
    public bool IsAiming()
    {
        return _isAiming;
    }

    private float getAngle()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = camera.WorldToScreenPoint(_player.position);
        float dx = mousePos.x - playerPos.x;
        float dy = mousePos.y - playerPos.y;
        if (dx < 0)
        {
            return Mathf.Atan(dy/dx) + Mathf.PI;
        }

        return Mathf.Atan(dy / dx);
    }

    private void drawTestCone(int n)
    {
        Vector3 endpoint1 = new Vector3(R*Mathf.Cos((2*n-1)*Mathf.PI/8), R*Mathf.Sin((2*n-1)*Mathf.PI/8)) + _player.position;
        Vector3 endpoint2 = new Vector3(R*Mathf.Cos((2*n+1)*Mathf.PI/8), R*Mathf.Sin((2*n+1)*Mathf.PI/8)) + _player.position;
        Debug.DrawLine(_player.position, endpoint1, Color.black, Time.deltaTime);
        Debug.DrawLine(_player.position, endpoint2, Color.black, Time.deltaTime);
    }

    private void testInput()
    {
        if (Input.GetKeyDown("d"))
        {
            direction = 0;
        }
        if (Input.GetKeyDown("e"))
        {
            direction = 1;
        }
        if (Input.GetKeyDown("w"))
        {
            direction = 2;
        }
        if (Input.GetKeyDown("q"))
        {
            direction = 3;
        }
        if (Input.GetKeyDown("a"))
        {
            direction = 4;
        }
        if (Input.GetKeyDown("z"))
        {
            direction = 5;
        }
        if (Input.GetKeyDown("s"))
        {
            direction = 6;
        }
        if (Input.GetKeyDown("c"))
        {
            direction = 7;
        }
    }
}
