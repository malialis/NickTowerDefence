using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    [SerializeField]private GameObject impactFX;

    [SerializeField] private float speed = 70f;
    [SerializeField] private float impactRadius = 0f;
    [SerializeField] private int damage = 50;


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        Debug.Log("We have struck Gold");

       GameObject fxInstance = (GameObject)Instantiate(impactFX, transform.position, transform.rotation);

        Destroy(fxInstance, 2f);

        if(impactRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

       // Destroy(target.gameObject);
        Destroy(gameObject);
        return;
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }        
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, impactRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactRadius);
    }


}
