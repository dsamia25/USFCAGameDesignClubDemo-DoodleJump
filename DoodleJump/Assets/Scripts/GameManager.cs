using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static bool m_GameIsRunning = true;   // Static bool that indicates that the game is running.
    public static bool gameIsRunning { get => m_GameIsRunning; }    // Public variable for other classes to see if the game is running.

    [SerializeField] private int m_MapWidth = 5;    // The width of the map in platforms.
    [SerializeField] private int m_GapBetweenRows = 3;  // The amount of space between rows.
    [SerializeField] private int m_PlatfromsPerRow = 2; // The amount of platforms per row.
    [SerializeField] private int m_AmountOfRows = 10;   // The amount of rows to generate.

    [SerializeField] private GameObject m_PlatformPrefab;   // The prefab of the platform object to generate the map with.

    [Header("Events")]
    [Space]

    public UnityEvent OnPlayerDeath;

    // **************************************************
    // Start
    // **************************************************

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < m_AmountOfRows; i++)
        {
            GeneratePlatformRow(m_MapWidth, i * m_GapBetweenRows, m_PlatfromsPerRow);
        }
    }

    // **************************************************
    // Update
    // **************************************************

    // Update is called once per frame
    private void Update()
    {
        
    }

    // **************************************************
    // Methods
    // **************************************************

    /// <summary>
    /// Generates a single row of platforms. Spawns platformCount number of platforms within a space of rowWdith wide.
    /// rowNumber is the height of the rows.
    /// </summary>
    /// <param name="rowWidth"></param>
    /// <param name="rowNumber"></param>
    /// <param name="platformCount"></param>
    private void GeneratePlatformRow(int rowWidth, int rowNumber, int platformCount)
    {
        int[] platformSlots = new int[platformCount];   // An array of all the positions to spawn a platform at.

        // Generate random positions to spawn the platforms at.
        int i = 0;
        while (i < platformCount)
        {
            int random = Mathf.FloorToInt(Random.Range(0, rowWidth));

            // Check if the random number is already in the list.
            int j = 0;
            while (j < i)
            {
                if (platformSlots[j] == random)
                {
                    // If the number already existed then make a new one and look again
                    random = Mathf.FloorToInt(Random.Range(0, rowWidth));
                    j = 0;
                }
                else
                {
                    j++;
                }
            }

            platformSlots[i++] = random;
            Debug.Log("num = " + random);
        }

        Debug.Log(platformSlots.ToString());

        // Spawn a platform at each of the positions
        for (i = 0; i < platformCount; i++)
        {
            // Uses the randomly generated numbers from platformSlots as the x value and the rowNumber as the y value of the platforms.
            Instantiate(m_PlatformPrefab, new Vector2(platformSlots[i], rowNumber + m_GapBetweenRows), Quaternion.identity);
        }
    }
}
