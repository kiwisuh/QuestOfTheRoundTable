﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.TestTools;
//using NUnit.Framework;
/*
 * RANDOM SEARCH.... 
 * =======  Cards  ======
 * STORY DECK 						= 28 TOTAL
 * QUESTS							= 13 Total
 * Search for the Holy Grail		= 1
 * Test of the Green Knight			= 1
 * Search for the Questing Beast    = 1
 * Defend the Queen's Honor			= 1
 * Rescue the Fair Maiden			= 1
 * Journey Through the Enchanted F. = 1
 * Vanquish King Arthur's Enemies	= 2
 * Slay the Dragon					= 1
 * Boar Hunt						= 2
 * Repel the Saxor Raiders			= 2 
 * 
 * TOURNAMENTS						= 4 Total
 * Tournament at Camelot 			= 1
 * Tournament at Orkney				= 1
 * Tournament at Tintagel			= 1
 * Tournament at York				= 1
 * 
 * EVENTS 							= 11 Total
 * Kings Recognition 				= 2
 * Queen's Favor 					= 2
 * Court Called to Camelot			= 2
 * Pox								= 1
 * Plague							= 1
 * Chivalous Deed					= 1
 * Prosperity Throughout the Realm 	= 1
 * King's Call to Arms				= 1
 * ==========================================
 */
/* ADVENTURE DECK 					
* Weapons 							= 49 Total
	* Excalibur						= 2
	* Lance							= 6
	* Battle-ax						= 8
	* Sword							= 16
	* Horse							= 11
	* Dagger						= 6
	* 
	* FOES 							= 50 Total
	* Dragon						= 1
	* Giant							= 2
	* Mordred						= 4
	* Green Knight					= 2
	* Black Knight					= 3
	* Evil Knight					= 6
	* Saxon Knight					= 8
	* Robber Knight					= 7 
	* Saxons						= 5
	* Boar							= 4
	* Thieves						= 8
	* 
	* TESTS 							= 8 Total
	* Test of Valor						= 2
	* Test of Temptation				= 2
	* Test of Morgan Le Fey				= 2
	* Test of the Questing Beast		= 2
	* 
	* ALLIES							= 10 Total
	* Sir Galahad						= 1
	* Sir Lancelot						= 1
	* King Arthur 						= 1
	* Sir Tristan						= 1
	* Sir Pellinore						= 1
	* Sir Gawain 						= 1
	* Sir Percival						= 1
	* Queen Quinevere					= 1
	* Queen Iseult						= 1
	* Merlin							= 1
	* 
	* AMOURS 							= 8 Total
	*/
	public class StoryDeckManager : MonoBehaviour {

	public Text storyCardText;
	Dictionary<string, int> storyDeck = new Dictionary<string, int>(){};

	public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;

	//Quests, Events, Tournaments
	public Sprite[] cards;

	// Use this for initialization
	void Start () {
		//storyCardText.text = "Story Deck.";
		populateDeck (storyDeck);
	}
		
	// Update is called once per frame
	void Update () {
		deckSize = getSizeOfDeck ();

		if (Input.GetKeyDown ("space")) {
			if (deckSize != 0) {
				
				TempCard = RandomCardPicker ();
				setSprite (TempCard);
				RemoveCard (storyDeck, TempCard);
			}

			if (deckSize == 0){
				Debug.Log ("Reshuffling Deck.");
				populateDeck (storyDeck);
			} 
		}
	}

	public string RandomCardPicker(){
	    tempKey = "";
		index = 0;
		randInt = 0;
		foreach (KeyValuePair<string, int> item in storyDeck) {
			randInt =  Random.Range (0, getSizeOfDeck()); 
			if (index == randInt) {
				tempKey = item.Key;
				return tempKey;
			}
			index += 1;
		}

		return  RandomCardPicker();	// If no card has been found: RECURSIFY
	}

	void RemoveCard(Dictionary <string, int> Deck, string tempKey){
		if (Deck.ContainsKey(tempKey) == true) {
			//Debug.Log ("STORY KEY: [" + tempKey + "] VALUE: [" + Deck [tempKey] + "] SIZE : [" + getSizeOfDeck() + "]");
			//storyCardText.text = "Story Deck: " + tempKey;
			Deck [tempKey] -= 1;
			if (Deck [tempKey] == 0) {
				Deck.Remove (tempKey);
			}
		} 
	}

	void populateDeck(Dictionary<string, int> Deck){
		/* QUESTS */
		Deck.Add("Search for the Holy Grail", 		1);
		Deck.Add("Test of the Green Knight"	, 	1);
		Deck.Add("Search for the Questing Beast",	1);
		Deck.Add("Defend the Queen's Honor",		1);
		Deck.Add("Rescue the Fair Maiden",			1);
		Deck.Add("Journey Through the Enchanted Forest",1);
		Deck.Add("Vanquish King Arthur's Enemies",	2);
		Deck.Add("Slay the Dragon",				1);
		Deck.Add("Boar Hunt",						2);
		Deck.Add("Repel the Saxon Raiders",		1);
		/* EVENTS */
		Deck.Add("Kings Recognition",				2);
		Deck.Add("Queen's Favor",					2);
		Deck.Add("Court Called to Camelot",		2);
		Deck.Add("Pox",							1);
		Deck.Add("Plague",							1);
		Deck.Add("Chivalrous Deed",					1);
		Deck.Add("Prosperity Throughout the Realm",1);
		Deck.Add("King's Call to Arms",			1);
		/* TOURNAMENTS */
		Deck.Add("Tournament at Camelot", 		1);
		Deck.Add("Tournament at Orkney",			1);
		Deck.Add("Tournament at Tintagel",			1);
		Deck.Add("Tournament at York",				1);	
	}
		
	public int getSizeOfDeck(){
		return storyDeck.Keys.Count;
	}

	public int getIndex(){
		return index;
	}

	public int getRandInt(){
		return randInt;
	}

	public string getCurrentCard(){
		return TempCard;
	}

	public int getStages (){
		int temp = 0;

		if(TempCard == "Repel the Saxon Raiders" || TempCard == "Boar Hunt"){
			temp = 2;
		}else if(TempCard == "Vanquish King Arthur's Enemies" || TempCard == "Slay the Dragon" || TempCard == "Journey Through the Enchanted Forest" || TempCard == "Rescue the Fair Maiden"){
			temp = 3;
		}else if(TempCard == "Test of the Green Knight" || TempCard == "Defend the Queen's Honor" || TempCard == "Search for the Questing Beast"){
			temp = 4;
		}else{
			temp = 5;
		}

		return temp;
	}

	void setSprite(string title){
		SpriteRenderer sp = this.GetComponent<SpriteRenderer> ();

		switch (title) {
		/* EVENTS */
		case "Chivalrous Deed":
			sp.sprite = cards [0];
			break;
		case "Court Called to Camelot":
			sp.sprite = cards [1];
			break;
		case "Queen's Favor":
			sp.sprite = cards [2];
			break;
		case "Prosperity Throughout the Realm":
			sp.sprite = cards [3];
			break;
		case "Pox":
			sp.sprite = cards [4];
			break;
		case "Plague":
			sp.sprite = cards [5];
			break;
		case "Kings Recognition":
			sp.sprite = cards [6];
			break;
		case "King's Call to Arms":
			sp.sprite = cards [7];
			break;

		/* QUESTS */
		case "Journey Through the Enchanted Forest":
			sp.sprite = cards [8];
			break;
		case "Vanquish King Arthur's Enemies":
			sp.sprite = cards [9];
			break;
		case "Repel the Saxon Raiders":
			sp.sprite = cards [10];
			break;
		case "Boar Hunt":
			sp.sprite = cards [11];
			break;
		case "Rescue the Fair Maiden":
			sp.sprite = cards [12];
			break;
		case "Slay the Dragon":
			sp.sprite = cards [13];
			break;
		case "Defend the Queen's Honor":
			sp.sprite = cards [14];
			break;
		case "Search for the Questing Beast":
			sp.sprite = cards [15];
			break;
		case "Test of the Green Knight":
			sp.sprite = cards[16];
			break;
		case "Search for the Holy Grail":
			sp.sprite = cards[17];
			break;

		/* TOURNAMENTS */
		case "Tournament at Camelot":
			sp.sprite = cards[18];
			break;
		case "Tournament at Orkney":
			sp.sprite = cards[19];
			break;
		case "Tournament at Tintagel":
			sp.sprite = cards[20];
			break;
		case "Tournament at York":
			sp.sprite = cards[21];
			break;
		}
	}
	/*
	[Test]
	public void populateDeckTest(){
		Dictionary<string, int> testDeck = new Dictionary<string, int>(){};
		populateDeck (testDeck);
		foreach (KeyValuePair<string, int> item in testDeck) {
			Debug.Log ("STORY: " + item.Key + " : " + item.Value );
		}
	}

	[Test]
	public void RemoveCardTest(){
		string testKey = "Search for the Holy Grail";							// Make sure Card only has of 1 value. 
		Dictionary<string, int> testDeck = new Dictionary<string, int>(){};
		populateDeck (testDeck);
		RemoveCard (testDeck, testKey);
		if (testDeck.ContainsKey (testKey) == true) {
			Assert.Fail ();
			Debug.LogError ("An Invalid Card has been randomly picked." + testKey + " Error...");
		} else {
			Assert.Pass ();
			Debug.Log ("Card successfully removed.");
		}
	}*/

}
	