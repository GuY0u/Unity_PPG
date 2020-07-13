using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkleLight : MonoBehaviour
{
    public float incre = 1.0f;
    public Light lt;
    public bool under = true;

    private void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        if (lt.intensity <= 20.0f && under == true)
        {
            lt.intensity += incre * Time.deltaTime;
        }
        else if (lt.intensity >= 50.0f && under == false)
        {
            lt.intensity -= incre * Time.deltaTime;
        }

        if(lt.intensity == 20.0f)
        {
            under = true;
        }
        else if( lt.intensity == 50.0f)
        {
            under = false;
        }
    }
}
