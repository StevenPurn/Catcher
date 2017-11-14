using UnityEngine;
using UnityEngine.UI;

public class MoveBetweenPoints : MonoBehaviour {

    public bool startLeft;
    private Vector2 startPosition, endPosition;
    public bool towardsStart;
    private RectTransform rectTrans;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        rectTrans = GetComponent<RectTransform>();
        towardsStart = false;
        float xSize = rectTrans.rect.width / 2;
        float ySize = rectTrans.rect.height / 2;
        RectTransform panelTrans = panel.GetComponent<RectTransform>();
        if (startLeft)
        {
            startPosition = new Vector2(xSize, -ySize);
            endPosition = new Vector2(panelTrans.rect.width - xSize, -ySize);
        }
        else
        {
            startPosition = new Vector2(-xSize, ySize);
            endPosition = new Vector2(-panelTrans.rect.width + xSize, ySize);
        }
        Debug.Log("Start position: " + startPosition.ToString());
        Debug.Log("End position: " + endPosition.ToString());
        rectTrans.anchoredPosition = startPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (towardsStart)
        {
            MoveTowards(startPosition);
        }
        else
        {
            MoveTowards(endPosition);
        }

        if(rectTrans.anchoredPosition == startPosition || rectTrans.anchoredPosition == endPosition)
        {
            ChangeDirection();
        }
	}

    private void MoveTowards(Vector3 pos)
    {
        float step = GameControl.speed * Time.deltaTime;
        rectTrans.anchoredPosition = Vector3.MoveTowards(rectTrans.anchoredPosition, pos, step);
    }

    public void ChangeDirection()
    {
        towardsStart = !towardsStart;
    }
}
