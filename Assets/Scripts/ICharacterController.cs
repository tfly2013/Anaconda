using UnityEngine;

public interface ICharacterController {
    int Score
    {
        get;
    }
    Color Color
    {
        get;
    }
    void AddScore(int amount);

}
