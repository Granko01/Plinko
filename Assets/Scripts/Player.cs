using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 15f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;
    private bool isJumping = false;

    public int score;
    private float highestY;

    public int currentLevel = 1;
    public int scoreTarget = 0;
    public int targetIncrement = 1500;
    public Text Coins;
    public GameObject WinUi;
    public GameObject LostUi;
    public GameObject MenuGM;

    public Text[] scoreText;
    public Text levelText;

    public Transform platformContainer;
    private float containerStartY;

    public bool StartScore = false;
    public LevelManager levelmanager;
    public CoinsManager coinsmanager;

    void Start()
    {
        if (levelmanager.Level == 0)
        {
            scoreTarget = 1000;
        }
        else if (levelmanager.Level == 1)
        {
            scoreTarget = 2000;
        }
        else if (levelmanager.Level >= 2)
        {
            scoreTarget = 5000;
        }
        Coins.text = coinsmanager.Coins.ToString();
        rb = GetComponent<Rigidbody2D>();
        highestY = transform.position.y;
        UpdateUI();
        containerStartY = platformContainer.position.y;
    }

    void Update()
    {
        scoreText[1].text = score.ToString();
        HandleBetterJump();
        if (StartScore == true)
        {
            CheckHeightForScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StartScore")
        {
            StartScore = true;
            Debug.Log("starting");
        }
        if (collision.tag == "Broken")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Coins")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Lose")
        {
            LostUi.gameObject.SetActive(true);
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            // Random direction: -1 (left) or +1 (right)
            int horizontalDir = Random.value < 0.5f ? -1 : 1;

            // Horizontal force value — tweak this!
            float horizontalForce = 30f;

            // Apply jump with horizontal offset
            rb.velocity = new Vector2(horizontalDir * horizontalForce, jumpForce);
            isJumping = true;
        }
    }

    void HandleBetterJump()
    {
        if (rb.velocity.y < 0)
        {
            // falling down
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // short hop
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckHeightForScore()
    {
        float distanceMoved = containerStartY - platformContainer.position.y;

        score = Mathf.FloorToInt(distanceMoved * 0.1f);
        UpdateUI();
        CheckLevelProgress();
    }
    private bool hasWon = false;
    void CheckLevelProgress()
    {
        if (score == scoreTarget && !hasWon)
        {
            hasWon = true;
            WinUi.gameObject.SetActive(true);
            coinsmanager.Score += 1000;
            coinsmanager.SaveScore();
            coinsmanager.UpdateAllTexts(coinsmanager.ScoreText, coinsmanager.Score);
            levelmanager.Level++;
            levelmanager.SaveLevel();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SeaGameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("SeaMainMenu");
    }

    public void MenuM()
    {
        bool isActive = MenuGM.activeSelf;

        if (MenuGM.activeSelf)
        {
            MenuGM.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            MenuGM.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText[0].text = "Score: " + score;

        if (levelText != null)
            levelText.text = "Level: " + currentLevel;
    }

    bool IsGrounded()
    {
        return true; 
    }
}
