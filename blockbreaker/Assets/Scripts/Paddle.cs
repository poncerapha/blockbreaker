using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
  [SerializeField] float screenWidthInUnits = 16f;
  [SerializeField] float minValue = 1f;
  [SerializeField] float maxValue = 15f;

  Ball ball;
  GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    ball = FindObjectOfType<Ball>();
    gameManager = FindObjectOfType<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
    paddlePos.x = Mathf.Clamp(GetXPos(), minValue, maxValue);
    transform.position = paddlePos;
  }

  private float GetXPos()
  {
    if (gameManager.IsAutoPlayEnabled())
    {
      return ball.transform.position.x;
    }
    else
    {
      return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
  }
}
