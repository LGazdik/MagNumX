using System;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    private bool canIteract = false;
    [SerializeField] private bool isFlipped = false;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform platform;

    [SerializeField] private Transform leverTransform;
    [SerializeField] private float smoothSpeed = .125f;

    public event Action NotifyLeverSwitchActivated;
    public event Action NotifyLeverSwitchDeActivated;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Interact()
    {
        if (canIteract != true) return;

        if (!isFlipped)
        {
            NotifyLeverSwitchActivated?.Invoke();
            leverTransform.Rotate(Vector3.forward, -90);
            isFlipped = !isFlipped;
        }
        else
        {
            NotifyLeverSwitchDeActivated?.Invoke();
            leverTransform.Rotate(Vector3.forward, 90);
            isFlipped = !isFlipped;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canIteract = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        canIteract = false;
    }
}
