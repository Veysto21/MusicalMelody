using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndDelegate(Draggable draggableObject);

    public DragEndDelegate dragEndedCallback;

    private bool _isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;


    private void OnMouseDown()
    {
        _isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if(_isDragged )
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        _isDragged = false;
        dragEndedCallback(this);
    }
}
