using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class Slider : MonoBehaviour
{
    private SliderJoint2D SliderJoint;
    private JointMotor2D motorSlider;

    private float timeToChange;
    private float maxMotorSpeed;

    
    void Start()
    {
        SliderJoint = GetComponent<SliderJoint2D>();
        motorSlider = SliderJoint.motor;
        maxMotorSpeed = motorSlider.motorSpeed;
        timeToChange = Random.Range(2, 5);
        InvokeRepeating(nameof(ChangeDirection), timeToChange, timeToChange);
    }

    private void ChangeDirection()
    {
        motorSlider.motorSpeed *= -1;
        SliderJoint.motor = motorSlider;
    }
}
