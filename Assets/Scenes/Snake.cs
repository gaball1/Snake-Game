using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public Text scoreText; 
    private int score = 0;
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 8;
    public GameOver gameOver;
    public Win win;


    private Coin coinManager; 

    private void Start()
    {
        coinManager = FindObjectOfType<Coin>(); 
        score = 0;
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);


        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
       
       
        scoreText.text = "Score: " + score;


    }

    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        AddScore(1);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Grow(); 
            coinManager.RemoveCoin(other.gameObject); 

            if (coinManager.TotalCoins == 0) 
            {

                    win.ShowWin();
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver.ShowGameOver();

        }
    }
    public void AddScore(int value)
    {
        score += value;
    }
 
}
