using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private int currentCheckpoint;
    private int pathFollowing;
    private bool isMoving;
    public List<PathPropio> paths = new List<PathPropio>();
    public List<VirtualMarker> virtualMarkers = new List<VirtualMarker>();

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (player.transform.position.x != paths[pathFollowing].checkpoints[currentCheckpoint].position.x ||
                player.transform.position.z != paths[pathFollowing].checkpoints[currentCheckpoint].position.z)
            {
                Vector3 pos = Vector3.MoveTowards(player.transform.position, paths[pathFollowing].checkpoints[currentCheckpoint].position, speed * Time.deltaTime);
                player.GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                currentCheckpoint++;
                if (currentCheckpoint >= paths[pathFollowing].checkpoints.Count)
                {
                    isMoving = false;

                    foreach (int vm in virtualMarkers[pathFollowing].marcadoresAlrededor)
                    {
                        virtualMarkers[vm].gameObject.SetActive(true);
                    }
                    virtualMarkers[pathFollowing].gameObject.SetActive(false);
                }
            }
            
        }
    }

    public void GoToMarker(int id)
    {
        virtualMarkers[id].gameObject.SetActive(false);
        pathFollowing = id;
        currentCheckpoint = 0;
        isMoving = true;
        Debug.Log("Path [" + id + "]");
    }

    public void showText(string st)
    {
        Debug.Log("Texto: " + st);
    }
}
