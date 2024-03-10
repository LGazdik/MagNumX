using System;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private List<Transform> FlyPoints;
    [SerializeField] private Transform LureTarget;
    private Transform NextPos;
    private int PosIndex;

    [SerializeField] private LeverSwitch switcher;
    [SerializeField] private float FlySpeed;

    private Action currentMovement;

    void Start()
    {
        NextPos = FlyPoints[0];
        currentMovement = MoveStandard;
        switcher.NotifyLeverSwitchActivated += AssignLuredMoving;
        switcher.NotifyLeverSwitchDeActivated += AssignStandardMoving;
    }

    void Update()
    {
        currentMovement();
    }

    private void MoveStandard()
    {
        if (transform.position == NextPos.position)
        {
            PosIndex++;
            NextPos = FlyPoints[PosIndex % FlyPoints.Count];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, NextPos.position, Time.deltaTime * FlySpeed);
        }
    }
    private void MoveLured()
    {
        transform.position = Vector2.MoveTowards(transform.position, LureTarget.position, Time.deltaTime * FlySpeed);
    }

    private void AssignStandardMoving()
    {
        Debug.Log("Mover standard");
        currentMovement = MoveStandard;

    }
    private void AssignLuredMoving()
    {
        Debug.Log("Mover lured");
        currentMovement = MoveLured;
    }
}
