using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip brakeSound;
    [SerializeField] AudioClip DestroySound;
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int pointsPerBlock;

    // cached reference
    Level level;
    GameStatus gameStatus;

    // state variables
    [SerializeField] int timesHit; //TODO only Serialized for debug 


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            PlayBlockDestroySFX(DestroySound);
            DestroyBlock();
        }
        else
        {
            PlayBlockDestroySFX(brakeSound);
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites[timesHit - 1])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        {
            Debug.LogError("Block sprite is missing form array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        TriggerBlockDistroyVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void TriggerBlockDistroyVFX()
    {
        GameObject blockVFX = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        Destroy(blockVFX, 1f);
    }

    private void PlayBlockDestroySFX(AudioClip clip)
    {
        gameStatus.AddToScore(pointsPerBlock);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
