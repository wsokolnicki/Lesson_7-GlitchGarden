using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [Range(1f, 10f)] [SerializeField] float gameSpeed = 1f;

    void Start () {
		
	}
	
	void Update ()
    {
        Time.timeScale = gameSpeed;
	}
}
