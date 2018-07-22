using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private float progressBar;
    [SerializeField] private float chargeTime;

    public void Test()
    {
        progressBar += 0.1f;
        if(progressBar >= chargeTime)
            Debug.Log($"End");
    }
}
