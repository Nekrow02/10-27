using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Buff : MonoBehaviourPunCallbacks
{
    GameObject target;
    float distance, distance0, distance1, distance2;
    //GameObject[] robolist;
    GameObject robo1, robo2, robo3;
    bool buff_on, buff_on_m = false;


    void Start()
    {

    }


    void Update()
    {
        //robolist = GameObject.FindGameObjectsWithTag("ROBO");

        if (GameObject.Find("Player(Clone)") && GameObject.Find("Robo(Clone)") && GameObject.Find("Robo_J(Clone)"))
        {
            robo1 = GameObject.Find("Robo(Clone)");
            robo2 = GameObject.Find("Robo_J(Clone)");
            robo3 = GameObject.Find("Robo_J(Clone)");

        }

        distance0 = Vector3.Distance(robo1.transform.position, transform.position);
        distance1 = Vector3.Distance(robo2.transform.position, transform.position);
        distance2 = Vector3.Distance(robo3.transform.position, transform.position);


        distance = Mathf.Min(distance0, distance1, distance2);//, distance3);


        if (Input.GetKeyDown(KeyCode.C))
        {
            if(buff_on_m == false)
            {


            this.GetComponent<MoveCtrl>().speed += 10;
            buff_on_m = true;

            Invoke("ResetBuff_m", 5f);
            }

        }


        //Debug.Log(robolist[0].name + "0번째 로봇");
        //Debug.Log(robolist[1].name + "1번째 로봇");
        if (Input.GetKeyDown(KeyCode.V))
        {

            if (buff_on == false)
            {
                //target.GetComponent<MoveCtrl>().speed += 10;
                photonView.RPC("Buff_", RpcTarget.AllViaServer, null);

            }
        }
    }

    [PunRPC]
    void Buff_()
    {
        FindTarget();

        target.GetComponent<MoveCtrl>().speed += 10;

        buff_on = true;

        Invoke("ResetBuff", 5f);
    }


    void ResetBuff()
    {
        target.GetComponent<MoveCtrl>().speed -= 10;
        buff_on = false;
    }
    void ResetBuff_m()
    {
        this.GetComponent<MoveCtrl>().speed -= 10;
        buff_on_m = false;
    }


    void FindTarget()
    {
        if (distance == distance0)
            target = robo1;
        else if (distance == distance1)
            target = robo2;
        else if (distance == distance2)
            target = robo3;
        else
            target = null;
    }



}
