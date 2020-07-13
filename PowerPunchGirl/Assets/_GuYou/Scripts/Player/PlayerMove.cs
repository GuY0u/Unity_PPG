using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{

    public Animator anim;
    Rigidbody rg;

    bool isMoving;

    public float h = 0.0f;
    public float v = 0.0f;
    public float s = 0.0f;


    //접근해야 하는 컴포넌트는 반드시 변수에 할당한 후 사용
    [SerializeField] private Transform tr;

    public float hp = 100f;

    public float currHp;

    private Color currColor;
    private readonly Color initColor = new Vector4(0, 1.0f, 0.0f, 1.0f);

    public Image hpBar;

    //회전 속도 변수
    public float rotSpeed = 80.0f;

    public GameObject ChargingImpact;
    bool isCharging = false;


    //이동 속도 변수(public으로 선언되어 Inspector에 노출됨)
    public float originSpeed = 20.0f;
    public float moveSpeed = 20.0f;
    public float jumpSpeed = 15.0f;

    bool isJump = false;

    public bool isGrounded = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //스크립트가 실행된 후 처음 수행되는 Start 함수에서 Transform 컴포넌트를 할당
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();

        currHp = hp;

        hpBar.color = initColor;
        currColor = initColor;


    }


    private void OnCollisionEnter(Collision col)

    {

        if (col.gameObject.tag == "Ground")

            isGrounded = true;  //Ground에 닿으면 isGround는 true

    }

    // Update is called once per frame
    void Update()
    {
        DisplayHpbar();


        Debug.Log("player hp : " + currHp);


        //print("v : " + v);
        //print("h : " + h);
        //print("s : " + s);

        //if (Input.GetKeyDown("escape"))
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}

        if (Input.GetKeyDown(KeyCode.F1))
        {
            HitDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            Time.timeScale = 1.0f;
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Damaged") || anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
        }
        else
        {
            Run();
            Jump();
            SightRotate();
            Animation();
            Charging();
        }
    }

    void Charging()
    {
        if (Input.GetKey(KeyCode.F))
        {
            ChargingImpact.SetActive(true);
            anim.SetBool("isCharging", true);
            isCharging = true;
        }
        else
        {
            ChargingImpact.SetActive(false);
            anim.SetBool("isCharging", false);
            isCharging = false;
        }
        if (currHp < 100)
        {
            currHp += Time.deltaTime;
        }
    }

    void DisplayHpbar()
    {
        if ((currHp / hp) > 0.5f)
            currColor.r = (1 - (currHp / hp)) * 2.0f;
        else
            currColor.g = (currHp / hp) * 2.0f;

        hpBar.color = currColor;
        hpBar.fillAmount = (currHp / hp);

    }

    //달리기
    void Run()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

    }

    //점프
    void Jump()
    {
        if (isGrounded)
        {
            moveSpeed = originSpeed;
            //눌렀을때 점프 트루
            if (Input.GetButtonDown("Jump"))
                isJump = true;

            //점프상태가 아니면 빠져나간다
            if (!isJump)
                return;

            //힘 추가
            rg.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            //다시 점프값 안되게 false처리
            isJump = false;
            isGrounded = false;
        }
        else
        {
            moveSpeed = jumpSpeed;
        }
    }

    //시야축 이동(걷기로 대체)
    void SightRotate()
    {
        s = Input.GetAxis("SightVolume");

        if (Input.GetKey(KeyCode.Q))
        {
            //Vector3.up 축을 기준으로 rotSpeed만큼의 속도로 회전
            tr.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            //Vector3.up 축을 기준으로 rotSpeed만큼의 속도로 회전
            tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }

    //애니메이션
    void Animation()
    {
        //Run
        if (h == 0 && v == 0)
        {
            //anim.SetTrigger("Idle");
            anim.SetBool("isMove", false);
            Debug.Log("대기");
        }
        else
        {
            //anim.SetTrigger("Run");
            anim.SetBool("isMove", true);
            Debug.Log("런");
        }

        //if (v < 0)
        //{
        //    anim.SetBool("isWalk", true);
        //    print("뒤로 걷는 중");
        //}

        //Rotate Sight
        if (s == 0)
        {
            anim.SetBool("isSight", false);
        }
        else
        {
            anim.SetBool("isSight", true);
        }

        if (isGrounded)
        {
            anim.SetBool("isJump", false);
        }
        else if (!isGrounded)
        {
            anim.SetBool("isJump", true);
        }
    }

    public void HitDamage(int value)
    {
        //예외처리
        //피격상태이거나, 죽은 상태일때는 데미지 중/첩으로 주지 않는다.
        //if (state == EnemyState.Damaged || state == EnemyState.Die) return;
        //체력깎기
        if (isCharging == true)
        {
            Debug.Log("데미지 무시");
        }
        else if (isCharging == false)
        {
            currHp -= value;
            //몬스터의 체력이 1이상이면 피격상태
            if (currHp > 0)
            {
                print("데미지 받음");
                print("HP : " + hp);

                Damaged();

                //anim.SetTrigger("Damaged");
                anim.SetTrigger("isDamaged");
            }
            //0이하이면 죽음상태
            else if (currHp <= 0)
            {
                print("플레이어 사망");

                //Time.timeScale = 0.8f;

                anim.SetTrigger("isDamaged");

                Time.timeScale = 0.3f;

                anim.SetTrigger("isDead");

                Die();

            }
        }
    }

    //피격상태 (Any State)
    private void Damaged()
    {
        //코루틴을 사용하자
        //1. 몬스터 체력이 1이상
        //2. 다시 이전상태로 변경
        //- 상태변경
        //- 상태전환 출력
        //Debug.Log("State: Damaged");
        //curHP--;

        //피격 상태를 처리하기 위한 코루틴을 실행한다
        StartCoroutine(DamageProc());
    }

    //피격상태 처리용 코루틴
    IEnumerator DamageProc()
    {
        //피격모션 시간만큼 기다리기
        yield return new WaitForSeconds(1.0f);
        //현재상태를 이동으로 전환
        print("상태전환 : Damaged -> Move");
        //anim.SetTrigger("Move");
    }

    //죽음상태 (Any State)
    private void Die()
    {
        //코루틴을 사용하자
        //1. 체력이 0이하
        //2. 몬스터 오브젝트 삭제
        //- 상태변경
        //- 상태전환 출력 (죽었다)
        //Debug.Log("State: Die");
        //Destroy(gameObject, 2.0f);

        //진행중인 모든 코루틴은 정지한다
        StopAllCoroutines();

        //죽음상태를 처리하기 위한 코루틴 실행
        StartCoroutine(DieProc());
    }

    IEnumerator DieProc()
    {
        //캐릭터컨트롤러 비활성화
        //cc.enabled = false;

        //2초후에 자기자신을 제거한다
        yield return new WaitForSeconds(2.0f);
        print("죽음");
        //Destroy(this.gameObject);
    }
}