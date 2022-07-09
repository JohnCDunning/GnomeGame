using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;
    public Transform playerSpawn;
    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public GameObject playerPrefab;
    
    [HideInInspector]
    public CameraController cameraController;
    public GameObject cameraControllerPrefab;
    void Awake()
    {
        if (AppManager.Instance == null)
        {
            StartCoroutine(LoadMaster());
        }
        instance = this;
    }
    IEnumerator LoadMaster()
    {
        SceneManager.LoadScene("Master", LoadSceneMode.Additive);
        yield return new WaitUntil(()=> AppManager.Instance != null);
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        playerController = Instantiate(playerPrefab).GetComponent<PlayerController>();
        playerController.transform.SetPositionAndRotation(playerSpawn.position,playerSpawn.rotation);

        cameraController = Instantiate(cameraControllerPrefab).GetComponent<CameraController>();
        cameraController.playerController = playerController;
        playerController.CameraController = cameraController;
    }
}
