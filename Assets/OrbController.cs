using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{

    AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        collectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Chicho"))
        {
            collectSound.Play();
            Destroy(gameObject);
        }
    }
}
