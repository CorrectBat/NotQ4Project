using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryItem : MonoBehaviour, Clickable
{
    private bool isHeld;
    private Vector3 offset;
    private Rigidbody2D rigidbody;
    [SerializeField] ItemNames itemType;
    private bool isStuck;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if(isHeld) {
            Drag();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            OnRelease();
        }
    }

    public ItemNames GetItem() {
        return itemType;
    }
    void Drag() {
        rigidbody.MovePosition(offset+Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnClick() {
        if(isStuck) {
            return;
        }
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.GetComponent<Rigidbody2D>().gravityScale = 0;
        isHeld = true;
        rigidbody.excludeLayers = LayerMask.GetMask("Shelf");
        rigidbody.includeLayers = LayerMask.GetMask("Line");
    }

    public void OnRelease() {
        if(isStuck) {
            return;
        }
        isHeld = false;
        transform.GetComponent<Rigidbody2D>().gravityScale = 1;
        rigidbody.includeLayers = LayerMask.GetMask("Shelf");
        rigidbody.excludeLayers = LayerMask.GetMask("Line");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Duck") {
            rigidbody.gravityScale = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            isStuck = true;
        }
    }
}
