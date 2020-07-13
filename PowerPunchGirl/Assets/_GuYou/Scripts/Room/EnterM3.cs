using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterM3 : MonoBehaviour
{


    public Camera cam;

    //public GameObject camPosStart;
    //public GameObject camPosEnd;


    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        //cam.transform.position = camPosStart.transform.position;
        //cam.transform.rotation = camPosStart.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        //잠시 따라다니는 카메라 스크립트 정지
        cam.gameObject.GetComponent<SmoothFollow>().enabled = false;
        cam.gameObject.GetComponent<EnterM3Cam>().enabled = true;
        //발판 사라져야 다시 이곳에 이동시 문제가 안생김
        this.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
