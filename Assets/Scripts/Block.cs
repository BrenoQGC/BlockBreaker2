using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound=null;
    [SerializeField] GameObject blockSparcklesVFX=null;
  //  [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit; //TODO serialized for debug
   
    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        CoutBreakableBlocks();
    }

    private void CoutBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.CountBlocks();
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit -1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array");
        }
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
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
        gameStatus.AddToScore();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVXF();
    }

    private void TriggerSparklesVXF()
    {
        GameObject sparkles = Instantiate(blockSparcklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
