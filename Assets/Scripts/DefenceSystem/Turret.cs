using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for managing the turrent range and enemy target lock mechanism. Add namespaces
/// </summary>


public class Turret : MonoBehaviour {

    private Bullet bullet;
    private Transform target;


    [Header("Attributes")]
    [SerializeField]
    private float range = 15f;
    [SerializeField]
    private float fireRate = 0.8f;
    [SerializeField]
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    [SerializeField]
    private float turnSpeed = 10f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    private Transform partToRotate;



    private void Awake() {
        partToRotate = GetComponent<Transform>();

    }

    private void Start() {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);

    }

    private void Update() {

        if (target == null)
            return;

        TurretTotation();

        if (fireCountDown <= 0) {
            Shoot();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void TurretTotation() {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    private void Shoot() {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Chase(target);
        }

    }

    private void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}//Class
