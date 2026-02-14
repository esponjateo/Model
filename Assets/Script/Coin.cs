using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Drag your Player object here in the Inspector
    [SerializeField] private GameObject objectToTouch;
    [SerializeField] private TextMeshProUGUI ScoreText;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the specific object that touched us is the one we dragged in
        if (other.gameObject == objectToTouch)
        {
            CollectCoin();
        }
    }

    // The X and Z limits for where the object can go.
    public float xRange = 4f;
    public float zRange = 4f;

    // Keep the Y position constant (e.g., if it's sitting on the ground)
    public float yHeight = 1.0f;


    public int TotalCoins = 0;


    private void Start()
    {
        UpdateUI();
    }


    private void CollectCoin()
    {
        TotalCoins++;
        UpdateUI();
        MoveToRandomPosition();
    }

    private void UpdateUI()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Coins: " + TotalCoins;
        }
    }




    void MoveToRandomPosition()
    {
        // 3. Calculate a new random position within the ranges
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);

        // 4. Apply the new position
        Vector3 newPosition = new Vector3(randomX, yHeight, randomZ);
        transform.position = newPosition;
    }




}