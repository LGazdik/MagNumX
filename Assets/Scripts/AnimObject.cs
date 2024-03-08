using UnityEngine;

public class AnimObject : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
    }

    void Update()
    {

    }

    public void PlayMe()
    {
        anim.Play("bridge-u");
    }
}
