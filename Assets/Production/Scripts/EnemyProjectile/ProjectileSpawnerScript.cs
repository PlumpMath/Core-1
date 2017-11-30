using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerScript : MonoBehaviour {
	public string[] directions = {"North","South", "East", "West"};
	public float spawnX, spawnY;
	public int number;
	public GameObject enemyGO; //Sometimes first enmy is null - always needs a first enemy
	[System.Serializable]
	public class DropEnemy{
		public string name;
		public GameObject enemy;
		public int enemyRarity;
	}
	public List<DropEnemy> EnemyTable = new List<DropEnemy>();
	public int enemyChance;
	void Awake () {
		number = 1;		
	}
	public void StartGame(){
		StartCoroutine(SpawnProjectile(1.5f));
		StartCoroutine(DifficultyUP());
	}
	void CalculateEnemy(){
		int calculatedEnemyChance = Random.Range(0,101);
		if(calculatedEnemyChance > enemyChance){
			return;
		} else{
			int itemWeight = 0;
			for(int i = 0; i < EnemyTable.Count; i++){
				itemWeight += EnemyTable[i].enemyRarity;
			}
			int randomValue = Random.Range(0, itemWeight);

			for(int j = 0; j < EnemyTable.Count; j++){
				if(randomValue <= EnemyTable[j].enemyRarity){
					enemyGO = EnemyTable[j].enemy;
					return;
				}
				randomValue -= EnemyTable[j].enemyRarity;
			}	
		}

	}
	private IEnumerator DifficultyUP(){
		while (true)
        {
            yield return new WaitForSeconds(5);
			int calculatedChance = Random.Range(0,101);
			if(enemyChance < 100){
				enemyChance++;
			}
			if(EnemyTable[0].enemyRarity > 21){
				EnemyTable[0].enemyRarity = EnemyTable[0].enemyRarity - 2;
				if(calculatedChance >= 35){
					EnemyTable[1].enemyRarity = EnemyTable[1].enemyRarity + 2;
				}
				if(calculatedChance >= 80){
					EnemyTable[2].enemyRarity = EnemyTable[2].enemyRarity + 2;
				}
			} else {
				if(	EnemyTable[1].enemyRarity < 80){
					EnemyTable[1].enemyRarity = EnemyTable[1].enemyRarity + 2;

				}
				if(calculatedChance >= 35){
					EnemyTable[2].enemyRarity = EnemyTable[2].enemyRarity + 3;
				}
			}
			
		}
	}
	private IEnumerator SpawnProjectile(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
			CalculateEnemy();
          	string cardinal = directions[Random.Range(0,directions.Length)];
			//Debug.Log(cardinal);
			if(cardinal == "South"){
				spawnY =  Random.Range(-17.0f, -27.0f);
				spawnX =  Random.Range(-25.0f, 25.0f);	
					GameObject item = Instantiate(enemyGO,new Vector2(spawnX, spawnY), Quaternion.identity);
				item.layer = LayerMask.NameToLayer("South");	
				item.name = number.ToString();
				number++;
				
			} else if (cardinal == "North"){
				spawnY =  Random.Range(17.0f, 27.0f);
				spawnX =  Random.Range(-25.0f, 25.0f);	
					GameObject item = Instantiate(enemyGO,new Vector2(spawnX, spawnY), Quaternion.identity);
				item.layer = LayerMask.NameToLayer("North");
				item.name = number.ToString();
				number++;
			}
			else if (cardinal == "West"){
				spawnY =  Random.Range(-15.0f, 15.0f);
				spawnX =  Random.Range(-26f, -36.0f);	
				GameObject item = Instantiate(enemyGO,new Vector2(spawnX, spawnY), Quaternion.identity);
				item.layer = LayerMask.NameToLayer("West");
				item.name = number.ToString();
				number++;
			}
			else{
				spawnY =  Random.Range(-15.0f, 15.0f);
				spawnX =  Random.Range(26f, 36.0f);	
					GameObject item = Instantiate(enemyGO,new Vector2(spawnX, spawnY), Quaternion.identity);
				item.layer = LayerMask.NameToLayer("East");
				item.name = number.ToString();
				number++;
			}
			
        }
    }
}
