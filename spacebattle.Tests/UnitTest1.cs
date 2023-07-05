using spacebattle;
using TechTalk.SpecFlow;

namespace spacebattle.Tests;

[Binding]
public class Движение_космического_корабля
{
    private readonly ScenarioContext _scenarioContext;
    private Spaceship _spc = new Spaceship(true);
    private double[] _actual = new double[2];

    private static void Act() { }
    private static Action _act = () => Act();

    public Движение_космического_корабля(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

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
}