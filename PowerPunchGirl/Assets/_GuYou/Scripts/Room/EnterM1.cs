using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterM1 : MonoBehaviour
{
    float time = 0;

    //카메라 스크립트 활용을 위한
    public Camera cam;

    //모든상황이 끝나면 실행되게
    bool actEnd = false;    //다 안끝났을 때


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //Debug.Log("시간 : " + time);
        if (actEnd == false)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("정지");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("M1 통과");
        //잠시 따라다니는 카메라 스크립트 정지
        cam.gameObject.GetComponent<SmoothFollow>().enabled = false;
        cam.gameObject.GetComponent<EnterM1Cam>().enabled = true;
        //발판 사라져야 다시 이곳에 이동시 문제가 안생김
        this.gameObject.SetActive(false);
    }
}
