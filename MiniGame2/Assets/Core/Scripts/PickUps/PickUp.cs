﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    public enum Type
    {
        Coin,
        PickUp,
    };

    public Type type;

    public int PointsWorth = 100;

    private ScoreControl scoreControl;

    public bool EnableRoatation = true;

    public float RotationSpeed = 1f;

    // Use this for initialization
    void Start()
    {

        scoreControl = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreControl>();

        if (type == Type.Coin)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

        }
        else if (type == Type.PickUp)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (EnableRoatation)
        {
            transform.Rotate(new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter()
    {

        Debug.Log("Hit it!!");

        if (type == Type.Coin)
        {
            GetComponent<ParticleSystem>().Play();
            
           scoreControl.AddPoints(PointsWorth);

        }

    }




}
