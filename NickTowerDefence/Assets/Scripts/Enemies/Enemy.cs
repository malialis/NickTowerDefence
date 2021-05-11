using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed = 10f;
    public int health = 100;
    public int value = 75;
    public GameObject deathFX;

    private Transform target;
    private int wavepointIndex = 0;


    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPathGoal();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    private void EndPathGoal()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        Debug.Log("Goal is reached");
    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathFX, transform.position, Quaternion.identity);
        PlayerStats.Money += value;
        Destroy(gameObject);
        Destroy(effect, 3f);
    }

}
