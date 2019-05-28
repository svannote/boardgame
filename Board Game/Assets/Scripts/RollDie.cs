using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDie : MonoBehaviour
{

    //create array to hold images for die 
    private Sprite[] diceSides;
    //renderer to display images
    private SpriteRenderer rend;
    //var to track who's turn (player1 or player2)
    private int whosTurn = 1;
    //bool to start/stop coroutine
    private bool coroutineAllowed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //to render die, load images from folder "DiceSides" in folder "Resources" in Assets of game, add to array
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    //when die clicked, if coroutine true and gameOver (from GameControl class) false, begin ienumerator to roll die
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        //create animation by showing random images from diceSides array 20 times at 0.05 sec each
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        
        //set var diceSideThrown (from GameControl class) to number animation finishes on, add 1 bc array is 0-5
        //this is number of spaces player moves
        GameControl.diceSideThrown = randomDiceSide + 1;
        
        //identify which player to move
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
            
        }

        else
        {
            GameControl.MovePlayer(2);
        }

        //change who goes next by mult by -1, see above
        whosTurn *= -1;
        coroutineAllowed = true;
    }

}
