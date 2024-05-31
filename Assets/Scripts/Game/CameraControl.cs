using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera MainCam;
    public Transform MenuCam, ModuleCam, OverallCam, ExperimentCam;
    private Transform target;
    [SerializeField] private float moveSpeed, rotateSpeed;
    void Start()
    {
        MainCam.transform.position = MenuCam.transform.position;
        target = MenuCam;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectPosition.moduleBallBeam)
            target = ModuleCam;
        if (ObjectPosition.enterBallBeam)
            target = OverallCam; 
        if (ObjectPosition.experimentView)
            target = ExperimentCam;

        MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, target.position, moveSpeed * Time.deltaTime);
        MainCam.transform.eulerAngles = Vector3.Lerp(MainCam.transform.eulerAngles, target.eulerAngles, rotateSpeed * Time.deltaTime);
    }
}
