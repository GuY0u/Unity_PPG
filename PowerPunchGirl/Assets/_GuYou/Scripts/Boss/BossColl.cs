using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColl : MonoBehaviour
{
    public float pushPower = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("충돌 : " + other);
    //    Debug.Log("충돌 태그 : " + other.tag);
    //    if (other.tag == "Player")
    //    {
    //        other.attachedRigidbody.AddForce(other.gameObject.transform.forward * pushPower);

    //    }
    //}

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.transform.tag=="Player")
        {
            coll.rigidbody.AddForce(coll.gameObject.transform.forward * pushPower);
        }
    }

}
