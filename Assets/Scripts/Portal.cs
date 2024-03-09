using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public CapsuleCollider2D col;
    public bool portalActivated = false;

    public static List<Portal> portals = new();

    private void Start()
    {
        portals = FindObjectsOfType<Portal>().ToList();
        foreach (var p in portals)
        {
            Debug.LogWarning(p);
        }
        Portal.ActivatedPortal += CatchPortalSignals;
    }

    public void TelepActivate()
    {
        //Debug.Log("portal activated " + this.GetInstanceID());
        if (portalActivated)
        {
            portalActivated = false;
        }
        else
        {
            portalActivated = true;
            ActivatedPortal?.Invoke();
        }
    }

    public static event Action ActivatedPortal;

    public void CatchPortalSignals()
    {
        Debug.LogWarning("Signal portal catched");
        bool bothActive = true;
        foreach (var p in portals)
        {
            if (!p.portalActivated) bothActive = false;
        }
        if (bothActive) GameManager.Instance.NextLevel();
    }
}
