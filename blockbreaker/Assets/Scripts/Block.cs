﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!!!");
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(this.gameObject);

    }
}
