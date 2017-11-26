using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.States;

public class GameManager : MonoBehaviour {


    public GameState CurrentGameState = GameState.Start;
    int CurrentBirthIndex = 0;
    public GameObject target;
    public float speed=1;

    private List<GameObject> Birds;

	// Use this for initialization
	void Start () {
        CurrentGameState = GameState.Start;
        Birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bird"));
        target= GameObject.FindGameObjectWithTag("BirthWatiPosition");
        
    }
	
	// Update is called once per frame
	void Update () {
     
        switch (CurrentGameState)
        {
            case GameState.Start:
                //if player taps, begin animating the bird 
                //to the slingshot
                if (Input.GetMouseButtonUp(0))
                {
                    AnimateBirdToSlingShot();
                }
                break;
            case GameState.BirdMovingToSlingshot:
                break;
            case GameState.Playing:
                break;
            case GameState.Won:
                break;
            case GameState.Lost:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Animates the bird from the waiting position to the slingshot
    /// </summary>
    void AnimateBirdToSlingShot()
    {
        CurrentGameState = GameState.BirdMovingToSlingshot;
        
        Birds[CurrentBirthIndex].transform.position = target.transform.position;
    }

   
    
}
