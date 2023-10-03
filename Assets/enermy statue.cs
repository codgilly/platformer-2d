using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enermystatue : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 8f;

    void Start()
    {

    }

    void Update()
    {
        float x = player.transform.position.x - transform.position.x;
        
        if (player != null )
        {
            Vector3 direction = (player.position  - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }


    }
}
