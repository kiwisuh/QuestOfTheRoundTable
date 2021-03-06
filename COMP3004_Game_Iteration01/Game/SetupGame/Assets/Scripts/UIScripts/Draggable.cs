﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector2 dragOffset = new Vector2(0f, 0f);
	public Transform parentToReturnTo;

	public void OnBeginDrag(PointerEventData eventData)    {
		Debug.Log ("here");
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		dragOffset = eventData.position - (Vector2)this.transform.localPosition;

		this.GetComponent<BoxCollider2D> ().enabled = false;
		this.GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
		this.transform.localPosition = eventData.position - dragOffset;

	}

	public void OnEndDrag(PointerEventData eventData) {
		this.transform.SetParent (parentToReturnTo);
		this.GetComponent<BoxCollider2D> ().enabled = true;
		this.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
	public string test(){
		return "asadsfafsdafddfaaffa";
	}

}
