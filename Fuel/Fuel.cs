namespace FuelSpc
{
public class Fuel
{
    private double _fuel = 0;
    private double _fuel_consumption = 0;
     public void SetFuel(double fuel_volume)
    {
        _fuel = fuel_volume;
    }
     public void SetFuelConsumption(double consump)
    {
        _fuel_consumption = consump;
    }
    public bool FuelIs () 
    { 
       if (_fuel > _fuel_consumption) { return true; }
       else { return false; }
    }

    public double FuelBurn()
    {
        if (_fuel > _fuel_consumption)
        {
            double burn = _fuel - _fuel_consumption;
            return burn;
        }
        else
        {
            throw new System.Exception();
        }
    }

}

}