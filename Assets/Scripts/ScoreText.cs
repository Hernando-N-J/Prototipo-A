using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score" + "\n" + TappyBirdGameManager.Instance.Score.ToString();
    }

}
