using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPosition : MonoBehaviour
{
    [SerializeField] private GameObject BallBeam, WaterLevel, Plot, Controller;
    private Vector3 BallBeamOrigin, PlotOrigin, BallBeamTarget, PlotTarget, WaterLevelTarget, WaterLevelOrigin;
    private Vector3 ControllerTarget, ControllerOrigin;
    private float loadSpeed = 4;
    [SerializeField]
    public static bool ballBeamLoad, waterLevelLoad;
    public static bool enterBallBeam, enterWaterLevel;
    public static bool moduleBallBeam, moduleWaterLevel;
    public static bool experimentView;
    public static bool PIDLoad;
    // Start is called before the first frame update
    void Start()
    {
        ballBeamLoad = false;
        waterLevelLoad = false;

        BallBeamTarget = new Vector3(5, 0, 10);
        BallBeamOrigin = BallBeam.transform.localPosition; 
        BallBeam.transform.localPosition = BallBeamOrigin - BallBeamTarget; 

        WaterLevelTarget = new Vector3(0, -10, 0);
        WaterLevelOrigin = WaterLevel.transform.localPosition;
        WaterLevel.transform.localPosition = WaterLevelOrigin - WaterLevelTarget;

        ControllerTarget = new Vector3(-8, -5, 0);
        ControllerOrigin = Controller.transform.localPosition;
        Controller.transform.localPosition = ControllerOrigin - ControllerTarget;

        PlotTarget = new Vector3(-8, -5, 0);
        PlotOrigin = Plot.transform.localPosition; 
        Plot.transform.localPosition = PlotOrigin - PlotTarget; 
    }
    // Update is called once per frame
    void Update()
    {
        if (ballBeamLoad)
            BallBeam.transform.localPosition = Vector3.Lerp(BallBeam.transform.localPosition, BallBeamOrigin, loadSpeed*Time.deltaTime);    
            
        if (!ballBeamLoad)
            BallBeam.transform.localPosition = Vector3.Lerp(BallBeam.transform.localPosition, -BallBeamTarget, 0.5f*loadSpeed*Time.deltaTime);    

        if (waterLevelLoad)
            WaterLevel.transform.localPosition = Vector3.Lerp(WaterLevel.transform.localPosition, WaterLevelOrigin, loadSpeed*Time.deltaTime);    

        if (!waterLevelLoad)
            WaterLevel.transform.localPosition = Vector3.Lerp(WaterLevel.transform.localPosition, -WaterLevelTarget, 0.5f*loadSpeed*Time.deltaTime);    

        if (ballBeamLoad || waterLevelLoad)
        {
            Controller.transform.localPosition = Vector3.Lerp(Controller.transform.localPosition, ControllerOrigin, loadSpeed*Time.deltaTime);    
            Plot.transform.localPosition = Vector3.Lerp(Plot.transform.localPosition, PlotOrigin, loadSpeed*Time.deltaTime);    
        }

    }
}
