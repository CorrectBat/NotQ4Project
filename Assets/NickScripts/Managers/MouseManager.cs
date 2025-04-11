using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            OnClick();
        }

        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            OnRelease();
        }
    }

    void OnClick() {
        Vector3 mousePosition = GetMousePosition();

        if(!Physics2D.OverlapPoint(mousePosition)) {
            return;
        }

        Collider2D[] objects = Physics2D.OverlapPointAll(mousePosition);
        GameObject highest = GetHighestObject(objects);
        if(highest.TryGetComponent(out Clickable clickable)) {
            clickable.OnClick();
        }
    }

    void OnRelease() {
        Vector3 mousePosition = GetMousePosition();

        if(!Physics2D.OverlapPoint(mousePosition)) {
            return;
        }

        Collider2D[] objects = Physics2D.OverlapPointAll(mousePosition);
        GameObject highest = GetHighestObject(objects);
        if(highest.TryGetComponent(out Clickable clickable)) {
            clickable.OnRelease();
        }
    }

    Vector3 GetMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    GameObject GetHighestObject(Collider2D[] objectsClicked) {
        int highestSort = 0;
        Collider2D highestCollider = objectsClicked[0];
        
        foreach(Collider2D collider in objectsClicked) {
            Renderer renderer = collider.transform.GetComponent<Renderer>();

            if(renderer.sortingOrder > highestSort) {
                highestSort = renderer.sortingOrder;
                highestCollider = collider;
            }
        }

        return highestCollider.gameObject;
    }
}
