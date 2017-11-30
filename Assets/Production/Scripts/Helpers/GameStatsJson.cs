using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStatsJson {
	public int resourceAmount;
	public int westDefenseBasic;
	public int westDefenseAdvance;
	public int eastDefenseBasic;
	public int eastDefenseAdvance;
	public int northDefenseBasic;
	public int northDefenseAdvance;
	public int southDefenseBasic;
	public int southDefenseAdvance;
	public int peopleAmount;
	public int farmAmount;
	public int foodAmount;
	public List<string> upgradesGot;
}
