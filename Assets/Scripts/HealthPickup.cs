using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

    AudioSource pickupSource;

    private void Awake ()
    {
        pickupSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dmgable dmgable = collision.GetComponent<Dmgable>();

        if(dmgable && dmgable.Health < dmgable.MaxHealth)
        {
            bool wasHealed = dmgable.Heal(healthRestore);

            if (wasHealed)
            {
                AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
                Destroy(gameObject);
            }
                
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }


}
