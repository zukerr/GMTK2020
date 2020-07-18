using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlacementController : MonoBehaviour
{
    private bool pickedUp = false;
    private GameObject airObject;
    private GameObject airButton;

    [SerializeField]
    private GameObject ghostObjectPrefab = null;

    private GameObject ghostObj;

    public static MousePlacementController instance = null;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(ghostObj != null)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0f;
            ghostObj.transform.position = worldMousePos;
        }
        if(pickedUp)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlaceObject();
            }
        }
    }

    public void PickUpObject(GameObject obj, GameObject btn)
    {
        pickedUp = true;
        airObject = obj;
        airButton = btn;
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0f;
        ghostObj = Instantiate(ghostObjectPrefab, worldMousePos, obj.transform.rotation);
        ghostObj.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
    }

    public void PlaceObject()
    {
        Destroy(ghostObj);
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0f;
        Instantiate(airObject, worldMousePos, airObject.transform.rotation);
        pickedUp = false;
        airObject = null;
        airButton.GetComponent<PlacingButton>().GreyOut();
        airButton = null;
        AudioManager.instance.PlayRandomSquashSound();
    }
}
