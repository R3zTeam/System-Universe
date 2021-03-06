﻿using UnityEngine;

/// <summary>
/// Splash Manager
/// Description: Handles the fading in and out of the different splash screens.
/// </summary>

public class SplashManager : MonoBehaviour
{
    // public variables
    public CanvasGroup cgTitle; // title screen
    public CanvasGroup cgSplash;    // the splash canvas
    public float fltFadeSpeed;  // fade speed
    public float fltDelayRate;  // the delay rate before a fade out

    // private variables
    private bool m_blnFadeIn;    // check if we should fade in
    private bool m_blnFadeOut;   // check if we should fade out
    private float m_fltTimer;   // timer for the delay

    // Use this for initialization
    void Start()
    {
        m_blnFadeIn = true; // begin fade in
        m_fltTimer = fltDelayRate;  // set the timer
    }

    // Update is called once per frame
    void Update()
    {
        // if fade in is true
        if (m_blnFadeIn)
        {
            // check if the alpha is less than 1
            if (cgTitle.alpha < 1)
            {
                // increase the alpha
                cgTitle.alpha += Time.deltaTime * fltFadeSpeed;
            }
            else
            {
                // if the timer is not 0
                if (m_fltTimer > 0)
                {
                    // decrease the timers
                    m_fltTimer -= Time.deltaTime;
                }
                else
                {
                    // begin fade out
                    m_blnFadeIn = false;
                    m_blnFadeOut = true;
                }
            }
        }

        // if fade out is true
        if (m_blnFadeOut)
        {

            // check if the alpha is greater than 0
            if (cgSplash.alpha > 0)
                // decrease the alpha
                cgSplash.alpha -= Time.deltaTime * fltFadeSpeed;
            else
                // disable this script
                this.GetComponent<SplashManager>().enabled = false;
        }
    }
}