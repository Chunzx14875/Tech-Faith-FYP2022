using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLogic : MonoBehaviour
{
    [SerializeField] private DoorLogic myDoorLogic;
    [SerializeField] private int floorNum;
    bool used;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.GetComponent<CubeLogic>() != null)
    //    {
    //        if (other.GetComponent<CubeLogic>().cubeNum == floorNum && used == false && myDoorLogic.sequence[myDoorLogic.addedSeq.Count] == floorNum)
    //        {
    //            used = true;
    //            myDoorLogic.AddKey(floorNum);
    //            //SET;
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CubeLogic>() != null)
        {
            if (collision.gameObject.GetComponent<CubeLogic>().cubeNum == floorNum && used == false && myDoorLogic.sequence[myDoorLogic.addedSeq.Count] == floorNum)
            {
                used = true;
                myDoorLogic.AddKey(floorNum);
                //SET;
            }
        }
    }

}
