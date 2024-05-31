using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControlSystem;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    public static float waterOut;
    public GameObject Water;
    private float flowRate;
    private WaterLevelTF _WaterLevelTF;
    private PID _PID;
    private float waterLevel, actSignal, _error;
    void Start()
    {
        _WaterLevelTF = new WaterLevelTF(1f, 1f);
        _PID = new PID(Controller.pGain, Controller.iGain, Controller.dGain);

        Controller.setPoint = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Controller.step = 1;

        _PID.UpdateGain(Controller.pGain, Controller.iGain, Controller.dGain);
        _error = Controller.setPoint - waterLevel;

        actSignal = _PID.ActSignal(_error);

        if (!Controller.isPID)
        {
            waterLevel = _WaterLevelTF.WaterLevel(flowRate)+2*Controller.disturb;
        }

        if (Controller.isPID)
        {
            flowRate = actSignal;
            waterLevel = _WaterLevelTF.WaterLevel(flowRate)+2*Controller.disturb;
        }
        
        if (Controller.config) _WaterLevelTF.Gain(5);
        if (!Controller.config) _WaterLevelTF.Gain(1);

        flowRate = Mathf.Clamp(flowRate, 0f, 20f);
        Water.transform.localScale = new Vector3(1, 1 + waterLevel, 1);

        Controller.pv = waterLevel;
    }
}
