﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTransform : MonoBehaviour
{
     private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    public bool dragging = false;
    private float distance;
    public bool onSlot = false;
    private bool isOnSlotArea = false;
    private bool getNewPosition = false;
    public bool preparingTime = true;
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }
 
   
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }
 
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        onSlot = false;
    }
 
    void OnMouseUp()
    {
        dragging = false;
        onSlot=true;
        if(!isOnSlotArea){
            transform.position = startPosition;

        }


    }
 
    void Update()
    {
        if (dragging && preparingTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            Vector3 tempTransform = transform.position;
            if(!onSlot){

            tempTransform.x =rayPoint.x;
            tempTransform.z =rayPoint.z;
            tempTransform.y = transform.position.y;
            transform.position = tempTransform;

            }
            
        }
    }
    
    private void OnTriggerStay(Collider other) {

        if(other.CompareTag("tile") && onSlot && preparingTime){
            print("colliding");
            Vector3 temptrans = transform.position;
            temptrans.x =  other.gameObject.transform.position.x;
            temptrans.z =  other.gameObject.transform.position.z;
            transform.position = temptrans;
        }
        if(other.CompareTag("slot") && onSlot && preparingTime){
            print("colliding");
            Vector3 temptrans = transform.position;
            temptrans.x =  other.gameObject.transform.position.x;
            temptrans.z =  other.gameObject.transform.position.z;
            transform.position = temptrans;
            // transform.position = other.gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("tile") && preparingTime){
            isOnSlotArea = true;
        }
        if(other.CompareTag("slot") && preparingTime){
            getNewPosition = true;
            isOnSlotArea = true;
        }
        if(other.CompareTag("slot") && preparingTime && getNewPosition)
        {
            Vector3 temptrans = transform.position;
            temptrans.x = other.gameObject.transform.position.x;
            temptrans.z = other.gameObject.transform.position.z;
            startPosition = temptrans;
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("tile")&& preparingTime){
            isOnSlotArea = false;
     
     if(other.CompareTag("slot")&& preparingTime){
                getNewPosition = false;
                isOnSlotArea = false;
        }   }
    }
}
 

