using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textLogic : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    int index = 0;
    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            texts[index].SetActive(true);
            index++;
            if (index == texts.Length - 1)
            {
                GameManager.Instance.NextLevel();
            }
        }
    }
}
