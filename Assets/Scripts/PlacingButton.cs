using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlacingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject myPlacedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GreyOut()
    {
        GetComponent<Button>().enabled = false;
        GetComponent<EventTrigger>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().color = Color.grey;
    }

    public void PickUp()
    {
        MousePlacementController.instance.PickUpObject(myPlacedObject, gameObject);
    }

    public void Place()
    {
        MousePlacementController.instance.PlaceObject();
    }
}
