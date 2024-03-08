using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour
{
    public Transform inter;
    public float interactiveColliderSize;
    void Start()
    {
        
    }

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
            if (col.GetComponent<Tree>() != null)
            {
                var obj = col.GetComponent<Tree>();
                obj.DestroyMe();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(inter.position, interactiveColliderSize);
    }
}
