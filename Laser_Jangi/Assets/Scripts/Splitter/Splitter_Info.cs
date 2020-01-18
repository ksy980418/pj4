using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter_Info : MonoBehaviour {
    private RaycastHit hit;
    private LineRenderer line;
    private Ray ray;

    private Vector3 cur_direction;
    private Vector3 start_point;
    private Vector3 end_point;
    private int num;

    private Vector3 position;
    private float angle;
    private float half_size_x;
    private float half_size_y;

    private ArrayList splitters;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();

        line.useWorldSpace = true;

        line.SetWidth(5.0f, 5.0f);
        line.SetColors(Color.green, Color.green);
        
        BoxCollider temp = gameObject.GetComponent<BoxCollider>();
        position = transform.position;
        half_size_x = transform.localScale.x * (temp.size.x * 0.5f);
        half_size_y = transform.localScale.y * (temp.size.y * 0.5f);
        temp = null;

        splitters = new ArrayList();
    }

    public Vector3 reflect_point(Vector3 hit_pos, Vector3 cur_dir) {
        cur_direction = cur_dir;

        position = transform.position;
        angle = transform.rotation.eulerAngles.z;

        switch (angle)
        {
            case 0 :
            case 180 : {
                if (position.y + half_size_y + 0.001 >= hit_pos.y && hit_pos.y >= position.y + half_size_y - 0.001) {
                    start_point = new Vector3(hit_pos.x, position.y + hit_pos.x - position.x, 0);
                    return start_point;
                }
                else if (position.x - half_size_x + 0.001 >= hit_pos.x && hit_pos.x >= position.x - half_size_x - 0.001) {
                    start_point = new Vector3(position.x + hit_pos.y - position.y, hit_pos.y, 0);
                    return start_point;
                }
                else if (position.y - half_size_y + 0.001 >= hit_pos.y && hit_pos.y >= position.y - half_size_y - 0.001) {
                    start_point = new Vector3(hit_pos.x, position.y + hit_pos.x - position.x, 0);
                    return start_point;
                }
                else if (position.x + half_size_x + 0.001 >= hit_pos.x && hit_pos.x >= position.x + half_size_x - 0.001) {
                    start_point = new Vector3(position.x + hit_pos.y - position.y, hit_pos.y, 0);
                    return start_point;
                }
                else {
                    start_point = transform.position;
                    return start_point;
                }
                break;
            }
            case 90 :
            case 270 : {
                if (position.y + half_size_x + 0.001 >= hit_pos.y && hit_pos.y >= position.y + half_size_x - 0.001) {
                    start_point = new Vector3(hit_pos.x, position.y - hit_pos.x + position.x, 0);
                    return start_point;
                }
                else if (position.x - half_size_y + 0.001 >= hit_pos.x && hit_pos.x >= position.x - half_size_y - 0.001) {
                    start_point = new Vector3(position.x - hit_pos.y + position.y, hit_pos.y, 0);
                    return start_point;
                }
                else if (position.y - half_size_x + 0.001 >= hit_pos.y && hit_pos.y >= position.y - half_size_x - 0.001) {
                    start_point = new Vector3(hit_pos.x, position.y - hit_pos.x + position.x, 0);
                    return start_point;
                }
                else if (position.x + half_size_y + 0.001 >= hit_pos.x && hit_pos.x >= position.x + half_size_y - 0.001) {
                    start_point = new Vector3(position.x - hit_pos.y + position.y, hit_pos.y, 0);
                    return start_point;
                }
                else {
                    start_point = transform.position;
                    return start_point;
                }
                break;
            }
            default: {
                start_point = transform.position;
                return start_point;
            }
        }
    }

    public Vector3 reflect_direction(Vector3 hit_pos, bool make_laser) {
        if (make_laser) {
            laserOn();
        }
        switch (angle)
        {
            case 0 :
            case 180 : {
                if (position.y + half_size_y + 0.001 >= hit_pos.y && hit_pos.y >= position.y + half_size_y - 0.001) {
                    return new Vector3(-1.0f, 0, 0);
                }
                else if (position.x - half_size_x + 0.001 >= hit_pos.x && hit_pos.x >= position.x - half_size_x - 0.001) {
                    return new Vector3(0, 1.0f, 0);
                }
                else if (position.y - half_size_y + 0.001 >= hit_pos.y && hit_pos.y >= position.y - half_size_y - 0.001) {
                    return new Vector3(1.0f, 0, 0);
                }
                else if (position.x + half_size_x + 0.001 >= hit_pos.x && hit_pos.x >= position.x + half_size_x - 0.001) {
                    return new Vector3(0, -1.0f, 0);
                }
                else {
                    return Vector3.zero;
                }
                break;
            }
            case 90 :
            case 270 : {
                if (position.y + half_size_x + 0.001 >= hit_pos.y && hit_pos.y >= position.y + half_size_x - 0.001) {
                    return new Vector3(1.0f, 0, 0);
                }
                else if (position.x - half_size_y + 0.001 >= hit_pos.x && hit_pos.x >= position.x - half_size_y - 0.001) {
                    return new Vector3(0, -1.0f, 0);
                }
                else if (position.y - half_size_x + 0.001 >= hit_pos.y && hit_pos.y >= position.y - half_size_x - 0.001) {
                    return new Vector3(-1.0f, 0, 0);
                }
                else if (position.x + half_size_y + 0.001 >= hit_pos.x && hit_pos.x >= position.x + half_size_y - 0.001) {
                    return new Vector3(0, 1.0f, 0);
                }
                else {
                    return Vector3.zero;
                }
                break;
            }
            default: {
                return Vector3.zero;
            }
        }
    }

    private void laserOn() {
        line.enabled = true;
        splitters.Clear();
        splitters.Add(transform.position);
        num = 0;
        end_point = start_point + cur_direction*2000;

        ray = new Ray(start_point, cur_direction);
        line.positionCount = ++num;
        line.SetPosition(num-1, ray.origin);

        while (Physics.Raycast(start_point, cur_direction, out hit)) {
            if (hit.transform.gameObject.tag == "Nemo") {
                if (hit.transform.gameObject.GetComponent<Nemo_Info>().is_reflect(hit.point)) {
                    start_point = hit.point;
                    cur_direction = Vector3.Reflect(cur_direction, hit.normal);
                    ray = new Ray(start_point, cur_direction);

                    line.positionCount = ++num;
                    line.SetPosition(num-1, start_point);

                    end_point = start_point + cur_direction*2000;

                    //Debug.Log(hit.transform.gameObject.tag);
                }
                else {
                    end_point = hit.point;
                    break;
                }
            }
            else if (hit.transform.gameObject.tag == "Triangle") {
                if (hit.transform.gameObject.GetComponent<Triangle_Info>().is_reflect(hit.point)) {
                    start_point = hit.transform.gameObject.GetComponent<Triangle_Info>().reflect_point(hit.point);
                    
                    cur_direction = hit.transform.gameObject.GetComponent<Triangle_Info>().reflect_direction(hit.point);
                    
                    ray = new Ray(start_point, cur_direction);

                    line.positionCount = ++num;
                    line.SetPosition(num-1, start_point);

                    end_point = start_point + cur_direction*2000;

                    //Debug.Log(hit.transform.gameObject.tag);
                }
                else {
                    end_point = hit.point;
                    break;
                }
            }
            else if (hit.transform.gameObject.tag == "Splitter") {
                if (!splitters.Contains(hit.transform.position)) {
                    splitters.Add(hit.transform.position);

                    start_point = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_point(hit.point, cur_direction);
                            
                    cur_direction = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_direction(hit.point, true);
                    
                    ray = new Ray(start_point, cur_direction);

                    line.positionCount = ++num;
                    line.SetPosition(num-1, start_point);

                    end_point = start_point + cur_direction*2000;
                }
                else {
                    if (hit.transform.position == transform.position) {
                        start_point = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_point(hit.point, cur_direction);
                            
                        cur_direction = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_direction(hit.point, false);
                        
                        ray = new Ray(start_point, cur_direction);

                        line.positionCount = ++num;
                        line.SetPosition(num-1, start_point);

                        end_point = start_point + cur_direction*2000;
                    }
                    else {
                        start_point = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_point(hit.point, cur_direction);

                        ray = new Ray(start_point, cur_direction);

                        line.positionCount = ++num;
                        line.SetPosition(num-1, start_point);

                        end_point = start_point + cur_direction*2000;
                    }
                }
            }
            else if (hit.transform.gameObject.tag == "laser") {
                end_point = hit.point;
                //Debug.Log(hit.transform.gameObject.tag);
                break;
            }
            else if (hit.transform.gameObject.tag == "King") {
                end_point = hit.point;
                //Debug.Log(hit.transform.gameObject.tag);
                break;
            }
            else {
                start_point = hit.point;
                cur_direction = Vector3.Reflect(cur_direction, hit.normal);
                ray = new Ray(start_point, cur_direction);

                line.positionCount = ++num;
                line.SetPosition(num-1, start_point);

            
                end_point = start_point + cur_direction*2000;
            }
        }
        line.positionCount = ++num;
        line.SetPosition(num-1, end_point);
    }
}
