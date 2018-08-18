using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _frequency;

    private void Update()
    {
        transform.position += Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad * _frequency) * _range;
    }
}
