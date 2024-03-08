using UnityEngine;

[System.Serializable]
public class InteractionTree : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyMe()
    {
        m_Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        m_Rigidbody.AddForce(transform.up * 100f, ForceMode2D.Impulse);
    }
    void OnBecameInvisible() { Destroy(gameObject); }
}

