using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public TextMeshPro Valve, StepScreen;
    public static float setPoint, pGain, iGain, dGain, pv, disturb, step;
    public static bool isManual, isPID, isDist, isConfig, config;
    void Start()
    {
        disturb = 0;
        pGain = 0.5f; 
        iGain = 0.000f;
        dGain = 0.075f;
        step = 1f; 

        isPID = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectSelect.isPV)
            Valve.text = pv.ToString("0.00");
        if (ObjectSelect.isSP)
            Valve.text = setPoint.ToString("0.00");
        if (ObjectSelect.isP)
            Valve.text = pGain.ToString("0.00");
        if (ObjectSelect.isI)
            Valve.text = iGain.ToString("0.00");
        if (ObjectSelect.isD)
            Valve.text = dGain.ToString("0.00");
        
        StepScreen.text = step.ToString("0");
    }
}
