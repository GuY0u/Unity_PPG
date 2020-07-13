using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTree : MonoBehaviour
{

    int randomDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMove player = other.transform.gameObject.GetComponent<PlayerMove>();


            randomDamage = Random.Range(20, 25);
            Debug.Log(randomDamage);
            player.HitDamage(randomDamage);
        }
    }
}
