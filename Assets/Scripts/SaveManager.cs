using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree;

public class SaveManager : MonoBehaviour
{

    public int testInt;
    public float testFloat;
    public string myTestString;
    public bool testBool;

    public Vector3 playersPositionOnExit;


    public void Save()
    {
        SaveGame.Save<bool>("TestBool", testBool);
        SaveGame.Save<int>("TestInt", testInt);
        SaveGame.Save<string>("MyTestString", myTestString);
        SaveGame.Save<float>("TestFloat", testFloat);

        SaveGame.Save<Vector3>("PlayerPositionOnExit", FindObjectOfType<LevelManager>().currentPlayerPosition);
    }

    public void Load()
    {
        testInt = SaveGame.Load<int>("TestInt");
        testFloat = SaveGame.Load<float>("TestFloat");
        myTestString = SaveGame.Load<string>("MyTestString");
        testBool = SaveGame.Load<bool>("testBool");

        playersPositionOnExit = SaveGame.Load<Vector3>("PlayerPositionOnExit");
    }
}



//public string loadTest;

//// Start is called before the first frame update
//void Start()
//{
//loadTest = SaveGame.Load<string>("LoadTest");


//}

//// Update is called once per frame
//void Update()
//{
//    if (Input.anyKeyDown)
//    {
//SaveGame.Save<string>("LoadTest", "Yes It Loaded");
//    }


//}
