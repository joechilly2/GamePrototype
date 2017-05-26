using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalValueHolder : MonoBehaviour {

	public string[] deadRooms = new string[5];
	private int currentDeadRoomsRover = 0;

	public LoadNewArea dungeonLock;
	public bool dungeonLockBool = true;

	public LoadNewArea thirdRoomLock;
	public bool thirdRoomLockBool = true;

	public LoadNewArea armorRoomLock;
	public bool armorRoomLockBool = true;

	public OpenChest spawnChest;
	public bool spawnChestOpened;

	public OpenChest thirdRoomChest;
	public bool thirdRoomChestOpened;

	private int healthPotions = 0;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < deadRooms.Length; i++) {
			if (deadRooms[i].Equals(SceneManager.GetActiveScene().name)) {
				GameObject[] g = GameObject.FindGameObjectsWithTag ("Enemy");
				for (int j = 0; j < g.Length; j++) {
					//g[i].GetComponent<EnemyHealthManager>().HurtEnemy(100000);
					Destroy(g[j]);
				}
			}
		}
		dungeonLock = GameObject.Find ("Dungeon1 Entry").GetComponent<LoadNewArea>();
		dungeonLock.locked = dungeonLockBool;

		thirdRoomLock = GameObject.Find ("ThirdRoom Entry").GetComponent<LoadNewArea>();
		thirdRoomLock.locked = thirdRoomLockBool;

		armorRoomLock = GameObject.Find ("ArmorRoom Entry").GetComponent<LoadNewArea>();
		armorRoomLock.locked = armorRoomLockBool;

		spawnChest = GameObject.Find ("SpawnChest").GetComponent<OpenChest> ();
		spawnChest.hasHealthPotion = !spawnChestOpened;

		thirdRoomChest = GameObject.Find ("ThirdRoomChest").GetComponent<OpenChest> ();
		thirdRoomChest.hasHealthPotion = !thirdRoomChestOpened;

	}

	public void addDeadRoom(string s){
		bool inarray = false;
		foreach (string room in deadRooms) {
			if (room == s) {
				inarray = true;
			}
		}
		if (!inarray) {
			deadRooms [currentDeadRoomsRover] = s;
			currentDeadRoomsRover++;
		}
	}

	public void UnlockRoom(string s){
		if (s == "Dungeon1") {
			dungeonLockBool = false;
		}
		else if (s == "ThirdRoom") {
			thirdRoomLockBool = false;
		}
		else if (s == "ArmorRoom") {
			armorRoomLockBool = false;
		}
	}

	public int GetHealthPotions(){
		return healthPotions;
	}

	public void AddHealthPotion(){
		healthPotions += 1;
	}

	public bool UseHealthPotion(){
		if (healthPotions >= 1) {
			healthPotions -= 1;
			return true;
		}
		return false;
	}

	public void SetFalseHealthPotion(string s){
		if(s=="SpawnChest"){
			spawnChest.hasHealthPotion = false;
			spawnChestOpened = true;
		}
		else if(s=="ThirdRoomChest"){
			thirdRoomChest.hasHealthPotion = false;
			thirdRoomChestOpened = true;
		}
	}
}
