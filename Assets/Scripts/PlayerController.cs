using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacterController {

    public string playerName = "Player";
    public GameObject snakeBodyPrefeb;

    private Color color = Color.blue;
    private int length = 10;
    private int score = 0;

    public Color Color
    {
        get
        {
            return color;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(Random.Range(100, 400), 0, Random.Range(100, 400));
        for (int i = 0; i < length; i++)
        {
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.transform.localPosition = new Vector3(0, 0, -i - 0.3f);
        }
        foreach (Transform child in transform)
            child.GetComponent<MeshRenderer>().material.color = color;
    }
	
	void FixedUpdate () {        
        GetComponent<MovementController>().move();
        var headPosition = transform.GetChild(0).position;
        if (headPosition.x < 0 || headPosition.x > 500 || headPosition.z < 0 || headPosition.z > 500)
                GameObject.Find("GameEngine").GetComponent<GameEngine>().GameOver();

    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateSize();
    }

    private void UpdateSize()
    {
        while (score / 10 > (length - 9))
        {
            var lastBodyPosistion = transform.GetChild(transform.childCount - 1).position;
            length++;
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.GetComponent<MeshRenderer>().material.color = color;
            body.transform.position = lastBodyPosistion;
        }
    }
}
