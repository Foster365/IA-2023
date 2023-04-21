using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Timer timer;

    private void Awake()
    {
        timer = GetComponent<Timer>();
    }
    private void Update()
    {
        timer.RunTimer();
    }
}
