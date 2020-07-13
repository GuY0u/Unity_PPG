using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMakeTreeSkill1 : MonoBehaviour
{

    public GameObject effect;

    public GameObject collTree;

    //이펙트가 지속될 시간
    float effectTime = 3.0f;
    //이펙트 타이머
    float effectTimer = 0f;

    float timer = 0f;


    //공격오브젝트가 지속될 시간
    float collTreeTime = 2.0f;
    //공격오브젝트 타이머
    float collTimer = 0f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (effect.activeSelf == true)
        {
            Effect();
        }

        if (effect.activeSelf == false)
        {
            MakeTree();
        }
    }

    void Effect()
    {
        effect.SetActive(true);
        timer += Time.deltaTime;
        if (effectTime < timer)
        {
            timer = 0f;
            effect.SetActive(false);
        }
    }

    void MakeTree()
    {

        collTree.SetActive(true);
        timer += Time.deltaTime;
        if(collTreeTime < timer)
        {
            Destroy(this.gameObject);
        }
    }
}
