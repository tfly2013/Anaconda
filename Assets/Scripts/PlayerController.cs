using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerName = "Player";
    public int length = 10;
    public int score = 0;
    public GameObject snakeBodyPrefeb;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(Random.Range(100, 400), 0, Random.Range(100, 400));
        for (int i = 0; i < length; i++)
        {
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.transform.localPosition = new Vector3(0, 0, -i - 1);
        }            
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<MovementController>().move();
	}

    public void AddScore(int amount)
    {
        score += amount;
        UpdateSize();
    }

    private void UpdateSize()
    {
        if (score / 10 > (length - 9))
        {
            var lastBodyPosistion = transform.GetChild(transform.childCount - 1).position;
            length++;
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.transform.position = lastBodyPosistion;
        }
    }
}
