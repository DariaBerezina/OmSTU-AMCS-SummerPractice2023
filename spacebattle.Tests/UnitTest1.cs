using TechTalk.SpecFlow;

namespace spacebattle.Tests;

[Binding]
public class Движение_космического_корабля
{
    private readonly ScenarioContext _scenarioContext;
    private Spaceship _spc = new Spaceship();
    private double[] _actual = new double[2];
    private double _actual_angle = 0;

    private static void Act() { }
    private static Action _act = () => Act();

    public Движение_космического_корабля(ScenarioContext scenarioContext)
    {
        _spc.fuel.SetFuel(100);
        _spc.fuel.SetFuelConsumption(1);

        _scenarioContext = scenarioContext;
    }

    // Тесты на проверку движения по прямой.

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void ДопустимКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(double p0, double p1)
    {
        _spc.SetCoords(p0, p1);
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void ДопустимИмеетМгновеннуюСкорость(double p0, double p1)
    {
        _spc.SetSpeed(p0, p1);
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void ДопустимКосмическийКорабльПоложениеВПространствеКоторогоНевозможноОпределить()
    {
        _spc.SetCoords(double.NaN, double.NaN);
    }

    [Given(@"скорость корабля определить невозможно")]
    public void ДопустимСкоростьКорабляОпределитьНевозможно()
    {
        _spc.SetSpeed(double.NaN, double.NaN);
    }

    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void ДопустимИзменитьПоложениеВПространствеКосмическогоКорабляНевозможно()
    {
        _spc.CanMove(false);
    }

    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void КогдаПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
    {
        try 
        {
            _actual = _spc.Move();
        }
        catch
        {
            _act = () => _spc.Move();
        }
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void ТоКосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(int p0, int p1)
    {
        double[] expected = {p0, p1};
        Assert.Equal(expected, _actual);
    }

    [Then(@"возникает ошибка Exception")]
    public void ТоВозникаетОшибкаException()
    {

        Assert.Throws<System.Exception>(_act);
    }

    // Тесты для топлива.

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void ДопустимКосмическийКорабльИмеетТопливоВОбъемеЕд(double p0)
    {
        _spc.fuel.SetFuel(p0);
    }
        
    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void ДопустимИмеетСкоростьРасходаТопливаПриДвиженииЕд(double p0)
    {
        _spc.fuel.SetFuelConsumption(p0);
    }
        
    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void ТоНовыйОбъемТопливаКосмическогоКорабляРавенЕд(double p0)
    {
        Assert.Equal(p0, _spc.fuel_volume);
    }

     // Тесты для вращения.

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void ДопустимКосмическийКорабльИмеетУголНаклонаГрадКОсиOX(double p0)
    {
        _spc.spin.SetAngle(p0);
    }
    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void ДопустимКосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
    {
        _spc.spin.SetAngle(double.NaN);
    }
        
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void ДопустимИмеетМгновеннуюУгловуюСкоростьГрад(double p0)
    {
        _spc.spin.SetAngleSpeed(p0);
    }
    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
    {
        _spc.spin.SetAngleSpeed(double.NaN);
    }

    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void ДопустимНевозможноИзменитьУголдНаклонаКОсиOXКосмическогоКорабля()
    {
        _spc.spin.CanSpin(false);
    }
        
    [When(@"происходит вращение вокруг собственной оси")]
    public void КогдаПроисходитВращениеВокругСобственнойОси()
    {
        try
        {
            _actual_angle = _spc.spin.SpinAt();
        }
        catch
        {
            _act = () => _spc.spin.SpinAt();
        }
    }
        
    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void ТоУголНаклонаКосмическогоКорабляКОсиOXСоставляетГрад(int p0)
    {
        Assert.Equal(p0, _actual_angle);
    }
}
