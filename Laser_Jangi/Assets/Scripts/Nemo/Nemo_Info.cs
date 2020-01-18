using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemo_Info : MonoBehaviour
{
    private Vector3 position;
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
        float angle = transform.rotation.eulerAngles.z;
        
        switch (angle)
        {
            case 0 : {
                if (position.y + y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y + y_half_size - 0.001) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 90 :{
                if (position.x - y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x - y_half_size - 0.001) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 180 :{
                if (position.y - y_half_size + 0.001 >= hit_pos.y && hit_pos.y >= position.y - y_half_size - 0.001) {
                    return true;
                }
                else {
                    return false;
                }
                break;
            }
            case 270 : {
                if (position.x + y_half_size + 0.001 >= hit_pos.x && hit_pos.x >= position.x + y_half_size - 0.001) {
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
}
