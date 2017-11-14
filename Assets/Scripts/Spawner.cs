using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject blueItem, redItem;
    public float modifier;

    private float screenHeight, screenWidth;
    private ItemColor.Color currentCol;

    [SerializeField]
    private float respawnTimer = 2.5f;
    private float currentRespawnTime;

    // Use this for initialization
    void Start ()
    {
        GameControl.Reset();
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        currentRespawnTime = respawnTimer;
        currentCol = ItemColor.Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        currentRespawnTime -= Time.deltaTime;

        if(currentRespawnTime <= 0 && !GameControl.gameOver)
        {
            SpawnPrefab(currentCol);
            currentRespawnTime = respawnTimer;
            currentCol = currentCol == ItemColor.Color.red ? ItemColor.Color.blue : ItemColor.Color.red;
        }
	}

    private void SpawnPrefab(ItemColor.Color col)
    {
        GameObject go;
        if (col == ItemColor.Color.blue)
        {
            go = Instantiate(blueItem, this.transform);
        } else
        {
            go = Instantiate(redItem, this.transform);
            GameControl.IncreaseSpeed();
        }

        Item item = go.GetComponent<Item>();
        float xLoc = Random.Range(-(screenWidth-100)/2, (screenWidth-100)/2);
        item.startLocation = new Vector3(xLoc, item.startLocation.y, 0);
        item.destination = new Vector3(xLoc, item.destination.y, 0);
        item.col = col;

        if(respawnTimer <= 1.2f)
        {
            respawnTimer = 1.2f;
        }
        else
        {
            respawnTimer -= 0.25f;
        }
    }
}
