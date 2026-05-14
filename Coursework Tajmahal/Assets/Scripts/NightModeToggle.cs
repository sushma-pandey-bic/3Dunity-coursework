using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;

public class NightModeToggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Lightning")]
    public Light directionalLight;
    public Material daySkybox;
    public Material nightSkybox;


    [Header("Day Settings")]
    public Color dayLightColor = new Color(1f, 0.95f, 0.8f);
    public float dayLightIntensity = 1.2f;

    [Header("Night Settings")]
    public Color nightLightColor = new Color(0.2f, 0.2f, 0.5f);
    public float nightLightIntensity = 0.1f;

    private bool isNight = false;
    void Start()
    {
        //Start in day mode
        ApplyDayMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            isNight = !isNight;

            if (isNight)
                ApplyNightMode();
            else
                ApplyDayMode();

        }
    }
    void ApplyDayMode()
    {
        RenderSettings.skybox = daySkybox;
        directionalLight.color = dayLightColor;
        directionalLight.intensity = dayLightIntensity;
        DynamicGI.UpdateEnvironment();  //updates ambient lighting

    }
    void ApplyNightMode()
    {
        RenderSettings.skybox = nightSkybox;
        directionalLight.color = nightLightColor;
        directionalLight.intensity = nightLightIntensity;
        DynamicGI.UpdateEnvironment();  //updates ambient lighting
    }
}
