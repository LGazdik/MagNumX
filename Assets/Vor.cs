using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] Rigidbody2D player;
    private bool isLockedOnBoat = false;
    bool isOnBoat = false;
    public bool isMirrored = false;
    [SerializeField] private Transform platform;
    float x;
    [SerializeField] float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (isOnBoat)
        {
            //Interact();

            if (isOnBoat && isLockedOnBoat)
            {
                if(transform.position.x  + 0.3f < xLimit)
                {
                     transform.position += new Vector3(x, 0, 0);

                }
                if (platform != null)
                {
                    if (!isMirrored)
                    {
                        platform.position += new Vector3(x, 0, 0);
                    }
                    if (isMirrored)
                    {
                        platform.position -= new Vector3(x, 0, 0);
                    }
                }
            }
        }
    }

    public void Interact()
    {
        Debug.Log("dari se");
        if (!isOnBoat) return;

        isLockedOnBoat = !isLockedOnBoat;
        player.constraints = isLockedOnBoat ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform);
        isOnBoat = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null);
        isOnBoat = false;
    }
}
