using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMapGeneration : MonoBehaviour
{

    public GameObject groundTop, groundMid;

    public int minPlatformSize;
    public int maxPlatformSize;
    public int maxHazardSize;
    public int platforms;
    [Range(0.0f, 1f)]
    public float hazardChance;
    [Range(0.0f, 1f)]
    public float bridgeChance;

    public int maxDrop;
    public int maxHeight;
    private int blockNum = 1;
    private int blockHeight;
    private bool isHazard;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(groundTop, new Vector2(0,0), Quaternion.identity);
        
        for(int plat = 1; plat < platforms; plat++)
        {
            if (isHazard == true)
            {
                isHazard = false;
            }
            else if (Random.value < hazardChance)
            {
                isHazard = true;
            }
            else
                isHazard = false;

            if(isHazard==true)
            {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));
                blockNum += hazardSize;
            }
            //platform Generation
            else
            {
                int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);

                for (int tiles = 0; tiles < platformSize; tiles++)
                {
                    Instantiate(groundTop, new Vector2(blockNum, blockHeight), Quaternion.identity);

                    for(int grdMid = 1; grdMid < 2; grdMid++)
                    {
                        Instantiate(groundMid, new Vector2(blockNum, blockHeight - grdMid), Quaternion.identity);
                    }
                    blockNum++;
                }
            }       
                       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
