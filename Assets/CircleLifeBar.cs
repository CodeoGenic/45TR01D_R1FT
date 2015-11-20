using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleLifeBar : MonoBehaviour {
	public Image meterOne;
	public Image meterTwo;
	// Use this for initialization
	void Awake () {
	
//		meterOne.type = Image.Type.Filled;
//		meterOne.fillMethod = Image.FillMethod.Radial360;
//		meterOne.fillOrigin = (int)Image.OriginHorizontal.Right;
//
//		meterTwo.type = Image.Type.Filled;
//		meterTwo.fillMethod = Image.FillMethod.Radial360;
//		meterTwo.fillOrigin = (int)Image.OriginHorizontal.Right;
	}
	
	// Update is called once per frame
	void Update () {

		//meterTwo.fillAmount = Mathf.Max( scrollbar.value,0.001f);
		//meterOne.fillAmount = Mathf.Max( scrollbar.value,0.001f);
	}
}
