using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
//   GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Restart();
    }
}
