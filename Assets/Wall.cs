using System;
using System.Collections;
using System.Collections.Generic;
using Script.Map;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col){
        // var other = col.rigidbody;
        // if (other == null) return;
        // var dice = other.GetComponent<Dice>();
        // if (dice == null) return;
        // var points = new List<ContactPoint2D>();
        // col.GetContacts(points);
        // var nor = points[0].normal;
        // var vel = other.velocity;
        // if (Vector2.Dot(nor, vel) < 0) nor = -nor;
        // var proj = nor.normalized * (vel.magnitude * Mathf.Cos(Vector2.Angle(nor, vel) * Mathf.Deg2Rad));
        // other.velocity = proj * 2 - vel;
    }
}
