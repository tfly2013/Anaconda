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
        score = Random.Range(0, 200);
        UpdateSize();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (transform.position.x < 0 || transform.position.x > 500)
            if (transform.position.y < 0 || transform.position.y > 500)
                Destroy(this);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateSize();
    }

    private void UpdateSize()
    {
        var x = Mathf.Log(score, 50);
        var z = Mathf.Log10(score);
        x = x < 1 ? 1 : x;
        z = z < 1 ? 1 : z;
        transform.localScale = new Vector3(x, 1, z);
    }
}
