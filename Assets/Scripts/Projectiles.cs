using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] float currentSpeed = 1f;
    [SerializeField] float damage = 50f;

  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        var health = othercollider.GetComponent<Health>();
        var attacker = othercollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
