using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace FunctionGraph
{
    public class DrawGraph
    {



        public override void AddValue(double value)
        {
            // Получаем все значения которые уже есть в графике.
            List listValues = ChartBackground.Children.OfType().Select(p => (double)p.Tag).ToList();

            // Вычисляем новую длину отрезка ломаной линии, чтобы график поместился 
            // полностью на ширину поля.
            double lengthSectionLine = listValues.Count > 0 ? WidthChart / listValues.Count : WidthChart;

            // Добавляем новое значение в график.
            listValues.Add(value);

            // Для ограничения высоты графика, вне зависимости от абсолютных значений,
            // вычислим общий знаменатель. И самое большое значение будет на максимальной
            // допустимой высоте. остальные пропорционально ниже.
            double maxValue = listValues.Max();
            double denominator = maxValue / HeightChart;

            // Удалим текущие элементы графика.
            Clear();

            // Инициализация новой ломаной линии.
            Polyline _polyline = new();
            _polyline.Stroke = Brushes.BlueViolet;
            _polyline.StrokeThickness = _lineThickness;
            _polyline.StrokeDashCap = PenLineCap.Flat;
            _polyline.StrokeLineJoin = PenLineJoin.Round;
            _polyline.HorizontalAlignment = HorizontalAlignment.Left;
            ChartBackground.Children.Add(_polyline);


            // Создание графика по текущим абсолютным значениям.
            // Абсолютные значения сохраняются в свойствах Ellipse.Tag
            foreach (double val in listValues)
            {
                // Счётчик добавленных в график узловых точек.
                int count = ChartBackground.Children.OfType().Count();

                // Относительная высота точки от нижнего края.
                // Для этого все абсолютные значения делятся на общий знаменатель,
                // чтобы максимальная высота точек не выходила выше установленной.
                double heightPoint = val / denominator;

                // Координаты узловой точки.
                double x = (count * lengthSectionLine) + (ChartBackground.ActualWidth - WidthChart) / 2;
                double y = heightPoint;

                // Узловая точка графика.
                Ellipse point = CreatePoint(x, y, _sizePoint, val);
                ChartBackground.Children.Add(point);

                // Надпись около узловой точки.
                Label title = CreateTitle(x - (_sizePoint / 2), y, val);
                ChartBackground.Children.Add(title);

                // Отрезок линии соединяющий предыдущую и текущую узловую точку.
                _polyline.Points.Add(new Point(x, ChartBackground.ActualHeight - y /* переворачиваем значение: отсчёт идёт от bottom*/));
            }
        }
    }
}
