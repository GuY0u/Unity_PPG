using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //접근해야 하는 컴포넌트는 반드시 변수에 할당한 후 사용
    [SerializeField] private Transform tr;

    Animator anim;
    Rigidbody rg;

    //기본공격의 정보값
    public int baseDamge = 10;
    public float dashSpeed = 5.0f;
    public float attackRange = 5f; //공격 가능 범위

    //좌우 손의 오브젝트
    public BoxCollider lHand;
    public BoxCollider RHand;

    int hitCount = 0;

    //기본펀치 이펙트
    public GameObject pEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //스크립트가 실행된 후 처음 수행되는 Start 함수에서 Transform 컴포넌트를 할당
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float qwer = Input.GetAxis("Fire1");
        Debug.Log(qwer);

        //if (Input.GetAxis("Fire1") < 0f)
        //{
        //    anim.SetBool("isAtk1", true);
        //}
        //else
        baseAtk();
    }

    void baseAtk()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //애니메이션 실행
            anim.SetTrigger("isAtk");

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1/3"))
        {
            lHand.enabled = true;
            RHand.enabled = true;
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2/3"))
        {
            lHand.enabled = true;
            RHand.enabled = true;
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3/3"))
        {
            lHand.enabled = true;
            RHand.enabled = true;
        }
        else
        {
            lHand.enabled = false;
            RHand.enabled = false;
        }
    }
    


}
