using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Interpolation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArgumentTable.RowCount = 2;
            ArgumentTable.Rows[0].HeaderCell.Value = "x";
            ArgumentTable.Rows[1].HeaderCell.Value = "y";
        }

        private void GenTableBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(PointCount.Text, out int numPoints) && numPoints > 0)
            {
                ArgumentTable.ColumnCount = 1;
                ArgumentTable.Columns[0].HeaderCell.Value = "x1";
                for (int i = 1; i < numPoints; i++)
                {
                    ArgumentTable.Columns.Add("","x"+(i+1));
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of points.");
            }
        }
        private void PlotLagrangePolynomial()
        {
            // Получение данных из DataGridView
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            DataGridViewRow xRow = ArgumentTable.Rows[0];
            DataGridViewRow yRow = ArgumentTable.Rows[1];

            for (int i = 0; i < ArgumentTable.Columns.Count; i++) // Начинаем с 1, чтобы пропустить столбцы "X" и "Y"
            {
                if (xRow.Cells[i].Value != null && yRow.Cells[i].Value != null)
                {
                    try
                    {
                        double x = Convert.ToDouble(xRow.Cells[i].Value);
                        double y = Convert.ToDouble(yRow.Cells[i].Value);
                        xValues.Add(x);
                        yValues.Add(y);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please enter valid numeric values.");
                        return;
                    }
                }
            }


            // Очистка предыдущих серий
            chart1.Series.Clear();

            // Добавление точек на график
            var seriesPoints = new Series("Points")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Red
            };
            

            for (int i = 0; i < xValues.Count; i++)
            {
                seriesPoints.Points.AddXY(xValues[i], yValues[i]);
            }


            // Построение полинома Лагранжа
            var seriesLagrange = new Series("Lagrange Polynomial")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Blue
            };

            for (double x = xValues[0]; x <= xValues[xValues.Count - 1]; x += 0.01)
            {
                double y = LagrangePolynomial(x, xValues.ToArray(), yValues.ToArray());
                seriesLagrange.Points.AddXY(x, y);
            }

            chart1.Series.Add(seriesLagrange);
            chart1.Series.Add(seriesPoints);
        }
        private double LagrangePolynomial(double x, double[] xValues, double[] yValues)
        {
            double result = 0.0;
            int n = xValues.Length;

            for (int i = 0; i < n; i++)
            {
                double term = yValues[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        term *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                result += term;
            }

            return result;
        }
        private void LagranjBtn_Click(object sender, EventArgs e)
        {
            PlotLagrangePolynomial();
        }

        private void CubicSplineBtn_Click(object sender, EventArgs e)
        {
            // Получение данных из DataGridView
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            DataGridViewRow xRow = ArgumentTable.Rows[0];
            DataGridViewRow yRow = ArgumentTable.Rows[1];

            for (int i = 0; i < ArgumentTable.Columns.Count; i++) // Начинаем с 1, чтобы пропустить столбцы "X" и "Y"
            {
                if (xRow.Cells[i].Value != null && yRow.Cells[i].Value != null)
                {
                    try
                    {
                        double x = Convert.ToDouble(xRow.Cells[i].Value);
                        double y = Convert.ToDouble(yRow.Cells[i].Value);
                        xValues.Add(x);
                        yValues.Add(y);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please enter valid numeric values.");
                        return;
                    }
                }
            }


            // Очистка предыдущих серий
            chart1.Series.Clear();

            // Добавление точек на график
            var seriesPoints = new Series("Points")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Red
            };


            for (int i = 0; i < xValues.Count; i++)
            {
                seriesPoints.Points.AddXY(xValues[i], yValues[i]);
            }
            if (xValues.Count > 1)
            {
                // Интерполяция кубическим сплайном
                (double[] xs, double[] ys) = InterpolateSpline(xValues.ToArray(), yValues.ToArray(), 100);

                // Добавление точек на график
                chart1.Series.Clear();
                Series series = new Series
                {
                    ChartType = SeriesChartType.Point,
                    MarkerStyle = MarkerStyle.Circle
                };

                for (int i = 0; i < xs.Length; i++)
                {
                    series.Points.AddXY(xs[i], ys[i]);
                }

                chart1.Series.Add(series);
                chart1.Series.Add(seriesPoints);
            }
        }
        private (double[], double[]) InterpolateSpline(double[] x, double[] y, int numPoints)
        {
            int n = x.Length;
            double[] a = new double[n];
            double[] b = new double[n - 1];
            double[] d = new double[n - 1];
            double[] h = new double[n - 1];

            for (int i = 0; i < n; i++)
                a[i] = y[i];

            for (int i = 0; i < n - 1; i++)
                h[i] = x[i + 1] - x[i];

            double[] alpha = new double[n - 1];
            for (int i = 1; i < n - 1; i++)
                alpha[i] = (3 / h[i] * (a[i + 1] - a[i])) - (3 / h[i - 1] * (a[i] - a[i - 1]));

            double[] c = new double[n];
            double[] l = new double[n];
            double[] mu = new double[n];
            double[] z = new double[n];
            l[0] = 1;
            mu[0] = 0;
            z[0] = 0;

            for (int i = 1; i < n - 1; i++)
            {
                l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
                mu[i] = h[i] / l[i];
                z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
            }

            l[n - 1] = 1;
            z[n - 1] = 0;
            c[n - 1] = 0;

            for (int j = n - 2; j >= 0; j--)
            {
                c[j] = z[j] - mu[j] * c[j + 1];
                b[j] = (a[j + 1] - a[j]) / h[j] - h[j] * (c[j + 1] + 2 * c[j]) / 3;
                d[j] = (c[j + 1] - c[j]) / (3 * h[j]);
            }

            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            for (int i = 0; i < n - 1; i++)
            {
                double step = (x[i + 1] - x[i]) / (double)numPoints;
                for (double xi = x[i]; xi < x[i + 1]; xi += step)
                {
                    double yi = a[i] + b[i] * (xi - x[i]) + c[i] * Math.Pow((xi - x[i]), 2) + d[i] * Math.Pow((xi - x[i]), 3);
                    xs.Add(xi);
                    ys.Add(yi);
                }
            }

            xs.Add(x[n - 1]);
            ys.Add(a[n - 1]);

            return (xs.ToArray(), ys.ToArray());
        }
    }
}
