using System;
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
        _angle = ClampAngle(FixAngle180(getAngle()), FixAngle180((2 * direction - 1) * Mathf.PI / 8), FixAngle180((2*direction+1)*Mathf.PI/8));
        Vector3 endpoint = new Vector3(R*Mathf.Cos(_angle), R*Mathf.Sin(_angle), 0);
        Debug.DrawRay(_player.position, endpoint, Color.red, Time.deltaTime);
        
    }
    
    public bool IsAiming()
    {
        return _isAiming;
    }

    private float getAngle()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = _player.position;
        float dx = mousePos.x - playerPos.x;
        float dy = mousePos.y - playerPos.y;

        return Mathf.Atan2(dy, dx);
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

    private static float FixAngle360(float angle)
    {
        if (angle < 0)
        {
            return angle + 2 * Mathf.PI;
        }

        if (angle >= 360)
        {
            return angle - 2 * Mathf.PI;
        }

        return angle;
    }

    private static float FixAngle180(float angle)
    {
        if (angle > Mathf.PI)
        {
            return angle - 2 * Mathf.PI;
        }

        return angle;
    }

    private static float ClampAngle(float angle, float from, float to)
    {
        from = FixAngle360(from);
        to = FixAngle360(to);
        angle = FixAngle360(angle);
        float mid = FixAngle180(from + FixAngle360(to - from) / 2);
        float fromNye = FixAngle180(from - mid);
        float toNye = FixAngle180(to - mid);
        float angleNye = FixAngle180(angle - mid);

        return Mathf.Clamp(angleNye, fromNye, toNye) + mid;
    }
    
}
