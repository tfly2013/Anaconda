using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerName = "Player";
    public int score = 0;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(Random.Range(100, 400), 0, Random.Range(100, 400));
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
        var x = Mathf.Log(score, 50);
        var z = Mathf.Log10(score);
        x = x < 1 ? 1 : x;
        z = z < 1 ? 1 : z;
        transform.localScale = new Vector3(x, 1, z);
    }
}
