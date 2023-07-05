namespace SpinSpc
{
public class Spin
{
    private double _angle = 0;
    private double _angle_speed = 0;
    private bool _canSpin = true;
     public void SetAngle(double angle)
    {
        _angle = angle;
    }
     public void SetAngleSpeed(double angle_speed)
    {
        _angle_speed = angle_speed;
    }
     public void CanSpin(bool canSpin)
    {
        _canSpin = canSpin;
    }
    public double SpinAt()
    {
        if (double.IsNaN(_angle) || double.IsNaN(_angle_speed) || !_canSpin)
        {
            throw new System.Exception();
        }
        else
        {
            _angle += _angle_speed;
        }
        return _angle;
    }
}

}