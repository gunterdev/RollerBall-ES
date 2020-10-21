using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.0f, 10.0f)] public float Force;
    [Range(0.0f, 25.0f)] public float MaxAngularVelocity;
    [Range(0.0f, 25.0f)] public float maxSpeed;
    private Rigidbody g_rb;
    private float g_horizontalAxis;
    private float g_verticalAxis;
    void Awake()
    {
        g_rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = MaxAngularVelocity;
    }

    void FixedUpdate()
    {
        if(g_rb.velocity.magnitude > maxSpeed)
        {
            g_rb.velocity = g_rb.velocity.normalized * maxSpeed;
        }
    }
    void Update()
    {
        g_horizontalAxis = Input.GetAxisRaw("Horizontal");
        g_verticalAxis = Input.GetAxisRaw("Vertical");
        if(g_horizontalAxis != 0 || g_horizontalAxis != 0)
        {
            g_rb.AddForce((g_horizontalAxis*Force),0f,(g_verticalAxis*Force), ForceMode.VelocityChange);

        }

    }
}
