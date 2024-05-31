using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ballBeamIn()
    {
        ObjectPosition.ballBeamLoad = true;
    }
    public void ballBeamOut()
    {
        if (!ObjectPosition.moduleBallBeam)
            ObjectPosition.ballBeamLoad = false;
    }
    public void waterLevelIn()
    {
        ObjectPosition.waterLevelLoad = true;
    }
    public void waterLevelOut()
    {
        if (!ObjectPosition.moduleWaterLevel)
            ObjectPosition.waterLevelLoad = false;
    }

    public void clickBallBeam()
    {
        ObjectPosition.moduleBallBeam = true;
    }
    public void clickWaterLevel()
    {
        ObjectPosition.moduleWaterLevel = true;
    }

    public void clickModule()
    {
        ObjectPosition.enterBallBeam = true;
    }
    public void clickExperiment()
    {
        ObjectPosition.experimentView = true;
    }

    //Controller
    public void SPClicked()
    {
        ObjectSelect.isSP = true;
        ObjectSelect.isPV = false;
        ObjectSelect.isP = false;
        ObjectSelect.isI = false;
        ObjectSelect.isD = false;
    }
    public void PVClicked()
    {
        ObjectSelect.isSP = false;
        ObjectSelect.isPV = true;
        ObjectSelect.isP = false;
        ObjectSelect.isI = false;
        ObjectSelect.isD = false;
    }
    public void PClicked()
    {

        ObjectSelect.isSP = false;
        ObjectSelect.isPV = false;
        ObjectSelect.isP = true;
        ObjectSelect.isI = false;
        ObjectSelect.isD = false;
    }
    public void IClicked()
    {

        ObjectSelect.isSP = false;
        ObjectSelect.isPV = false;
        ObjectSelect.isP = false;
        ObjectSelect.isI = true;
        ObjectSelect.isD = false;
    }
    public void DClicked()
    {

        ObjectSelect.isSP = false;
        ObjectSelect.isPV = false;
        ObjectSelect.isP = false;
        ObjectSelect.isI = false;
        ObjectSelect.isD = true;
    }
    public void IncreaseStep()
    {
        if (ObjectSelect.isSP) Controller.setPoint += Controller.step;
        if (ObjectSelect.isP) Controller.pGain += Controller.step;
        if (ObjectSelect.isI) Controller.iGain += Controller.step;
        if (ObjectSelect.isD) Controller.dGain += Controller.step;
    }
    public void DecreaseStep()
    {

        if (ObjectSelect.isSP) Controller.setPoint -= Controller.step;
        if (ObjectSelect.isP) Controller.pGain -= Controller.step;
        if (ObjectSelect.isI) Controller.iGain -= Controller.step;
        if (ObjectSelect.isD) Controller.dGain -= Controller.step;
    }

    //Disturbances
    public void AddDist()
    {
        Controller.disturb = 1;
    }
    public void RemoveDist()
    {
        Controller.disturb = -1;
    }

    //Configurations
    public void Config1()
    {
        Controller.config = false;
    }
    public void Config2()
    {
        Controller.config = true;
    }
    

    public void gameQuit()
    {
        Application.Quit();
    }
    public void gameReset()
    {
        ObjectPosition.experimentView = false;
        ObjectPosition.enterBallBeam = false;
        ObjectPosition.moduleBallBeam = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
