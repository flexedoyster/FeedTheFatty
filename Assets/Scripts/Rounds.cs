﻿using UnityEngine;
using System.Collections;

public class Rounds : MonoBehaviour {
	public int gameState;
	public int roundTime;
	public int maxRounds;
	public float timer;
	public float randomTime;
	public bool roundActive;
	public bool timeSet;
	public int minWait;
	public int maxWait;
	public GameObject[] foodList;
	public food foodClone; 


	// Use this for initialization
	void Start () {
	maxRounds = 2;
	roundActive = false;
	timeSet = false;
	timer = 0;
	roundTime = 10;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(roundActive == true)
		{
			if(timer > roundTime)
			{
				setRound(0);
				timer = 0;
			}
		}
		else
		{
			if(timeSet == false)
			{
				randomTime=Random.Range(minWait,maxWait);
				timeSet=true;
			}
			if(timer>randomTime)
			{
				setRound(Random.Range(1,maxRounds+1));
				timer = 0;
			}
		}
		switch (gameState)
		{
		case 1: 
			bigFood ("Top");
			bigFood ("Bottom");
			break;
		}
	}

	public void setRound(int num)
	{
		gameState = num;
		if (gameState>0)
		{
			roundActive = true;
		}
		else
		{
			roundActive = false;
			timeSet = false;
		}
	}
	
	public int getRound()
	{
		return gameState;
	}

	private void bigFood(string tag)
	{
		foodList = GameObject.FindGameObjectsWithTag(tag);
		for(int i = 0; i < foodList.Length; i++)
		{
			foodClone = (food)foodList[i].gameObject.GetComponent(typeof(food));
			if(foodClone.getType()==1)
			{
				foodClone.transform.localScale = new Vector3(.60f, .60f, 0);
				CapsuleCollider myCollider = foodClone.transform.GetComponent<CapsuleCollider>();
				myCollider.radius = 4f;
			}
		}
	}
	private void announcement()
	{

	}

}
