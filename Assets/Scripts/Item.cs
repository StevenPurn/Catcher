using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour {

    public Vector3 destination;
    public Vector3 startLocation;
    public ItemColor.Color col;

    private RectTransform rectTrans;
    private float speedIncreaseTime = 5.0f;

	// Use this for initialization
	void Start ()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.anchoredPosition = startLocation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move(destination);
        if (rectTrans.anchoredPosition == new Vector2(destination.x, destination.y))
        {
            //GameObject.Find("GameOverPanel").SetActive(true);
            GameControl.GameOver();
            Destroy(gameObject);
        }
	}

    private void Move(Vector3 dest)
    {
        float step = GameControl.speed * Time.deltaTime;
        rectTrans.anchoredPosition = Vector3.MoveTowards(rectTrans.anchoredPosition, dest, step);
    }

    public void ChangeDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Catcher")
        {
            if(collision.gameObject.GetComponent<ItemColor>().col == col)
            {
                GameControl.ChangeScore(1);
                Destroy(gameObject);
            }
        }
    }
}
