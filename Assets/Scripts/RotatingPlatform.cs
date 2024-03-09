using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    private HingeJoint2D hinge;
    public float rotationSpeed = 100f; // Adjust this value to control rotation speed

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();

    }

}
