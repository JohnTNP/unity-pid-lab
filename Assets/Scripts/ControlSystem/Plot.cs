using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] GameObject PlotScreen;
    [SerializeField] private Color c1 = Color.white;
    private int lineRendererLength = 100;
    private float plotWidth, plotHeight, plotLength, xScale, yScale, zScale;
    private Vector3 containerPos;
    private float offset;
    private List<float> dataList = new List<float>();
    public static float maxValue;

    void Start()
    {
        maxValue = 25f;
        plotWidth = PlotScreen.transform.localScale.z; 
        plotHeight = PlotScreen.transform.localScale.x; 
        plotLength = PlotScreen.transform.localScale.y;
        zScale = plotWidth/lineRendererLength;
        yScale = plotHeight/maxValue;

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>(); 
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.0075f;
        lineRenderer.positionCount = lineRendererLength;
        lineRenderer.startColor = c1;
        lineRenderer.endColor = c1;

        offset = 0.0f;

        containerPos = PlotScreen.transform.position;
        containerPos += new Vector3(plotHeight/2, plotLength/2, -plotWidth/2.0f + offset);
        for (int i = 0; i < lineRendererLength; i++) dataList.Add(0);

        StartCoroutine("_Plot");
    }
    IEnumerator _Plot()
    {
        while (true)
        {
            yScale = plotHeight/maxValue;
            containerPos = PlotScreen.transform.position;
            containerPos += new Vector3(0.01f, -plotHeight/2, -plotWidth/2.0f + offset);

            LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>(); 

            dataList.RemoveAt(0);
            dataList.Add(Controller.pv);
            for (int i = 0; i < lineRendererLength; i++)
            {
                lineRenderer.SetPosition(i, new Vector3(containerPos.x, containerPos.y + Mathf.Clamp(dataList[i], 0, maxValue)*yScale, containerPos.z + i*zScale));
            }


            yield return new WaitForSeconds(0.03f);
        }
    }

}
