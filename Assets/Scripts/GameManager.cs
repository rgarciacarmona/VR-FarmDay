using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PianoActivity piano_activity;
    public OrchardActivity orchard_activity;
    public GardenActivity garden_activity;
    public ScareCrowActivity scarecrow_activity;
    public AnimalActivity animal_activity;
    public CleanActivity clean_activity;
    public DrinkActivity drink_activity;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

///<summary>
///Manage start of activities
///</summary>
    public void StartActivity(string activity)
    {
        switch (activity)
        {
            case "entrance":
                break;
            case "piano":
                piano_activity.StartAgain();
                break;
            case "garden":
                garden_activity.StartAgain();
                break;
            case "lunch":
                drink_activity.StartAgain();
                break;
            case "orchard":
                orchard_activity.StartAgain();
                break;
            case "scarecrow":
                scarecrow_activity.StartAgain();
                break;
            case "animals":
                animal_activity.StartAgain();
                break;
            case "clean":
                clean_activity.StartAgain();
                break;
            default:
                break;
        }
  }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartActivity("scarecrow");
            Debug.Log("Se ha puulsado A");
        }
    }
}
