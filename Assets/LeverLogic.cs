using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{
    private bool canIteract = false;
    [SerializeField] private bool isFlipped = false;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform platform;

    [SerializeField] private Transform leverTransform;
    [SerializeField] private float smoothSpeed = .125f;


    [SerializeField] bool isMirrorLever = false;
    [SerializeField] Vor vorToChange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        if (platform == null) return;

        if (isFlipped == true)
        {
            platform.position = Vector3.MoveTowards(platform.transform.position, pointA.position, Time.deltaTime * smoothSpeed);
        }
        if (isFlipped == false)
        {
            platform.position = Vector3.MoveTowards(platform.transform.position, pointB.position, Time.deltaTime * smoothSpeed);
        }



    }

    public void Interact()
    {

        if (canIteract)
        {
            if (!isFlipped)
            {
                leverTransform.Rotate(Vector3.forward, -90);
                isFlipped = !isFlipped;

            }
            else
            {
                leverTransform.Rotate(Vector3.forward, 90);
                isFlipped = !isFlipped;
            }

            if (isMirrorLever)
            {
                vorToChange.isMirrored = !vorToChange.isMirrored;
                //GFX
                //posunoutPlatformu
            }
         
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
