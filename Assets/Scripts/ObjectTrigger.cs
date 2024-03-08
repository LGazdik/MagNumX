using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectTrigger : MonoBehaviour
{
    public GameObject SelectedObject;
    public GameObject AffectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(SelectedObject);
        Destroy(AffectedObject);
    }
}
