using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.VFX;
using UnityEditor.VFX;

public class LiquidTemperture : MonoBehaviour
{
    [Header("Shader")]
    [SerializeField] Renderer materialRenderer;
    [SerializeField] float boilingColorIntensity = 0.8f;
    [SerializeField] float waterColorIntensity = 1f;
    [SerializeField] float frozenColorIntensity = 2f;

    [Header("Particles")]
    public VisualEffect particles;
    [SerializeField] Texture2D bubbleImg;
    [SerializeField] Texture2D snowflakeImg;

    [Header("Temperture Vars")]
    public TempertureController temperture;
    public bool isBoiling = false;
    public float targetTemperture = 20;
    [SerializeField] float tempertureChangeRate = 5f;

    private void Start()
    {
        temperture = GetComponent<TempertureController>();
    }

    public void Update()
    {
        BoilingHandle();
        ParticlesHandle();
    }

    void BoilingHandle()
    {
        if (isBoiling)
        {
            if (temperture.temp < targetTemperture)
                temperture.temp += tempertureChangeRate * Time.deltaTime;
        }
        else
        {
            if (temperture.temp > targetTemperture)
                temperture.temp -= tempertureChangeRate * Time.deltaTime;
        }
    }

    void ParticlesHandle()
    {
        if (temperture.temp >= 99)
        {
            particles.gameObject.SetActive(true);
            particles.SetTexture("Texture", bubbleImg);
            materialRenderer.material.SetFloat("Intensity", boilingColorIntensity);
        }
        else if(temperture.temp<=0)
        {
            particles.gameObject.SetActive(true);
            particles.SetTexture("Texture", snowflakeImg);
            materialRenderer.material.SetFloat("Intensity", frozenColorIntensity);
        }
        else
        {
            particles.gameObject.SetActive(false);
            materialRenderer.material.SetFloat("Intensity", waterColorIntensity);
        }
    }

    public void Boile(float targetTemperture,float tempertureChangeRate)
    {
        this.tempertureChangeRate = tempertureChangeRate;
        isBoiling = true;
        this.targetTemperture = targetTemperture;
    }

    public void StopBoile()
    {
        this.tempertureChangeRate = 2f;
        isBoiling = false;
        targetTemperture = 30f;
    }

    public void CoolDown(float targetTemperture, float tempertureChangeRate)
    {
        this.tempertureChangeRate = tempertureChangeRate;
        isBoiling = false;
        this.targetTemperture = targetTemperture;
    }

    //Otan teleiwsei to Scene to default Intensity prepei na ksanaginei 1 gia na min epireasei to gameobjects me to idio material sta alla scenes
    private void OnDisable()
    {
        materialRenderer.material.SetFloat("Intensity", waterColorIntensity);
    }

}
