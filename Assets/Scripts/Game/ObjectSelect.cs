using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControlSystem;

public class ObjectSelect : MonoBehaviour
{
    public Material Light, No_Light;
    public GameObject spBtn, pvBtn, pBtn, iBtn, dBtn;
    private Renderer spRdr, pvRdr, pRdr, iRdr, dRdr;
    public static bool isSP, isPV, isP, isI, isD;
    void Start()
    {
        spRdr = spBtn.GetComponent<Renderer>();
        pvRdr = pvBtn.GetComponent<Renderer>();
        pRdr = pBtn.GetComponent<Renderer>();
        iRdr = iBtn.GetComponent<Renderer>();
        dRdr = dBtn.GetComponent<Renderer>();

        isSP = false;
        isPV = true;
        isP = false;
        isI = false;
        isD = false;
    }
    public void SetActive()
    {
        if (isSP) spRdr.material = Light; 
        if (!isSP) spRdr.material = No_Light; 
        if (isPV) pvRdr.material = Light; 
        if (!isPV) pvRdr.material = No_Light; 
        if (isP) pRdr.material = Light; 
        if (!isP) pRdr.material = No_Light; 
        if (isI) iRdr.material = Light; 
        if (!isI) iRdr.material = No_Light; 
        if (isD) dRdr.material = Light; 
        if (!isD) dRdr.material = No_Light; 
    }

}
