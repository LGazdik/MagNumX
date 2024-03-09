using UnityEngine;

public class interactions : MonoBehaviour
{
    public Transform inter;
    public float interactiveColliderSize;
    public KeyCode interactionButton;

    private bool inPortal = false;

    void Update()
    {
        if (Input.GetKeyDown(interactionButton))
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

                if (inPortal == false)
                {
                    inPortal = true;
                    if (p != null && p.portalActivated)
                    {
                        if (GetComponent<Rigidbody2D>() is Rigidbody2D r)
                            r.constraints = RigidbodyConstraints2D.FreezePosition;
                        GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
                else
                {
                    inPortal = false;
                    if (p != null && !p.portalActivated)
                    {
                        if (GetComponent<Rigidbody2D>() is Rigidbody2D r)
                            r.constraints = RigidbodyConstraints2D.FreezeRotation;
                        GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }

            if (col.GetComponent<LeverLogic>() is LeverLogic l)
                l.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(inter.position, interactiveColliderSize);
    }
}
