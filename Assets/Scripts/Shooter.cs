using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AtackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

   
    


    private void Start()
    {
        SetLaneSpawner();
        CreatedProjectileParent();
        animator = GetComponent<Animator>();
    }


    private void CreatedProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AtackerSpawner[] spawners = FindObjectsOfType<AtackerSpawner>();
        foreach (AtackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs ((spawner.transform.position.y) - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private void Update()
    {
        if(IsAttackerInLine())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsAttackerInLine()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else return true;
    }

    public void Fire()
    {
       GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
