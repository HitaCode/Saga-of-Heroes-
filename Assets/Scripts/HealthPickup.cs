using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dmgable dmgable = collision.GetComponent<Dmgable>();

        if(dmgable)
        {
            bool wasHealed = dmgable.Heal(healthRestore);

            if(wasHealed)
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }


}
