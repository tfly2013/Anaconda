using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public int score = 0;
    public float moveSpeed = 5f;

    private Color[] colors = { Color.red, Color.yellow, Color.blue, Color.green, Color.black, Color.white, Color.cyan, Color.magenta };

    // Use this for initialization
    void Start () {
        var color = colors[(int)Random.Range(0, colors.Length - 1)];
        GetComponentInChildren<MeshRenderer>().material.color = color;
        score = Random.Range(0, 10000);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
