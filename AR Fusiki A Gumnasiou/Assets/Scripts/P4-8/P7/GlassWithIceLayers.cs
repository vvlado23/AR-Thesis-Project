using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWithIceLayers : MonoBehaviour
{
    [SerializeField] GameObject iceCubes;
    [SerializeField] GameObject particles;
    [SerializeField] List<TempertureController> layers = new List<TempertureController>();

    public void SetTemperture()
    {
        particles.SetActive(true);
        iceCubes.SetActive(true);
        layers[0].temp = 0;
        layers[1].temp = 2;
        layers[2].temp = 4;
    }
}
