using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSelect : MonoBehaviour
{
    public GameObject Script_BB, Script_WL, Script_Plot;

    public void selectBB()
    {
        Script_BB.SetActive(true);
        Script_WL.SetActive(false);
        Plot.maxValue = 1f;
    }
    public void selectWL()
    {
        Script_WL.SetActive(true);
        Script_BB.SetActive(false);
        Plot.maxValue = 25f;
    }
    public void selectManual()
    {
        Controller.isPID = false;
    }
    public void selectPID()
    {
        Controller.isPID = true;
    }
    public void selectDist()
    {
        Controller.isPID = true;
        Controller.isDist = true;
    }
    public void selectConfig()
    {
        Controller.isPID = true;
        Controller.isConfig = true;
    }
}
