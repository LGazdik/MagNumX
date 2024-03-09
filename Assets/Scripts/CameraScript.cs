using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public movement PlayerUP;
    public movement2 PlayerDOWN;

    public float bound;

    void Update()
    {
        transform.position = (PlayerUP.transform.position + PlayerDOWN.transform.position) * 0.5f;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bound, bound), 0f, -10f);
    }
}
