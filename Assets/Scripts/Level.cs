using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int blocksCount;

    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlocksCounter()
    {
        blocksCount++;
    }

    public void BlocksDestroyer()
    {
         blocksCount--;
         if(blocksCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
