using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraController : MonoBehaviour {

    private List<GameObject> players;
    private Camera cameraMain;

    void Start()
    {
        cameraMain = GetComponent<Camera>();
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        transform.position = new Vector3(AveragePlayersPostionX(), transform.position.y, transform.position.z);
        CalculateOrthographicSize();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(AveragePlayersPostionX(), transform.position.y, transform.position.z);
        CalculateOrthographicSize();
    }

    private float AveragePlayersPostionX()
    {
        return players.Average(p => p.transform.transform.position.x);
    }

    private void CalculateOrthographicSize()
    {
        cameraMain.orthographicSize = ((players.Max(p => p.transform.transform.position.x) + 1) - (players.Min(p => p.transform.transform.position.x) - 1)) / cameraMain.aspect / 2f;
        if (cameraMain.orthographicSize < 3) cameraMain.orthographicSize = 3;
    }
}
