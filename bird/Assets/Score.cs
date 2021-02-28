using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text text;

    public static int  x = 0;

    private void Start()
    {
        text.GetComponent<Text>();
    }
    private void Update()
    {
        text.text = x.ToString();
    }
}
