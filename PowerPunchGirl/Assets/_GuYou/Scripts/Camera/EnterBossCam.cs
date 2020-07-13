using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossCam : MonoBehaviour
{

    public const string POS = "Standing 1H Magic Attack 03";

    Vector3 originPos;
    Quaternion originRot;
    float timer = 0f;
    float faceTime = 4f;

    public GameObject obj;

    public Camera cam;

    public GameObject bossFSM;

    public GameObject player;

    public GameObject bossHpBar;


    int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMove>().enabled = false;
        originPos = new Vector3(15.35f, 62.6f, -1181f);
        originRot.eulerAngles = new Vector3(-7.8f, -184f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            HoldCam();
        }
        else if (state == 2)
        {
            Back();
        }

    }

    void HoldCam()
    {
        Debug.Log("카메라 고정");
        this.transform.position = originPos;
        this.transform.rotation = originRot;
        timer += Time.deltaTime;
        if (faceTime < timer)
        {
            state = 2;
        }

    }
    void Back()
    {
        cam.gameObject.GetComponent<SmoothFollow>().enabled = true;
        cam.gameObject.GetComponent<SmoothFollow>().distance = 50f;
        cam.gameObject.GetComponent<SmoothFollow>().height = 50f;

        cam.gameObject.GetComponent<EnterBossCam>().enabled = false;

        bossFSM.GetComponent<BossFSM>().enabled = true;

        bossHpBar.SetActive(true);

        player.GetComponent<PlayerMove>().enabled = true;
    }
}
