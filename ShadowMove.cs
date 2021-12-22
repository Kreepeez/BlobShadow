using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
{
    
    int layerMask;

    public GameObject blobShadow;

    public float maxDistance;
    public float minDistance;

    void Start()
    {
        layerMask = LayerMask.GetMask("solid");
    }

    
    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 15f, layerMask);

        if (hit.collider != null)
        {
            blobShadow.SetActive(true);
            blobShadow.transform.position = hit.point;
            Debug.DrawLine(transform.position, hit.centroid, Color.yellow);


             if(hit.distance <= maxDistance || hit.distance >= minDistance)
             {
                 float distanceRatio = minDistance / hit.distance;

                if(distanceRatio > 1f)
                {
                    distanceRatio = 1f;
                } else if(distanceRatio < 0.3f)
                {
                    distanceRatio = 0.3f;
                }

                blobShadow.GetComponent<Transform>().localScale = new Vector2(distanceRatio, distanceRatio);
            }  
        }
        else blobShadow.SetActive(false);
    }
}
        
    






