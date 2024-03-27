using com.rfilkov.kinect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Script : MonoBehaviour
{
    //// Start is called before the first frame update
    public GameObject cubeg;
    public GameObject cubed;
    void Start()
    {
        //Debug.Log("Démarage");
    }

    // Update is called once per frame
    void Update()
    {
        KinectInterop.JointType jointdroite = KinectInterop.JointType.HandtipRight;
        KinectInterop.JointType jointgauche = KinectInterop.JointType.HandtipLeft;


        KinectManager kinectManager = KinectManager.Instance;
        if (kinectManager && kinectManager.IsInitialized())
        {
            if (kinectManager.IsUserDetected(0))
            {
                ulong userId = kinectManager.GetUserIdByIndex(0);

                if (kinectManager.IsJointTracked(userId, jointdroite))
                {
                    Vector3 jointdroitePos = kinectManager.GetJointPosition(userId, jointdroite);
                    Debug.Log("La position de la main droite est " + jointdroitePos);
                    cubed.transform.position = new Vector3(jointdroitePos.x * 15, jointdroitePos.y * 5);
                    cubed.transform.position -= new Vector3(0, 6.5f, 0);
                    // do something with the joint position
                }

                if (kinectManager.IsJointTracked(userId, jointgauche))
                {
                    Vector3 jointgauchePos = kinectManager.GetJointPosition(userId, jointgauche);
                    Debug.Log("La position de la main droite est " + jointgauchePos);
                    cubeg.transform.position = new Vector3(jointgauchePos.x * 15, jointgauchePos.y * 5);
                    cubeg.transform.position -= new Vector3(0, 6.5f, 0);
                    // do something with the joint position
                }
            }
        }
    }


}
