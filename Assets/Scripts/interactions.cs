using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour
{
    public Transform inter;
    public float interactiveColliderSize;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, interactiveColliderSize);
        foreach (Collider2D col in cols)
        {
            Debug.Log(col);
            if (col.GetComponent<InteractionTree>() is InteractionTree i)
            {
                i.DestroyMe();
            }

            if (col.GetComponent<AnimObject>() is AnimObject a)
            {
                a.PlayMe();
            }

            if (col.GetComponent<Portal>() is Portal p)
            {
                p.TelepActivate();
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(inter.position, interactiveColliderSize);
    }
}
