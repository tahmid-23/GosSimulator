using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

public class MeleeCombat : MonoBehaviour
{
    // Update is called once per frame
    public double _radius = 5.0;

    private bool charge_boolean = false;
    private GameObject otherGameObject;

    private BoxCollider2D _boxCollider2D;

    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            charge_boolean = false;
            transform.position += new Vector3(-2, 0);
        }
    }

    void Update()
    { 
        if (CollisionDetection.IsTouching(transform.gameObject, otherGameObject))
        {
            Debug.Log("Touched");
        }
        
        if (charge_boolean)
        {
            double dx = (otherGameObject.transform.position.x - transform.position.x);
            double dy = (otherGameObject.transform.position.y - transform.position.y);
                
            transform.position += new Vector3((float) dx * Time.deltaTime, (float) dy * Time.deltaTime);
        }
    }

    public GameObject ObjectClickedGameObject()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        otherGameObject = rayHit.rigidbody.gameObject;
        return rayHit.rigidbody.gameObject;
    }

    public bool IsMeleeAllowed()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        Transform other = rayHit.transform;

        double dx = Math.Abs(other.position.x - getX());
        double dy = Math.Abs(other.position.y - getY());

        double length = Math.Sqrt((dx * dx) + (dy * dy));

        return (length < _radius);
    }

    // Speed from 1-5? Idk it works for now
    public void ConductMeleeAttack(GameObject initialPlayer, GameObject targetPlayer, int speed)
    {
        charge_boolean = true;
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
