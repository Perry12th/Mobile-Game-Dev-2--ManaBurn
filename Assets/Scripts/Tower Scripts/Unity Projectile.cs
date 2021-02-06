using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityProjectile : ProjectileBase
{
    
    GameObject trackingTarget;

    public void SetTarget(GameObject target)
    {
        trackingTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, trackingTarget.transform.position, speed * Time.deltaTime);
        }
    }
}
