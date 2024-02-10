using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

    private void Start()
    {
		fill.color = gradient.Evaluate(1f);
		SetProgress(0);
	}

    public void SetProgress(float Progress)
	{
		slider.value = Progress;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
