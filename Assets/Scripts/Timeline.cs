using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timeline : MonoBehaviour
{
	public OrderManager OrderManager;
	public Slider mainSlider;
	private int currentInt;
	private DateTime currentTime;
	private DateTime maxTime;
	private DateTime minTime;

	public void Start()
	{
		currentTime = DateTime.Now;
		minTime = new DateTime(currentTime.Year, currentTime.Month,currentTime.Day, 08, 00, 0 );
		maxTime = new DateTime(currentTime.Year, currentTime.Month,currentTime.Day, 23, 59, 0 );
		double maxTicks = maxTime.Ticks - minTime.Ticks;
		double currentTicks = currentTime.Ticks - minTime.Ticks;
		//Adds a listener to the main slider and invokes a method when the value changes.
		mainSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});

		double percentage = (double)(currentTicks / maxTicks) * 10;
		currentInt = (int)Math.Floor(percentage);
		mainSlider.value = (float)percentage;
	}
	
	// Invoked when the value of the slider changes.
	public void ValueChangeCheck()
	{
		if(mainSlider.value > currentInt+1){
			currentInt = (int)Math.Floor(mainSlider.value);
			OrderManager.UpdateOrders(true);
		}
		else if(mainSlider.value < currentInt-1){
			currentInt = (int)Math.Floor(mainSlider.value);
			OrderManager.UpdateOrders(false);
		}
	}

}
