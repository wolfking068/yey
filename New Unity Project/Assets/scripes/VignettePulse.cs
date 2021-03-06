﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class VignettePulse : MonoBehaviour {
    public PostProcessVolume m_Volume;
    public Vignette m_Vignette;
    public float health = 100;
    void Start()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        ////m_Vignette.enabled.Override(true);
        ////m_Vignette.intensity.Override(1f);

        ////m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void Update()
    {
        if(health <= 50)
        {
            m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
            m_Vignette = ScriptableObject.CreateInstance<Vignette>();
            m_Vignette.enabled.Override(true);
            m_Vignette.intensity.Override(1f);

            m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        }
        if(health >= 60)
        {
            m_Vignette.enabled.Override(false);
        }
        //m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
