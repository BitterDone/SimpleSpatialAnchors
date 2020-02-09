using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSceneSetUp : MonoBehaviour
{
	public GameObject cubePrefab;
	[Range(10, 500)]
	public float cubeDistance = 100;
	public float maxAudioScale = 1000;
	public float cubeScale = 5f;
	GameObject[] sampleCubes = new GameObject[512];
	float rootRotVal = -.703125f;
	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < 512; i++)
		{
			GameObject cubeInst = GameObject.Instantiate(cubePrefab);
			cubeInst.transform.parent = transform;
			cubeInst.transform.localPosition = Vector3.zero;
			cubeInst.transform.localPosition = transform.forward * cubeDistance;
			cubeInst.transform.parent = null;
			cubeInst.name = "AudioCube " + i;
			sampleCubes[i] = cubeInst;
			transform.eulerAngles = new Vector3(0, rootRotVal * i, 0);
		}

	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < 512; i++)
		{
			if (sampleCubes[i] != null)
			{
				sampleCubes[i].transform.localScale = new Vector3(cubeScale, (AudioPeer.samples[i] * maxAudioScale) +2, cubeScale);
			}
		}
	}
}
