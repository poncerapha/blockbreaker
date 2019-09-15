using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    [SerializeField] int currentHits;
    [SerializeField] Sprite[] hitSprites;

    LevelManager levelManager;

    GameManager gameManager;

    [SerializeField] GameObject particle;


    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
        if (this.tag == "Breakable")
        {
            levelManager.CountBlocks();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Breakable")
        {
            Debug.Log("Collision!!!");
            HandleHit();

        }

    }

    private void HandleHit()
    {
        currentHits++;
        int maxHits = hitSprites.Length + 1;
        if (currentHits >= maxHits)
        {

            DestroyBlock();

        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = currentHits - 1;
        if (spriteIndex != null)
        {
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = hitSprites[spriteIndex];

        }
        else
        {
            Debug.LogError("Block sprite is missing from array, the gameobject: " + this.gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gameManager.AddToScore();
        Destroy(this.gameObject);
        levelManager.BlockDestroyed();
        TriggerParticle();
    }

    private void TriggerParticle()
    {
        GameObject particles = Instantiate(particle, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
