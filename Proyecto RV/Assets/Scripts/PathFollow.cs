using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public static PathFollow instance;

    public GameObject player;
    public float speed;
    private int currentCheckpoint;
    private int pathFollowing;
    public int actualMarker;
    private bool isMoving;
    public List<PathPropio> paths = new List<PathPropio>();
    public List<VirtualMarker> virtualMarkers = new List<VirtualMarker>();
    public List<InteractableObject> interactableObjects = new List<InteractableObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        actualMarker = -1;
    }

    // Update is called once per frame
    void Update()
    {

        //Seguimiento de caminos.
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

                    foreach (VirtualMarker vm in virtualMarkers)
                    {
                        if (vm.isSphere)
                            vm.gameObject.SetActive(false);
                        else
                            vm.collider.enabled = false;
                    }

                    foreach (int vm in virtualMarkers[actualMarker].marcadoresAlrededor)
                    {
                        virtualMarkers[vm].gameObject.SetActive(true);

                        if (!virtualMarkers[vm].isSphere)
                            virtualMarkers[vm].collider.enabled = true;

                    }

                    if (virtualMarkers[actualMarker].isSphere)
                    {
                        virtualMarkers[actualMarker].gameObject.SetActive(false);
                    } else
                    {
                        virtualMarkers[actualMarker].collider.enabled = false;
                    }

                    //Interactable Objects
                    foreach (InteractableObject io in interactableObjects)
                    {
                        if (io != null)
                            io.collider.enabled = false;
                    }

                    if (PublicVariables.instance.level == 1)
                    {
                        if (actualMarker == 1)
                        {
                            if (interactableObjects[0] != null)
                                interactableObjects[0].collider.enabled = true;
                        }
                        else if (actualMarker == 5)
                        {
                            if (interactableObjects[1] != null)
                                interactableObjects[1].collider.enabled = true;
                        }
                        else if (actualMarker == 8)
                        {
                            if (interactableObjects[2] != null)
                                interactableObjects[2].collider.enabled = true;
                            if (interactableObjects[3] != null)
                                interactableObjects[3].collider.enabled = true;
                        }
                        else if (actualMarker == 11)
                        {
                            if (interactableObjects[4] != null)
                                interactableObjects[4].collider.enabled = true;
                        }
                    }
                    
                }
            }

        }
    }

    public void GoToMarker(int id)
    {
        if (PublicVariables.instance.level == 1)
        {
            switch (id)
            {
                case 0:
                    if (actualMarker == -1)
                    {
                        FollowPath(0);
                    }
                    else if (actualMarker == 1)
                    {
                        FollowPath(2);
                    }
                    else if (actualMarker == 2)
                    {
                        FollowPath(5);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 1:
                    if (actualMarker == 0)
                    {
                        FollowPath(1);
                        if (interactableObjects[0] != null)
                            interactableObjects[0].collider.enabled = true;
                    }
                    else if (actualMarker == 2)
                    {
                        FollowPath(6);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 2:
                    if (actualMarker == 0)
                    {
                        FollowPath(3);
                    }
                    else if (actualMarker == 1)
                    {
                        FollowPath(4);
                    }
                    else if (actualMarker == 3)
                    {
                        FollowPath(8);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 3:
                    if (actualMarker == 2)
                    {
                        FollowPath(7);
                    }
                    else if (actualMarker == 4)
                    {
                        FollowPath(10);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 4:
                    if (actualMarker == 3)
                    {
                        FollowPath(9);
                    }
                    else if (actualMarker == 5)
                    {
                        FollowPath(12);
                    }
                    else if (actualMarker == 6)
                    {
                        FollowPath(15);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 5:
                    if (actualMarker == 4)
                    {
                        FollowPath(11);
                        if (interactableObjects[1] != null)
                            interactableObjects[1].collider.enabled = true;
                    }
                    else if (actualMarker == 6)
                    {
                        FollowPath(16);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 6:
                    if (actualMarker == 4)
                    {
                        FollowPath(13);
                    }
                    else if (actualMarker == 5)
                    {
                        FollowPath(14);
                    }
                    else if (actualMarker == 7)
                    {
                        FollowPath(18);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 7:
                    if (actualMarker == 6)
                    {
                        FollowPath(17);
                    }
                    else if (actualMarker == 8)
                    {
                        FollowPath(20);
                    }
                    else if (actualMarker == 9)
                    {
                        FollowPath(22);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 8:
                    if (actualMarker == 7)
                    {
                        FollowPath(19);
                        if (interactableObjects[2] != null)
                            interactableObjects[2].collider.enabled = true;
                        if (interactableObjects[3] != null)
                            interactableObjects[3].collider.enabled = true;
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 9:
                    if (actualMarker == 7)
                    {
                        FollowPath(21);
                    }
                    else if (actualMarker == 10)
                    {
                        FollowPath(24);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 10:
                    if (actualMarker == 9)
                    {
                        FollowPath(23);
                    }
                    else if (actualMarker == 11)
                    {
                        FollowPath(26);
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
                case 11:
                    if (actualMarker == 10)
                    {
                        FollowPath(25);
                        if (interactableObjects[4] != null)
                            interactableObjects[4].collider.enabled = true;
                    }
                    else
                    {
                        Debug.LogWarning("Esto no debería pasar, AM: " + actualMarker + ", id: " + id);
                    }
                    break;
            }
        }

        actualMarker = id;

        if (virtualMarkers[id].isSphere)
            virtualMarkers[id].gameObject.SetActive(false);
        else
            virtualMarkers[id].collider.enabled = false;
    }

    public void FollowPath(int id)
    {
        pathFollowing = id;
        currentCheckpoint = 0;
        isMoving = true;
        Debug.Log("Path [" + id + "]");
    }
}
