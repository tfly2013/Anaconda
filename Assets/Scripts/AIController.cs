using UnityEngine;

public class AIController : MonoBehaviour, ICharacterController {

    public GameObject snakeBodyPrefeb;
    public float moveSpeed = 10;
    public float rotationSpeed = 120;

    private int score = 0;
    private int length = 10;
    private Color color;
    private Color[] colors = { Color.red, Color.yellow, Color.blue, Color.green, Color.black, Color.white, Color.cyan, Color.magenta };

    public int Score
    {
        get
        {
            return score;
        }
    }

    public Color Color
    {
        get
        {
            return color;
        }
    }

    // Use this for initialization
    void Start () {
        color = colors[(int)Random.Range(0, colors.Length - 1)];
        for (int i = 0; i < length; i++)
        {
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.transform.localPosition = new Vector3(0, 0, -i - 0.3f);
        }
        score = Random.Range(0, 200);
        UpdateSize();
        foreach (Transform child in transform)
            child.GetComponent<MeshRenderer>().material.color = color;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        var targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        for (int i = transform.childCount - 1; i > 0; i--)
            transform.GetChild(i).position = Vector3.MoveTowards(transform.GetChild(i - 1).position, transform.GetChild(i).position, 0.3f);
        transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.GetChild(0).position += transform.GetChild(0).forward * Time.deltaTime * moveSpeed;
        var headPosition = transform.GetChild(0).position;
        if (headPosition.x < 0 || headPosition.x > 500 || headPosition.z < 0 || headPosition.z > 500)
            Destroy(gameObject);
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
