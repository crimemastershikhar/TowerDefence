using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is responsible with the bullet and its destroy system
/// </summary>

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speedOfBullet = 20f;

    private void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speedOfBullet * Time.deltaTime;

        if(dir.magnitude < distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    public void Chase(Transform _target)
    {
        target = _target;

    }

    public void HitTarget()
    {
        Destroy(gameObject);

    }

}
