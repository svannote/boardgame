using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    //create gameobjects for player sprites and text on screen
    private static GameObject whoWinsText, player1MoveText, player2MoveText;
    public static GameObject buyButton;
    private static GameObject player1, player2;

    //create var for number rolled and what waypoint players are on
    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    //bool to identify if game has been won
    public static bool gameOver = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //associate gameobjects with text gameobjects in unity
        whoWinsText = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");
        buyButton = GameObject.Find("BuyButton");
        
        //associate gameobjects with player sprites in unity
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        //neither player can go until die is rolled
        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        
        //at start of game, it is player 1 turn, so should only see that player one can go
        whoWinsText.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //while both players 
        //if waypoint where player is at is greater than 
        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
            buyButton.gameObject.SetActive(true);
            
        }
        
        if (player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
            buyButton.gameObject.SetActive(true);
        }
        
        if (player1.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            whoWinsText.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
            
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
            
        }
        
        if (player2.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            whoWinsText.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
            
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
            
        }

        
    }
    
    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}
