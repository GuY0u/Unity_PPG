using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{

    int randomDamage;

    float duringTime = 12f;
    float timer = 0f;
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        Destory();
    }

    void FollowTarget()
    {
        GameObject player = GameObject.Find("Player");

        Vector3 target = new Vector3(player.transform.position.x - this.transform.position.x, 0f, player.transform.position.z - this.transform.position.z).normalized;

        transform.position += target * speed * Time.deltaTime;


    }

    void Destory()
    {
        timer += Time.deltaTime;
        if (duringTime < timer)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMove player = other.transform.gameObject.GetComponent<PlayerMove>();


            randomDamage = Random.Range(8, 12);
            Debug.Log(randomDamage);
            player.HitDamage(randomDamage);
            Destroy(this.gameObject);
        }
    }
}
