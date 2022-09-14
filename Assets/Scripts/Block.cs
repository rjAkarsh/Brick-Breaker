using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] blockSprites;
    [SerializeField] int timesHit = 0;
    Level level;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag =="Breakable")
            level.BlocksCounter();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        timesHit++;
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        if (tag == "Breakable")
        {
            if(timesHit >= maxHits)
                DestroyBlock();
            else
            {
                ShowNextBlockSprite();
            }
            
        }   
              
    }

    private void ShowNextBlockSprite()
    {
        int spriteIndex = timesHit-1;
        if (spriteIndex < blockSprites.Length)
            GetComponent<SpriteRenderer>().sprite = blockSprites[spriteIndex];
        else
            Debug.Log("Block hit Sprite missing from array for " +  gameObject.name );
    }
    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        FindObjectOfType<GameStatus>().AddToScore(); 
        level.BlocksDestroyer();
        Destroy(gameObject, 0.1f);
    }
}
