using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 1f;
    [SerializeField] Attacker[] attackerPrefabArray;

    IEnumerator Start()
    {
     while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        if(myAttacker.GetComponent<LizzardAttack>())
        {
            Attacker newAttacker = Instantiate(myAttacker, new Vector2(transform.position.x, transform.position.y+0.25f), transform.rotation) as Attacker;
            newAttacker.transform.parent = transform;
        }
        else
        {
            Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
            newAttacker.transform.parent = transform;
        }
        
    }

}
