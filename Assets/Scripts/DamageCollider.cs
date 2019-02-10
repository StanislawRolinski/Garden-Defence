using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Lives>().TakeLife();
        Destroy(collision.gameObject);
    }
  }
