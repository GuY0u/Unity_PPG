using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoss : MonoBehaviour
{
    //카메라 스크립트 활용을 위한
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        cam.gameObject.GetComponent<SmoothFollow>().enabled = false;
        cam.gameObject.GetComponent<EnterBossCam>().enabled = true;

        this.gameObject.SetActive(false);
    }
}

