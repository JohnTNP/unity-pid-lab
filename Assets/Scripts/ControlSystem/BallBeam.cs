using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ControlSystem;
using FourBarLink;

public class BallBeam : MonoBehaviour
{
    public GameObject Ball, Beam, Bar, MotorDisk;
    private BallBeamTF _BallBeamTF;
    private PID _PID;
    private FourBar _FourBar;
    private float ballPos, beamAngle, _error, actSignal, pActSignal;
    void Start()
    {
        _BallBeamTF = new BallBeamTF(1f, 1f);
        _FourBar = new FourBar(0.067f, 0.24f, 0.39f, 0.40f);
        _PID = new PID(Controller.pGain, Controller.iGain, Controller.dGain);

        Controller.setPoint = 0;
    }
    void Update()
    {
        Controller.step = 0.1f;
        _PID.UpdateGain(Controller.pGain, Controller.iGain, Controller.dGain);
        _error = Controller.setPoint - ballPos;

        actSignal = _PID.ActSignal(_error); 
        actSignal = Mathf.Clamp(actSignal, -1f, 1f);

        beamAngle = Beam.transform.localEulerAngles.x * Mathf.Deg2Rad;
        if (Controller.isPID)
        {
            beamAngle = actSignal;
            ballPos = _BallBeamTF.BallPos(beamAngle)+0.05f*Controller.disturb;
        }

        if (ballPos > 0.8f || ballPos < 0) 
        {
            ballPos = 0;
            _BallBeamTF.Reset();
        }

        if (Controller.config) _BallBeamTF.Gain(5);
        if (!Controller.config) _BallBeamTF.Gain(1);

        ballPos = -_BallBeamTF.BallPos(beamAngle)+0.05f*Controller.disturb;
        ballPos *= 0.8f/2f;
        Ball.transform.localPosition = new Vector3(0.6134f, 0.0375f, Mathf.Clamp(-ballPos, -0.8f, 0));
        //Beam.transform.localEulerAngles = new Vector3(Mathf.Clamp(beamAngle*180/Mathf.PI, -10f, 10f), 0, 0);
        float motorAngle = - 45f*Mathf.Deg2Rad - MotorDisk.transform.eulerAngles.x * Mathf.Deg2Rad + Mathf.PI;
        float barAngle = _FourBar.FourBarAngle(MotorDisk.transform.eulerAngles.x * Mathf.Deg2Rad)[0];
        float beamAngleFB = _FourBar.FourBarAngle(MotorDisk.transform.eulerAngles.x * Mathf.Deg2Rad)[1];
        Bar.transform.position = new Vector3(0f, 0.067f*Mathf.Sin(motorAngle) + MotorDisk.transform.localPosition.y, 0.067f*Mathf.Cos(motorAngle) + MotorDisk.transform.localPosition.z);
        Bar.transform.localRotation = Quaternion.Euler(barAngle * Mathf.Rad2Deg - 90f, 0f, 0f);

        // Four Bar
        Beam.transform.localRotation = Quaternion.Euler(-beamAngleFB * Mathf.Rad2Deg + 180f -45f, 0f, 0f);

        Controller.pv = ballPos;
    }
}
