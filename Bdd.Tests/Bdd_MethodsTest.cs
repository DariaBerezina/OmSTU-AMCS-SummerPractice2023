using SquareEquationLib;
using TechTalk.SpecFlow;

namespace Bdd.Tests
{
    [Binding]
    public class Решение_Квадратного_Уравнения
    {
        private readonly ScenarioContext _scenarioContext;
        public Решение_Квадратного_Уравнения(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        private static void Act() { }

        private double _a;
        private double _b;
        private double _c;
        private double[] _actual = new double[2];
        private static Action _act = () => Act();

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентами(double p0, double p1, double p2)
        {
            _a = p0;
            _b = p1;
            _c = p2;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN1(double p0, double p1)
        {
            _a = double.NaN;
            _b = p0;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN2(double p0, double p1)
        {
            _a = p0;
            _b = double.NaN;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN3(double p0, double p1)
        {
            _a = p0;
            _b = p1;
            _c = double.NaN;
        }
        [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity1(int p0, int p1)
        {
            _a = double.NegativeInfinity;
            _b = p0;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity2(int p0, int p1)
        {
            _a = p0;
            _b = double.NegativeInfinity;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity3(int p0, int p1)
        {
            _a = p0;
            _b = p1;
            _c = double.NegativeInfinity;
        }
        [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity1(int p0, int p1)
        {
            _a = double.PositiveInfinity;
            _b = p0;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity2(int p0, int p1)
        {
            _a = p0;
            _b = double.PositiveInfinity;
            _c = p1;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity3(int p0, int p1)
        {
            _a = p0;
            _b = p1;
            _c = double.PositiveInfinity;
        }
        [When(@"вычисляются корни квадратного уравнения")]
        public void вычисляются_корни_квадратного_уравнения()
        {
            try
            {
                _actual = SquareEquation.Solve(_a, _b, _c);

            }
            catch
            {
                Action act = () => SquareEquation.Solve(_a, _b, _c);
                _act = act;
            }

        }
        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double p0, double p1)
        {
            double[] expected = { p0, p1 };
            Array.Sort(expected);
            Array.Sort(_actual);
            Assert.Equal(expected, _actual);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва(double p0)
        {
            double[] expected = { p0 };
            Assert.Equal(expected, _actual);
        }

        [Then(@"множество корней квадратного уравнения пустое")]
        public void ТоМножествоКорнейКвадратногоУравненияПустое()
        {
            double[] expected = { };
            Assert.Equal(expected, _actual);
        }

        [Then(@"выбрасывается исключение ArgumentException")]
        public void ТоВыбрасываетсяИсключениеArgumentException()
        {
            Assert.Throws<System.ArgumentException>(_act);
        }


    }
}
