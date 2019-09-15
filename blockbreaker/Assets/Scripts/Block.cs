using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  [SerializeField] AudioClip breakSound;

  LevelManager levelManager;

  GameManager gameManager;


  private void Start()
  {
    levelManager = FindObjectOfType<LevelManager>();
    gameManager = FindObjectOfType<GameManager>();
    levelManager.CountBlocks();
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Collision!!!");
    gameManager.AddToScore();
    DestroyBlock();

  }

  private void DestroyBlock()
  {
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    Destroy(this.gameObject);
    levelManager.BlockDestroyed();
  }
}
