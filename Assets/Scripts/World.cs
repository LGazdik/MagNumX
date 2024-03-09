using UnityEngine;

public class World : MonoBehaviour
{
    private bool IsUp = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightShift) && Input.GetKeyUp(KeyCode.LeftShift))
        {
            FlipWorld();
        }
    }

    public void FlipWorld()
    {
        Debug.Log("Fliper not fliping");
        if (IsUp)
        {
            IsUp = false;
            transform.rotation = Quaternion.Euler(new Vector2(-180, 0));
        }
        else
        {
            IsUp = true;
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }

    }
}
