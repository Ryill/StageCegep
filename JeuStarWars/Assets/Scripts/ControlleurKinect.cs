using com.rfilkov.kinect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Script : MonoBehaviour
{
    //// Start is called before the first frame update
    public GameObject MainGauche;
    public GameObject MainDroite;
    void Start()
    {
        //Debug.Log("Démarage");
    }

    // Update is called once per frame
    void Update()
    {
        KinectInterop.JointType jointdroite = KinectInterop.JointType.HandtipRight;


        KinectManager kinectManager = KinectManager.Instance;
        if (kinectManager && kinectManager.IsInitialized())
        {
            if (kinectManager.IsUserDetected(0))
            {
                ulong userId = kinectManager.GetUserIdByIndex(0);

                if (kinectManager.IsJointTracked(userId, jointdroite))
                {
                    Vector3 jointdroitePos = kinectManager.GetJointPosition(userId, jointdroite);
                    //Debug.Log("La position de la main droite est " + jointdroitePos);
                    MainDroite.transform.position = new Vector3(jointdroitePos.x * 15, jointdroitePos.y * 5);
                    MainDroite.transform.position -= new Vector3(0, 6.5f, 0);
                    
                }
            }
        }
    }


}
