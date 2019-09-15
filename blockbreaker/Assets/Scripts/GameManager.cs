﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int pointsPerBlock = 20;
  [SerializeField] TextMeshProUGUI scoreText;

  [SerializeField] bool isAutoPlayEnabled;

  [SerializeField] int currentScore = 0;
  // Start is called before the first frame update

  void Awake()
  {
    int gameManagerCount = FindObjectsOfType<GameManager>().Length;
    if (gameManagerCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }
  void Start()
  {
    scoreText.text = currentScore.ToString();
  }

  // Update is called once per frame
  void Update()
  {
    Time.timeScale = gameSpeed;

  }

  public void AddToScore()
  {
    currentScore += pointsPerBlock;
    scoreText.text = currentScore.ToString();
  }

  public void ResetScore()
  {
    Destroy(gameObject);
  }

  public bool IsAutoPlayEnabled()
  {
    return isAutoPlayEnabled;

  }


}
