using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_Info : MonoBehaviour
{
    private Vector3 position;
    private float angle;
    private float x_half_size;
    private float y_half_size;

    void Start() {
        position = transform.position;

        BoxCollider temp = gameObject.GetComponent<BoxCollider>();
        x_half_size = transform.localScale.x * (temp.size.x * 0.5f);
        y_half_size = transform.localScale.y * (temp.size.y * 0.5f);
        temp = null;
    }

    public bool is_reflect(Vector3 hit_pos) {
        position = transform.position;
        angle = transform.rotation.eulerAngles.z;
        
        switch (angle)
        {
            case 0 : {
                if ((position.y + y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y + y_half_size - 0.001)
                || (position.x - x_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x - x_half_size - 0.001)) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 90 :{
                if ((position.x - y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x - y_half_size - 0.001)
                || (position.y - x_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y - x_half_size - 0.001)) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 180 :{
                if ((position.y - y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y - y_half_size - 0.001)
                || (position.x + x_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x + x_half_size - 0.001)) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 270 : {
                if ((position.x + y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x + y_half_size - 0.001)
                || (position.y + x_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y + x_half_size - 0.001)) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }       
            default: {
                return false;
                break;
            }
        }
    }

    public Vector3 reflect_point(Vector3 hit_pos) {
        switch (angle)
        {
            case 0 : {
                if (position.y + y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y + y_half_size - 0.001) {
                    return new Vector3(hit_pos.x, position.y + hit_pos.x - position.x, 0);
                }
                else {
                    return new Vector3(position.x + hit_pos.y - position.y, hit_pos.y, 0);
                }
                break;
            }
            case 90 :{
                if (position.x - y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x - y_half_size - 0.001) {
                    return new Vector3(position.x - hit_pos.y + position.y, hit_pos.y, 0);
                }
                else {
                    return new Vector3(hit_pos.x, position.y - hit_pos.x + position.x, 0);
                }
                break;
            }
            case 180 :{
                if (position.y - y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y - y_half_size - 0.001) {
                    return new Vector3(hit_pos.x, position.y + hit_pos.x - position.x, 0);
                }
                else {
                    return new Vector3(position.x + hit_pos.y - position.y, hit_pos.y, 0);
                }
                break;
            }
            case 270 : {
                if (position.x + y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x + y_half_size - 0.001) {
                    return new Vector3(position.x - hit_pos.y + position.y, hit_pos.y, 0);
                }
                else {
                    return new Vector3(hit_pos.x, position.y - hit_pos.x + position.x, 0);
                }
                break;
            }
            default : {
                return transform.position;
            }
        }
    }

    public Vector3 reflect_direction(Vector3 hit_pos) {
        switch (angle)
        {
            case 0 : {
                if (hit_pos.y >= position.y + y_half_size) {
                    return new Vector3(-1.0f, 0, 0);
                }
                else {
                    return new Vector3(0, 1.0f, 0);
                }
                break;
            }
            case 90 :{
                if (hit_pos.x <= position.x - y_half_size) {
                    return new Vector3(0, -1.0f, 0);
                }
                else {
                    return new Vector3(-1.0f, 0, 0);
                }
                break;
            }
            case 180 :{
                if (hit_pos.y <= position.y - y_half_size) {
                    return new Vector3(1.0f, 0, 0);
                }
                else {
                    return new Vector3(0, -1.0f, 0);
                }
                break;
            }
            case 270 : {
                if (hit_pos.x >= position.x + y_half_size) {
                    return new Vector3(0, 1.0f, 0);
                }
                else {
                    return new Vector3(1.0f, 0, 0);
                }
                break;
            }
            default : {
                return Vector3.zero;
            }
        }
    }
}
