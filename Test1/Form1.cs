using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        List<Triangle> m_triangles = new List<Triangle> { };
        List<Rectangular> m_rectangular = new List<Rectangular> { };


        public Form1()
        {
            InitializeComponent();
        }

        private void AddTriangle_Click(object sender, EventArgs e)
        {
            double First_Side = Convert.ToDouble(txtFirstSide.Text == "" ? "0" : txtFirstSide.Text);
            double Second_Side = Convert.ToDouble(txtSecondSide.Text == "" ? "0" : txtSecondSide.Text);
            double Third_Side = Convert.ToDouble(txtThirdSide.Text == "" ? "0" : txtThirdSide.Text);

            m_triangles.Add(new Triangle(First_Side, Second_Side, Third_Side));

            txtFirstSide.Text = "";
            txtSecondSide.Text = "";
            txtThirdSide.Text = "";
        }

        private void DisplayTriangles_Click(object sender, EventArgs e)
        {
            OutputTriangles.Text = "";

            String Result = "";
            for (int i = 0; i < m_triangles.Count; ++i)
                Result += m_triangles[i].ToString() + Environment.NewLine;

            OutputTriangles.Text = Result;
        }

        private void AddRectangular_Click(object sender, EventArgs e)
        {
            double First_Leg = Convert.ToDouble(txtFirstLeg.Text == "" ? "0" : txtFirstLeg.Text);
            double Second_Leg = Convert.ToDouble(txtSecondLeg.Text == "" ? "0" : txtSecondLeg.Text);
            double Hypotenuse = Convert.ToDouble(txtHypotenuse.Text == "" ? "0" : txtHypotenuse.Text);

            m_rectangular.Add(new Rectangular(First_Leg, Second_Leg, Hypotenuse));

            txtFirstLeg.Text = "";
            txtSecondLeg.Text = "";
            txtHypotenuse.Text = "";
        }

        private void DisplayRectangular_Click(object sender, EventArgs e)
        {
            OutputRectangular.Text = "";

            String Result = "";
            for (int i = 0; i < m_rectangular.Count; ++i)
                Result += m_rectangular[i].ToString() + Environment.NewLine;

            OutputRectangular.Text = Result;
        }

        private void TriangleArea_Click(object sender, EventArgs e)
        {
            String Result = "";

            int max_area_index = 0;
            double max_area = 0;

            for (int i = 0; i < m_triangles.Count; ++i)
                if (max_area < m_triangles[i].GetSquare())
                {
                    max_area_index = i;
                    max_area = m_triangles[i].GetSquare();
                }

            if (m_triangles.Count > 0)
                Result = m_triangles[max_area_index].ToString();

            OutputTriangles.Text = Result;
        }

        private void SmallHypotenuse_Click(object sender, EventArgs e)
        {

            String Result = "";

            int min_hypot_index = 0;
            double min_hypotenuse = 0;

            for (int i = 0; i < m_rectangular.Count; ++i)
                if (min_hypotenuse > m_rectangular[i].Hypotenuse)
                {
                    min_hypot_index = i;
                    min_hypotenuse = m_rectangular[i].Hypotenuse;
                }

            if (m_rectangular.Count > 0)
                Result = m_rectangular[min_hypot_index].ToString();

            OutputRectangular.Text = Result;
        }
    }
}
