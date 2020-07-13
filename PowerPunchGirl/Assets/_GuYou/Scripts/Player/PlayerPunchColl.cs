using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchColl : MonoBehaviour
{
    public GameObject pEffect;

    PlayerAttack playerAtkInfo;
    


    // Start is called before the first frame update
    void Start()
    {
        playerAtkInfo = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌 물체 : " + other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<AudioSource>().Play();
            EnemyFSM enemy = other.transform.gameObject.GetComponent<EnemyFSM>();

            int ranDamage = Random.Range(10, 12);

            enemy.HitDamage(ranDamage);

            Debug.Log("펀치 데미지 적중  적 남은 체력 : " + enemy.hp);
        }

        if (other.gameObject.tag == "Boss")
        {
            GetComponent<AudioSource>().Play();
            BossFSM enemy = other.transform.gameObject.GetComponent<BossFSM>();

            int ranDamage = Random.Range(10, 12);

            enemy.HitDamage(ranDamage);

            Debug.Log("펀치 데미지 적중  보스 남은 체력 : " + enemy.hp);
        }
    }

    //private void OnCollisionEnter(Collision coll)
    //{
    //    Debug.Log("dasf");
    //    //print(coll.transform.gameObject.name);
    //    //GameObject effect = Instantiate(pEffect);
    //    //effect.transform.position = coll.transform.position;
    //}


}
