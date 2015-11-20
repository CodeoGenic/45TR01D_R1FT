using UnityEngine;
using System.Collections;

public class ChangeSkybox : MonoBehaviour {

	public Material warp;
	public Material mainSkybox;

	public void Warp()
	{
		RenderSettings.skybox = warp;
	}

	public void MainSkybox()
	{
		RenderSettings.skybox = mainSkybox;
	}
}
