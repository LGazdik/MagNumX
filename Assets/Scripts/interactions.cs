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
            if (col.GetComponent<InteractionTree>() != null)
            {
                var obj = col.GetComponent<InteractionTree>();
                obj.DestroyMe();
            }

            if (col.GetComponent<AnimObject>() != null)
            {
                var obj = col.GetComponent<AnimObject>();
                obj.PlayMe();
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(inter.position, interactiveColliderSize);
    }
}
