using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterM1Cam : MonoBehaviour
{
    //M1 입장시 
    Vector3 originPos;
    Quaternion originRot;
    float timer = 0f;

    public GameObject wallSpawn;
    public GameObject enemySpawn;

    int state = 1;


    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        originPos = new Vector3(-18.4f, 54.9f, -81.4f);
        originRot.eulerAngles = new Vector3(46.2f, -181.2f, 0f);

        player.GetComponent<PlayerMove>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("상황 : " + state);
        //CancelInvoke("HoldCam");
        //Invoke("ShakeCam", 1f);
        //Invoke("WallSpawn", 15f);
        //Invoke("EnemySpawn", 15f);
        if (state == 1)
        {
            HoldCam();
        }
        else if (state == 2)
        {
            ShakeCam();
        }
        else if (state == 3)
        {
            StartCoroutine("WallSpawn");
        }
        else if (state == 4)
        {
            StartCoroutine("EnemySpawn");
        }
        else if (state == 5)
        {
            StartCoroutine("QuitCam");
        }
    }

    //플레이어 입장시 PlayerMove스크립트를 꺼서 고정시킬 예정
    void HoldPlayer()
    {

    }

    void HoldCam()
    {
        Debug.Log("카메라 고정");
        this.transform.position = originPos;
        this.transform.rotation = originRot;
        state = 2;
    }

    void ShakeCam()
    {
        Debug.Log("카메라 흔들림");
        gameObject.GetComponent<ShakeCam>().enabled = true;
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("카메라 흔들림");
        gameObject.GetComponent<ShakeCam>().enabled = false;
        state = 3;
    }

    IEnumerator WallSpawn()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("벽 생성");
        wallSpawn.SetActive(true);
        state = 4;
    }

    //void WallSpawn()
    //{
    //    Debug.Log("벽 생성");
    //    GameObject.Find("_Wall").SetActive(true);
    //}

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("적 생성");
        enemySpawn.SetActive(true);
        state = 5;

    }

    //모든 함수 수행시 스크립트 해제
    IEnumerator QuitCam()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        gameObject.GetComponent<SmoothFollow>().enabled = true;
        gameObject.GetComponent<EnterM1Cam>().enabled = false;
        
        player.GetComponent<PlayerMove>().enabled = true;
    }
}
