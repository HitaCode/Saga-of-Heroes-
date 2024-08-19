using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dmgable dmgable = collision.GetComponent<Dmgable>();

        if (dmgable != null)
        {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            bool goHit = dmgable.Hit(attackDamage, deliveredKnockback);

            if(goHit) 
                Debug.Log(collision.name + " hit for" + attackDamage);
        }
    }
}
