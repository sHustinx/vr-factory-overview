using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timeline : MonoBehaviour
{
	public Slider mainSlider;
	
	private DateTime currentTime;
	private DateTime maxTime;
	private DateTime minTime;

	public void Start()
	{
		currentTime = DateTime.Now;
		minTime = new DateTime(currentTime.Year, currentTime.Month,currentTime.Day, 8, 00, 0 );
		maxTime = new DateTime(currentTime.Year, currentTime.Month,currentTime.Day, 21, 00, 0 );
		double maxTicks = maxTime.Ticks - minTime.Ticks;
		double currentTicks = currentTime.Ticks - minTime.Ticks;
		//Adds a listener to the main slider and invokes a method when the value changes.
		mainSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});

		double percentage = (double)(currentTicks / maxTicks) * 10;
		
		mainSlider.value = (float)percentage;
	}
	
	// Invoked when the value of the slider changes.
	public void ValueChangeCheck()
	{
		Debug.Log (mainSlider.value);
	}

}
