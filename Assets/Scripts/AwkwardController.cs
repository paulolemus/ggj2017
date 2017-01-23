using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AwkwardController : MonoBehaviour {

    public Slider awkwardSlider;

    // all changs go to this value
    private float value = 0;
    
    private float passiveIncrement = 0.1f;
    private float passiveMin       = 0.1f;
    private float passiveMax       = 1f;
    private float minorAwks        = 5f;
    private float majorAwks        = 10f;
    private float catastrophicAwks = 25f;

    private float colorIntensity   = 0.1f;
    private float colorMax         = 456243;

    private bool isDead = false;
    private bool isGettingAwkward = false;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        updateValues();
        updateGUI();
	}
   // user calls to increase passive rate
    public void gettingAwkward(bool b)
    {
        isGettingAwkward = b;
    }
    public void minorAwkward()
    {
        value += minorAwks;
    }
    public void majorAwkward()
    {
        value += majorAwks;
    }
    public void catastrophicAwkward()
    {
        value += catastrophicAwks;
    }


    void updateValues()
    {
        if (isGettingAwkward) passiveIncrement = passiveIncrement + 0.1f * Time.deltaTime;
        if (passiveIncrement >= passiveMax) passiveIncrement = passiveMax - 0.01f;
        else if (passiveIncrement > passiveMax && !isGettingAwkward) passiveIncrement = passiveIncrement - 0.1f * Time.deltaTime;

        if (awkwardSlider.value >= 99) isDead = true;
        // Do something if dead
    }
    void updateGUI()
    {
        awkwardSlider.value = value + passiveIncrement * Time.deltaTime;
    }
}
