namespace spacebattle;

public class Spaceship
{
    private bool _canMove = false;
    private double[] _coords = new double[2];
    private double[] _speed = new double[2];
    public Spaceship(bool canMove)
    {
        _canMove = canMove;
    }

    public void SetCoords(double first_coord, double second_coord)
    {
        _coords[0] = first_coord;
        _coords[1] = second_coord;
    }
    public void SetSpeed(double first_speed, double second_speed)
    {
        _speed[0] = first_speed;
        _speed[1] = second_speed;
    }
    public void CanMove(bool canMove)
    {
        _canMove = canMove;
    }
    public double[] Move()
    {
        if (double.IsNaN(_coords[0]) || double.IsNaN(_coords[1]) || double.IsNaN(_speed[0]) || double.IsNaN(_speed[1]))
        {
            throw new System.Exception();
        }
        if (!_canMove)
        {
            throw new System.Exception();
        }
        else
        {
            _coords[0] += _speed[0];
            _coords[1] += _speed[1];
        }

        return _coords;
    }
}
