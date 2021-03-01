﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTransform : MonoBehaviour
{
     private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    public bool onSlot = false;
    private bool isOnSlotArea = false;
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
            transform.position = tempTransform;
            }
            
        }
    }
    
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("tile") && onSlot && preparingTime){
            print("colliding");
            transform.position = other.gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("tile") && preparingTime){
            isOnSlotArea = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("tile")&& preparingTime){
            isOnSlotArea = false;
        }
    }
}
 
