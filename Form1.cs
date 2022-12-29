using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[,] ImageMatrix;
        int Wmax = 3;
        int T = 1;
        int SelectedFilterID = 0;
        int UsedAlgorithm = 0;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
        }

        private void btnZGraph_Click(object sender, EventArgs e)
        {
            if (T > 4)
            {
                MessageBox.Show("Trim Value must be less than 5 to generate graph starting at window size=3");
            }
            else
            {
                int N = 40;
                double[] x_values = new double[N];
                double[] y_values_AMF1 = new double[N];
                double[] y_values_AMF2 = new double[N];
                double[] y_values_ATF1 = new double[N];
                double[] y_values_ATF2 = new double[N];
                int counter = 0;
                for (int i = Wmax; i >= 3; i -= 2)
                {
                    x_values[counter] = i;
                    int time1 = Environment.TickCount;
                    AdaptiveMedianFilter.ApplyFilter(ImageMatrix, i, 0);
                    int time2 = Environment.TickCount;
                    y_values_AMF1[counter] = time2 - time1;
                    time1 = Environment.TickCount;
                    AdaptiveMedianFilter.ApplyFilter(ImageMatrix, i, 1);
                    time2 = Environment.TickCount;
                    y_values_AMF2[counter] = time2 - time1;
                    time1 = Environment.TickCount;
                    AlphaTrimFilter.ApplyFilter(ImageMatrix, i, 0, T);
                    time2 = Environment.TickCount;
                    y_values_ATF1[counter] = time2 - time1;
                    time1 = Environment.TickCount;
                    AlphaTrimFilter.ApplyFilter(ImageMatrix, i, 1, T);
                    time2 = Environment.TickCount;
                    y_values_ATF2[counter] = time2 - time1;
                    counter++;

                }


                //Create a graph and add two curves to it
                ZGraphForm ZGF = new ZGraphForm("Adaptive Median Filter", "Window Size", "Execution Time");
                ZGF.add_curve("Quick Sort", x_values, y_values_AMF1, Color.Red);
                ZGF.add_curve("Counting Sort", x_values, y_values_AMF2, Color.Blue);
                ZGF.Show();
                ZGraphForm ZGF2 = new ZGraphForm("Alpha Trim Filter", "Window Size", "Execution Time");
                ZGF2.add_curve("Counting Sort", x_values, y_values_ATF1, Color.Red);
                ZGF2.add_curve("Kth element", x_values, y_values_ATF2, Color.Blue);
                ZGF2.Show();
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (Wmax * Wmax < 2 * T)
            {
                MessageBox.Show("You are trying to trim more than the window size!");
            }
            else
            {
                if (SelectedFilterID == 0)
                {
                    ImageOperations.DisplayImage(AlphaTrimFilter.ApplyFilter(ImageMatrix, Wmax, UsedAlgorithm, T),
                        pictureBox2);
                }
                else
                {
                    ImageOperations.DisplayImage(AdaptiveMedianFilter.ApplyFilter(ImageMatrix, Wmax, UsedAlgorithm),
                        pictureBox2);
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAlgorithm.Visible = true;
            lbl_algorithm.Visible = true;
            if (cbFilter.SelectedIndex == 0)
            {
                label1.Visible = true;
                maxWindowSize.Visible = true;
                label2.Visible = true;
                trimmingValue.Visible = true;
                SelectedFilterID = 0;

                cbAlgorithm.Items.Clear();

                cbAlgorithm.Items.Add("Counting Sort");
                cbAlgorithm.Items.Add("Kth Smallest/Largest");
            }
            else
            {
                label1.Visible = true;
                maxWindowSize.Visible = true;
                label2.Visible = false;
                trimmingValue.Visible = false;
                SelectedFilterID = 1;

                cbAlgorithm.Items.Clear();

                cbAlgorithm.Items.Add("Quick Sort");
                cbAlgorithm.Items.Add("Counting Sort");
            }
        }

        private void cbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsedAlgorithm = cbAlgorithm.SelectedIndex;
        }

        private void maxWindowSize_ValueChanged(object sender, EventArgs e)
        {
            Wmax = (int)maxWindowSize.Value;
        }

        private void trimmingValue_ValueChanged(object sender, EventArgs e)
        {
            T = (int)trimmingValue.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}