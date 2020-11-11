using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //TODO create poinnts of refs for other managers
    //colelction of checkpoints that spawn the player at the current point
    [Header("Player Info")]
    public GameObject playerPrefab;
    public GameObject currentPlayerObject;
    public Vector3 currentPlayerPosition;

    [Header("Systems")]
    public AudioManager audioManager;
    public SaveManager saveManager;

    [Header("Level Params")]
    public Transform initSpawnPoint;

    private void Awake()
    {
        InitializeLevelManager();
    }

    private void Update()
    {
        if (currentPlayerObject)
        {
            currentPlayerPosition = currentPlayerObject.transform.position;
        }
        
    }


    //Here we are getting all of our scene refs
    public void InitializeLevelManager()
    {

        audioManager = GetComponentInChildren<AudioManager>();
        saveManager = GetComponentInChildren<SaveManager>();

        LoadGame();

        //what ever position the player left at is our init position on play
        initSpawnPoint.position = saveManager.playersPositionOnExit;

        SpawnPlayer(initSpawnPoint.position);

        Debug.Log("Init Spawn Manager");

        
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        //spawn the player at xyz of spawnPoint
        currentPlayerObject = Instantiate(playerPrefab, spawnPoint, Quaternion.identity, null);
        Debug.Log("Spawn Player");
        
    }

    public void SaveGame()
    {
        //call the save features of the save manager
        saveManager.Save();
    }

    public void LoadGame()
    {
        saveManager.Load();
    }

    public void PlaySound(AudioClip clip)
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

}
