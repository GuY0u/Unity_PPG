using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision coll)
    //{
    //    if (coll.transform.gameObject.tag == "PlayerPunch")
    //    {
    //        Debug.Log("적 펀치에 충돌");
    //    }
    //}

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("asdf");
        if (coll.gameObject.tag == "PlayerPunch")
        {
            Debug.Log("펀치에 충돌");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.gameObject.tag == "PlayerPunch")
    //    {
    //        Debug.Log("펀치에 충돌");
    //    }
    //}
}
