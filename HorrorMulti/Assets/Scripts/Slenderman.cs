﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slenderman : MonoBehaviour
{
    public Transform character;
    private Rigidbody rb;
    public float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, character.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(position);
        transform.LookAt(character);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    internal void PlayerDeath(bool damageToGive)
    {
        throw new NotImplementedException();
    }
}
