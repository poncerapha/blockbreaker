﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over");
        if (collision.gameObject.name == "Ball")
        {

            SceneManager.LoadScene("Game Over");
        }
    }
}
