using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Rigidbody TargetPosition;
    private Rigidbody g_FollowerPosition;
    void Awake() {
        g_FollowerPosition = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        g_FollowerPosition.velocity = TargetPosition.velocity;
    }
}
