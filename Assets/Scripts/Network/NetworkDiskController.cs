using UnityEngine;
using UnityEngine.Networking;

public class NetworkDiskController : NetworkBehaviour {

    public int score;
    public float scale;
    public Color color;

    private Color[] colors = { Color.red, Color.yellow, Color.blue, Color.green, Color.black, Color.white, Color.cyan, Color.magenta };

    void Start () {
        transform.SetParent(GameObject.Find("Disks").transform);
        var rvalue = Random.value;
        if (rvalue > 0.93)
        {
            score = 16;
            scale = 1.5f;
        }
        else if (rvalue > 0.8)
        {
            score = 8;
            scale = 1.3f;
        }
        else if (rvalue > 0.6)
        {
            score = 4;
            scale = 1.1f;
        }
        else if (rvalue > 0.3)
        {
            score = 2;
            scale = 1;
        }
        else
        {
            score = 1;
            scale = 0.8f;
        }
        transform.localScale = new Vector3(scale, scale, scale);
        color = colors[(int)Random.Range(0, colors.Length - 1)];
        color.a = 0.7f;
        GetComponent<MeshRenderer>().material.color = color;
    }


}
