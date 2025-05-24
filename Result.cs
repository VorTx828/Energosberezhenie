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

namespace Program
{

    public partial class Result : Form
    {
        private BindingSource bindingSource = new BindingSource();

        private Main a;
        public Result(Main a)
        {
            InitializeComponent();

            this.a = a;

            InitializeChart();

            textBox1.Text = Convert.ToString(a.F());
            textBox2.Text = Convert.ToString(a.V());
            textBox3.Text = Convert.ToString(a.S());
            textBox4.Text = Convert.ToString(a.k_Tr());
            textBox5.Text = Convert.ToString(a.e_g());
            textBox6.Text = Convert.ToString(a.k_Tst());
            textBox7.Text = Convert.ToString(a.ar());
            textBox8.Text = Convert.ToString(a.q());
            textBox9.Text = Convert.ToString(a.Q());


            Form1 form1 = new Form1();
            this.FormClosed += (_o, _e) => form1.Show();
        }

        private void InitializeChart()
        {
            

            // 2. Настройка BindingSource
            bindingSource.DataSource = a.Result(7);

            // 3. Очистка предыдущих данных графика
            chart1.Series.Clear();
            chart2.Series.Clear();

            // 4. Создание и настройка серии
            Series series1 = new Series("k_Tr(T)");
            series1.ChartType = SeriesChartType.Line;

            Series series2 = new Series("e_g(T)");
            series2.ChartType = SeriesChartType.Line;


            Series series4 = new Series("Q(T)");
            series4.ChartType = SeriesChartType.Line;


            // 5. Привязка данных через BindingSource
            series1.XValueMember = "T";  // Используем Category для оси X
            series1.YValueMembers = "k_Tr";    // Используем Value для оси Y
            series1.Label = "#VALY";           // Формат отображения значений


            series2.XValueMember = "T";  // Используем Category для оси X
            series2.YValueMembers = "e_g";    // Используем Value для оси Y
            series2.Label = "#VALY";

            series4.XValueMember = "T";  // Используем Category для оси X
            series4.YValueMembers = "Q";    // Используем Value для оси Y
            series4.Label = "#VALY";

            // 6. Установка источника данных
            chart1.DataSource = bindingSource;
            chart2.DataSource = bindingSource;

            // 7. Добавление серии на график
            chart2.Series.Add(series1);
            chart2.Series.Add(series2);
            //chart1.Series.Add(series3);
            chart1.Series.Add(series4);

            // 8. Привязка данных
            chart1.DataBind();
            chart2.DataBind();


            // 9. Дополнительные настройки
            ConfigureChartAppearance(chart1, 3000, 9000000);
            ConfigureChartAppearance(chart2, 2000, 1, "Степень черноты и коэффициент ослабления газа");




        }

        private void ConfigureChartAppearance(Chart chart, int maxX, int maxY, string YTitle = "Тепловой поток, Вт")
        {
            // Добавляем ChartArea, если её нет
            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("Default"));

            var area = chart.ChartAreas[0];

            // Фон всей области графика
            area.BackColor = Color.White;

            // Оси
            area.AxisX.Title = "Температура, К";
            area.AxisY.Title = YTitle;

            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = maxX;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = maxY;

            area.AxisX.Interval = maxX / 10; // Автоматический интервал по X
            area.AxisY.Interval = maxY / 10; // Автоматический интервал по Y

            // Сетка
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Подписи
            area.AxisX.LabelStyle.ForeColor = Color.Black;
            area.AxisY.LabelStyle.ForeColor = Color.Black;

            // Подписи данных + улучшение визуала
            int colorIndex = 0;
            foreach (var series in chart.Series)
            {
                series.IsValueShownAsLabel = false;
                series.BorderWidth = 2;
                series.MarkerStyle = MarkerStyle.Circle; // Точки на линиях
                series.MarkerSize = 6;
                series.MarkerBorderWidth = 2;
                series.MarkerBorderColor = Color.Black;
                series.ShadowOffset = 2;
                series.SmartLabelStyle.Enabled = true;

                // Цвета для разных серий
                switch (colorIndex % 5)
                {
                    case 0: series.Color = Color.SteelBlue; break;
                    case 1: series.Color = Color.SeaGreen; break;
                    case 2: series.Color = Color.Goldenrod; break;
                    case 3: series.Color = Color.DarkOrange; break;
                    case 4: series.Color = Color.Purple; break;
                }

                // Можно задать разные типы линий
                if (series.Name.Contains("q") || series.Name.Contains("Q"))
                {
                    series.BorderDashStyle = ChartDashStyle.Dash;
                }

                colorIndex++;
            }

            // Легенда
            if (chart.Legends.Count == 0)
                chart.Legends.Add(new Legend("DefaultLegend"));

            chart.Legends[0].Enabled = true;
            chart.Legends[0].Docking = Docking.Bottom; // Легенда снизу
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Font = new Font("Segoe UI", 9);

            // Добавим анимацию
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            //chart.TextAntiAliasingQuality = TextAntiAliasQuality.High;
            chart.AntiAliasing = AntiAliasingStyles.All;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
