using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  [SerializeField] Paddle paddle1;
  [SerializeField] float xPush = 2f;
  [SerializeField] float yPush = 15f;
  [SerializeField] AudioClip[] ballSounds;

  [SerializeField] float randomFactor = 0.5f;


  Vector2 paddleToBallVector;

  private bool isBauncing = false;


  AudioSource audioSource;

  Rigidbody2D rigidbody2D;

  // Start is called before the first frame update
  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    rigidbody2D = GetComponent<Rigidbody2D>();
    paddleToBallVector = transform.position - paddle1.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    LockBallToPaddle();
    LauchOnMouseClick();

  }

  private void LauchOnMouseClick()
  {
    if (Input.GetMouseButtonDown(0) && isBauncing == false)
    {
      Debug.Log("Launching the ball");
      rigidbody2D.velocity = new Vector2(xPush, yPush);
      isBauncing = true;

    }
  }

  private void LockBallToPaddle()
  {
    if (!isBauncing)
    {
      Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
      transform.position = paddlePos + paddleToBallVector;
    }

  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
    if (isBauncing)
    {
      AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
      audioSource.PlayOneShot(clip);
      rigidbody2D.velocity += velocityTweak;



    }

  }
}
