using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeasureTape : MonoBehaviour
{
    [SerializeField] GameObject tapeBody;//xriazete gia na dw an einai active to MeshRenderer, diladi an to blepei i kamera
    [SerializeField] GameObject tapePart;
    [SerializeField] GameObject startTapePart;
    [SerializeField] GameObject tapeEdge;
    [SerializeField] Transform edgePoint;

    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] Transform textPivot;

    [SerializeField] float tapePartScaleOffset;
    [SerializeField] float distance;

    public void Update()
    {
        if(edgePoint.gameObject.activeSelf)
        {
            gameObject.transform.LookAt(edgePoint);
            tapeEdge.transform.position = edgePoint.position; 
            GetDistance();
            TextLookAtCamera();
        }
    }

    void GetDistance()
    {
        Vector2 edgePosition = new Vector2(tapeEdge.transform.position.x, tapeEdge.transform.position.z);
        Vector2 startPosition = new Vector2(startTapePart.transform.position.x, startTapePart.transform.position.z);

        distance = (edgePosition - startPosition).magnitude;
        //distance = (distance-0.15f) * 100;
        distance *= 100;
        float newDistance = Mathf.Floor(distance) / 10f;
        distanceText.text = newDistance + " cm";

        ScaleMeasure(newDistance);
    }

    void TextLookAtCamera()
    {
        if(tapeBody.GetComponent<MeshRenderer>().enabled)
        {
            Vector3 textPos = Camera.main.WorldToScreenPoint(textPivot.position);
            distanceText.gameObject.SetActive(true);
            distanceText.transform.position = textPos;
        }
        else
        {
            distanceText.gameObject.SetActive(false);
        }
        
    }

    void ScaleMeasure(float newDistance)
    {
        //find center of start and edge of measure
        Vector3 center = Vector3.Lerp(tapeEdge.transform.position, startTapePart.transform.position,0.5f);
        tapePart.transform.position = center;
        
        float newScale = tapePart.transform.localScale.x * (newDistance * tapePartScaleOffset);

        tapePart.transform.localScale = new Vector3(1f, 1f, newScale);
    }
}
