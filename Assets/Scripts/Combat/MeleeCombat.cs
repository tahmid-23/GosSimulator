using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeleeCombat : MonoBehaviour
{
    // Update is called once per frame
    public double radius = 2.0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Melee Combat Mode is activated");
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.transform.name);
        }
    }

    public String objectClickedName()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        return rayHit.transform.name;
    }

    public bool isMeleeAllowed()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        Transform transform = rayHit.transform;

        double dx = Math.Abs(transform.position.x - getX());
        double dy = Math.Abs(transform.position.y - getY());

        double length = Math.Sqrt((dx * dx) + (dy * dy));

        return (length < radius);
    }

    private double getX()
    {
        return transform.position.x;
    }

    private double getY()
    {
        return transform.position.y;
    }
}
