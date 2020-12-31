﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //[SerializeField] float health = 100f;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyBulletPrefab;

    [SerializeField] float enemyBulletSpeed = 0.3f;

    //reduces health whenever enemy collides with a gameObject
    //which has a DamageDealer component
    //private void OnTriggerEnter2D(Collider2D otherObject)
    //{
    //    //access the DamageDealer class from "otherObject" which hits enemy and reduce health accordingly
    //    DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

    //    ProcessHit(dmgDealer);
    //}

    //private void ProcessHit(DamageDealer dmgDealer)
    //{ 
    //    health -= dmgDealer.GetDamage();

    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        //generate a random number
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduce the amount of time for shot 
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            EnemyFire();
            //reset shotCounter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void EnemyFire()
    {
        //spawn an enemyLaser at enemy position
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //shoot laser downwards
        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }

}
