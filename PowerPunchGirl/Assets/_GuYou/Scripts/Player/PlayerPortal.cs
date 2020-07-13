using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{

    public Camera cam;

    //M2
    public GameObject EnterM3;

    //M3
    //퍼즐 클리어시 카메라 위치
    Vector3 originPos;
    Quaternion originRot;
    float timer = 0f;
    bool isBossPortalOpen = false;

    public GameObject sun;
    public GameObject M3;

    bool lightRed = false;
    bool lightGreen = false;
    bool lightYellow = false;
    bool lightBlue = false;

    public GameObject ballRed;
    public GameObject ballGreen;
    public GameObject ballYellow;
    public GameObject ballBlue;

    public GameObject EnterbossPortal;
    public GameObject bossPortal;

    // Start is called before the first frame update
    void Start()
    {
        originPos = new Vector3(-43.5f, 66.0f, -623.7f);
        originRot.eulerAngles = new Vector3(33.0f, -174.6f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isBossPortalOpen == false)
        {
            OpenBossPortal();
        }
    }

    void OpenBossPortal()
    {
        if (lightRed == true && lightBlue == true && lightGreen == false && lightYellow == false)
        {
            //이부분 나중에 카메라에 스크립트로 이동해 카메라가 한번 줌하고 포탈이 열리는 식으로 만들거임
            // ex) smoothcam(off) -> camM3(on) -> zoom this position -> portalEffect(off) or makePortal ->camM3(off) and smoothCam(on)
            cam.GetComponent<SmoothFollow>().enabled = false;

            if (timer <= 0)
            {
                cam.transform.position = originPos;
                cam.transform.rotation = originRot;
            }
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                EnterbossPortal.gameObject.SetActive(true);
            }
            if (timer > 2.5f)
            {
                cam.GetComponent<SmoothFollow>().enabled = true;
                isBossPortalOpen = true;
            }
        }
    }


    //플레이어가 트리거에 걸리면 조명색갈을 해당색갈로 바꾸고 다시 그 트리거를 발동시키면 원래 초기의 색이였던 하얀색으로 바꿔준다.
    private void OnTriggerEnter(Collider other)
    {
        //M2
        //포탈 닿을시 M3의 위치로 이동

        //M3에서의 플레이어의 카메라위치가 답답하다.
        //smooth follow의 distance값도 조정이 필요할거같다.

        //추후 디테일시 M3이동후 
        //smoothCam(off) -> 맵한번 둘러보게 해주고 보스룸 포탈한번 봐주고(scanM3(on)) -> 다보면 scanM3(off) and smoothCam(on) 
        if (other == EnterM3.GetComponent<Collider>())
        {
            sun.SetActive(false);
            this.transform.position = M3.transform.position;
        }


        //M3
        //퍼즐 빛 맞추기
        if (other == ballRed.GetComponent<Collider>())
        {
            //빨
            if (lightRed == false)
            {
                //불을 색갈과 맞춘다
                Debug.Log("빨간조명");
                lightRed = true;
                ballRed.GetComponentInChildren<Light>().color = Color.red;
            }
            else  //true일때
            {
                //불을 다시 하얀색으로 바꾼다
                lightRed = false;
                ballRed.GetComponentInChildren<Light>().color = Color.white;
            }
        }

        if (other == ballGreen.GetComponent<Collider>())
        {
            //초
            if (lightGreen == false)
            {
                lightGreen = true;
                ballGreen.GetComponentInChildren<Light>().color = Color.green;
            }
            else  //true일때
            {
                lightGreen = false;
                ballGreen.GetComponentInChildren<Light>().color = Color.white;
            }
        }

        if (other == ballYellow.GetComponent<Collider>())
        {
            //노
            if (lightYellow == false)
            {
                lightYellow = true;
                ballYellow.GetComponentInChildren<Light>().color = Color.yellow;
            }
            else  //true일때
            {
                lightYellow = false;
                ballYellow.GetComponentInChildren<Light>().color = Color.white;
            }
        }

        if (other == ballBlue.GetComponent<Collider>())
        {
            //파
            if (lightBlue == false)
            {
                lightBlue = true;
                ballBlue.GetComponentInChildren<Light>().color = Color.blue;
            }
            else  //true일때
            {
                lightBlue = false;
                ballBlue.GetComponentInChildren<Light>().color = Color.white;
            }
        }

        //보스방 포털
        if (other == EnterbossPortal.GetComponent<Collider>())
        {
            sun.SetActive(true);
            this.transform.position = bossPortal.transform.position;
        }
    }
}
