using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBird : MonoBehaviour
{
    // Object formation
    private Rigidbody2D physEffect;
    public GameObject welcome;
    public GameObject displayBird;
    public float jumpStep;
    private bool startGame;
    private int score;
    private int maxScore;
    public Text textScore;
    public Text finalGame;
    public Text highScore;
    public GameObject autoGame;
    public GameObject overGame;

    private void Awake()
    {
        physEffect = this.gameObject.GetComponent<Rigidbody2D>();
        startGame = false;
        physEffect.gravityScale = 0;
        score = 0;
        maxScore = 0;
        textScore.text = score.ToString();
        finalGame.GetComponent<SpriteRenderer>().enabled = false;
        highScore.GetComponent<SpriteRenderer>().enabled = false;
        welcome.GetComponent<SpriteRenderer>().enabled = true;
        displayBird.GetComponent<SpriteRenderer>().enabled = false;
        overGame.GetComponent<SpriteRenderer>().enabled = false;
        textScore.IsActive();
        // Return true if the GameObject and the Component are active.
    }

    // Bird start
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Audio.assign.playSound("wing", 1.5f);
            if (startGame == false)
            {
                startGame = true;
                physEffect.gravityScale = 2;
                welcome.GetComponent<SpriteRenderer>().enabled = false;
                displayBird.GetComponent<SpriteRenderer>().enabled = true;
                autoGame.GetComponent<AutoGame>().browserPipe = true;
                textScore.IsDestroyed();
                // Returns true if the native representation of the behaviour has been destroyed.
            }
            moveBird();
        }
    }
    private void moveBird()
    {
        physEffect.velocity = Vector2.up * jumpStep;
    }

    // Static collider
    // Collision && reset game
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.assign.playSound("hit", 1f);
        displayBird.GetComponent<SpriteRenderer>().enabled = false;
        overGame.GetComponent<SpriteRenderer>().enabled = true;
        finalGame.GetComponent<SpriteRenderer>().enabled = true;
        highScore.GetComponent<SpriteRenderer>().enabled = true;
        finalGame.text = score.ToString();
        if (score > maxScore)
        {
            maxScore = score;
            highScore.text = maxScore.ToString();
        }
        if (true)
        {
            if (Input.GetKeyDown((KeyCode.S)))
            {
                reloadScene();
            }
            // If you don't press 'S' after 5 seconds, reloadScene() will be called again.
            else Invoke("reloadScene", 5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Audio.assign.playSound("point", 1f);
        score++;
        textScore.text = score.ToString();
    }
    public void reloadScene()
    {
        SceneManager.LoadScene("_BackgroundGame");
        score = 0;
        textScore.text = score.ToString();
    }
}
