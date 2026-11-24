using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class OneWayPlatform : MonoBehaviour
{
    Collider2D platformCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach(GameObject f in LevelContext.fighters)
        {
            Vector3 fPos = f.transform.position; 
            Collider2D fCol = f.GetComponent<Collider2D>();

            if(fPos.y < transform.position.y)
            {
                Physics2D.IgnoreCollision(platformCollider, fCol, true);
            }
            else
            {
                Physics2D.IgnoreCollision(platformCollider, fCol, false);
            }
        }
    }
}
