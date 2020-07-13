using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterM3Cam : MonoBehaviour
{
    public GameObject id;
    Animation anim;
    float timer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        anim = id.GetComponent<Animation>();
        anim.Play("EnterM3Camera");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            gameObject.GetComponent<SmoothFollow>().enabled = true;
            gameObject.GetComponent<EnterM3Cam>().enabled = false;
        }
    }
}
