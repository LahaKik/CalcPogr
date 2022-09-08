using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        double Kst(int N, int DovVer)
        {
            double[,] Kt = new double[,] {{3.0770, 6.3130, 12.7060, 31.820, 63.656, 127.656, 318.306, 636.619 },
                { 1.8850, 2.9200, 4.3020, 6.964, 9.924, 14.089, 22.327, 31.599 },
                { 1.6377, 2.35340, 3.182, 4.540, 5.840, 7.458, 10.214, 12.924 },
                { 1.5332, 2.13180, 2.776, 3.746, 4.604, 5.597, 7.173, 8.610 },
                { 1.4759, 2.01500, 2.570, 3.649, 4.0321, 4.773, 5.893, 6.863 },
                { 1.4390, 1.943, 2.4460, 3.1420, 3.7070, 4.316, 5.2070, 5.958 },
                { 1.4149, 1.8946, 2.3646, 2.998, 3.4995, 4.2293, 4.785, 5.4079 },
                { 1.3968, 1.8596, 2.3060, 2.8965, 3.3554, 3.832, 4.5008, 5.0413 },
                { 1.3830, 1.8331, 2.2622, 2.8214, 3.2498, 3.6897, 4.2968, 4.780 },
                { 1.3720, 1.8125, 2.2281, 2.7638, 3.1693, 3.5814, 4.1437, 4.5869 },
                { 1.363, 1.795, 2.201, 2.718, 3.105, 3.496, 4.024, 4.437 },
                { 1.3562, 1.7823, 2.1788, 2.6810, 3.0845, 3.4284, 3.929, 4.178 },
                { 1.3502, 1.7709, 2.1604, 2.6503, 3.1123, 3.3725, 3.852, 4.220 },
                { 1.3450, 1.7613, 2.1448, 2.6245, 2.976, 3.3257, 3.787, 4.140 },
                { 1.3406, 1.7530, 2.1314, 2.6025, 2.9467, 3.2860, 3.732, 4.072 },
                { 1.3360, 1.7450, 2.1190, 2.5830, 2.9200, 3.2520, 3.6860, 4.0150 },
                { 1.3334, 1.7396, 2.1098, 2.5668, 2.8982, 3.2224, 3.6458, 3.965 },
                { 1.3304, 1.7341, 2.1009, 2.5514, 2.8784, 3.1966, 3.6105, 3.9216 },
                { 1.3277, 1.7291, 2.0930, 2.5395, 2.8609, 3.1737, 3.5794, 3.8834 },
                { 1.3253, 1.7247, 2.08600, 2.5280, 2.8453, 3.1534, 3.5518, 3.8495 },
                { 1.3230, 1.7200, 2.0790, 2.5170, 2.8310, 3.1350, 3.5270, 3.8190 },
                { 1.3212, 1.7117, 2.0739, 2.5083, 2.8188, 3.1188, 3.5050, 3.7921 },
                { 1.3195, 1.7139, 2.0687, 2.4999, 2.8073, 3.1040, 3.4850, 3.7676 },
                { 1.3178, 1.7109, 2.0639, 2.4922, 2.7969, 3.0905, 3.4668, 3.7454 },
                { 1.3163, 1.7081, 2.0595, 2.4851, 2.7874, 3.0782, 3.4502, 3.7251 },
                { 1.315, 1.705, 2.059, 2.478, 2.778, 3.0660, 3.4360, 3.7060 },
                { 1.3137, 1.7033, 2.0518, 2.4727, 2.7707, 3.0565, 3.4210, 3.6896 },
                { 1.3125, 1.7011, 2.0484, 2.4671, 2.7633, 3.0469, 3.4082, 3.6739 },
                { 1.3114, 1.6991, 2.0452, 2.4620, 2.7564, 3.0360, 3.3962, 3.8494 },
                { 1.3104, 1.6973, 2.0423, 2.4573, 2.7500, 3.0298, 3.3852, 3.6460 } };
            return Kt[N - 2, DovVer];
                
        }
        public Form1()
        {
            InitializeComponent();
        }



        double Sigma(List<double> tX,int N, double AbsX)
        {
            double sum = 0;
            foreach (double x in tX)
                sum += Math.Pow((x - AbsX), 2);
            return (Math.Sqrt(sum / (N * (N - 1))));
        }


        void Calculate()
        {
            if (dataGridView1.Rows.Count > 2)
            {
                double SrArif = 0f, dX, sigma;
                int cntNull = 0;
                int N;
                List<double> listX = new List<double>();
                foreach (DataGridViewRow str in dataGridView1.Rows)
                {
                    if (str.Cells[0].EditedFormattedValue.ToString() != "")
                        try
                        {
                            var a = Convert.ToDouble(str.Cells[0].EditedFormattedValue.ToString());
                            SrArif += a;
                            listX.Add(a);
                        }
                        catch (FormatException) { }
                        catch
                        {
                            MessageBox.Show("Неправильный тип данных", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    else
                        cntNull += 1;

                }
                N = dataGridView1.Rows.Count - cntNull;
                SrArif /= N;
                sigma = Sigma(listX, N, SrArif);
                textBox1.Text = "Прибл. ист. знач.: " + SrArif.ToString() + "\r\n" + "Сигма: " + sigma.ToString() + "\r\n";
                if (comboBox1.SelectedIndex != -1)
                {
                    string ocrX;
                    dX = sigma * Kst(N, comboBox1.SelectedIndex);
                    textBox1.Text += "dX: " + dX.ToString() + "\r\n";
                    string dXstr = dX.ToString();
                    if (Convert.ToUInt16(dXstr[dXstr.IndexOf(',') + 1]) >= 3)
                    {
                        dX = Math.Round(dX, 1);
                        dXstr = dX.ToString();
                        ocrX = Math.Round(SrArif, 1).ToString();
                    }
                    else
                    {
                        dX = Math.Round(dX, 2);
                        dXstr = dX.ToString();
                        ocrX = Math.Round(SrArif, 2).ToString();
                    }
                    textBox1.Text += "Итого: " + '(' + ocrX + '±' + dXstr + ')' + "\r\n";
                }
            }


        }

        private void EndEdit(object sender, DataGridViewCellParsingEventArgs e)
        {
            Calculate();
        }

        private void Selected(object sender, EventArgs e)
        {
            Calculate();
        }



        //string Print(double AbsX, )

    }
}
