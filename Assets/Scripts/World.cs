using UnityEngine;

public class World : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void FlipWorld()
    {
        if(Input.GetKeyUp(KeyCode.RightShift) && Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Fliper not fliping");
            transform.rotation = Quaternion.Euler(new Vector2(-1,0));
        }
    }
}
