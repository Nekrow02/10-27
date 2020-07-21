using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    GameObject target;
    float distance, distance0, distance1, distance2, distance3;
    GameObject[] robolist;
    bool buff_on = false;


    void Start()
    {

    }


    void Update()
    {
        robolist = GameObject.FindGameObjectsWithTag("ROBO");

        if (GameObject.FindGameObjectWithTag("ROBO"))
        {
            distance0 = Vector3.Distance(robolist[0].transform.position, transform.position);
            distance1 = Vector3.Distance(robolist[1].transform.position, transform.position);
            distance2 = Vector3.Distance(robolist[2].transform.position, transform.position);
            //distance3 = Vector3.Distance(robolist[3].transform.position, transform.position);
        }

        distance = Mathf.Min(distance0, distance1, distance2);//, distance3);


        if (Input.GetKeyDown(KeyCode.C))
        {
            FindMe();

            target.GetComponent<MoveCtrl>().speed += 10;
            buff_on = true;

            Invoke("ResetBuff", 5f);
        }


        //Debug.Log(robolist[0].name + "0번째 로봇");
        //Debug.Log(robolist[1].name + "1번째 로봇");
        if (Input.GetKeyDown(KeyCode.V))
        {
            Min();

            if (buff_on == false)
            {
                FindTarget();
            }


            target.GetComponent<MoveCtrl>().speed += 10;
            buff_on = true;

            Invoke("ResetBuff", 5f);
        }
    }

    void ResetBuff()
    {
        target.GetComponent<MoveCtrl>().speed -= 10;
        buff_on = false;
    }

    void Min()
    {
        if (distance == distance0)
            distance = Mathf.Min(distance1, distance2);//, distance3);
        else if (distance == distance1)
            distance = Mathf.Min(distance0, distance2);//, distance3);
        else if (distance == distance2)
            distance = Mathf.Min(distance0, distance1);//, distance3);
        else
            target = null;
    }

    void FindTarget()
    {
        if (distance == distance0)
            target = robolist[0];
        else if (distance == distance1)
            target = robolist[1];
        else if (distance == distance2)
            target = robolist[2];
        else
            target = null;
    }

    void FindMe()
    {
        if (distance == distance0)
            target = robolist[0];
        else if (distance == distance1)
            target = robolist[1];
        else if (distance == distance2)
            target = robolist[2];
        else
            target = null;
    }


}
