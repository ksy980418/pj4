using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_info : MonoBehaviour {
    private RaycastHit hit;
    private LineRenderer line;
    private Ray ray;

    private float half_size_y;

    public bool laser_on;

    private Vector3 cur_direction;
    private Vector3 start_point;
    private Vector3 end_point;
    private int num;

    private ArrayList splitters;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();

        line.useWorldSpace = true;

        line.SetWidth(5.0f, 5.0f);
        line.SetColors(Color.green, Color.green);

        laser_on = true;

        splitters = new ArrayList();
        
        BoxCollider temp = gameObject.GetComponent<BoxCollider>();
        half_size_y = transform.localScale.y * (temp.size.y * 0.5f);
        temp = null;
    }


    void Update() {
        if (laser_on) {
            line.enabled = true;
            splitters.Clear();
            num = 0;
            cur_direction = transform.up;
            start_point = transform.position; //+ Vector3.up*half_size_y;
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

                        Debug.Log(hit.transform.gameObject.tag);
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
                        start_point = hit.transform.gameObject.GetComponent<Splitter_Info>().reflect_point(hit.point, cur_direction);

                        ray = new Ray(start_point, cur_direction);

                        line.positionCount = ++num;
                        line.SetPosition(num-1, start_point);

                        end_point = start_point + cur_direction*2000;
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
        else {
            line.enabled = false;
        }
    }
}
