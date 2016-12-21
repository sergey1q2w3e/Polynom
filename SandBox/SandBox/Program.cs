using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable dt = new DataTable("Simple");
            //dt.Columns.Add(new DataColumn("INCOMING_DOC_ID"));
            //DataView dv = new DataView(dt);
            //DataRowView drv = dv.AddNew();
            //drv["INCOMING_DOC_ID"] = 11122;
            //dv.Table.Rows.Add(drv);

            //DataRowView drw = dt.DefaultView[0];



            //string docid = "322233";
            //Clipboard.SetDataObject(docid);
            //long g;
            //g = long.Parse(Clipboard.GetData(DataFormats.Text).ToString());


            int dim = 3;
            double[] coeff = {2.0, 3.0, -1.0, 2.0};
            
            //2x^3 + 3x^2 -1x +2  (2,28)
            //2+x(-1+x(3+2x))   
            double res = MathPolynom(2, dim, coeff);
            Console.WriteLine(res);
            double[] coefDeriv = Derivative(4, dim, coeff);
            double[] coefIntegral = Integral(dim, coeff);
            double resIntegral = IntegralDefinite(2, dim, coeff);
            Console.WriteLine(resIntegral);
            Console.Read();
            //out
            string s_out ="";
            for(int i = coeff.Length-1; i<0; i--)
            {
                s_out+=String.Format(coeff[i]+"x^");
            }
        }

        static double IntegralDefinite(int value, int dim, double[] coeff)
        {
            return MathPolynom(value, dim + 1, Integral(dim, coeff));
        }
        static double[] Integral(int dim, double[] coeff)
        {
            double[] newCoeff = new double[dim+2];
            for (int i = 0; i < newCoeff.Length - 1; i++)
            {
                newCoeff[i] = coeff[i]/(dim + 1 - i);
            }
            return newCoeff;
        }
        static double MathPolynom(int x, int dim, double[] coeff)
        {
            double result = 0.0;

            for (int i = 0; i < coeff.Length - 1; i++)
            {
                result = (result + coeff[i]) * x;
            }
            result += coeff[coeff.Length - 1];
            return result;
        }

        static double[] Derivative(int st, int dim, double[] coef)
        {
            if (st > dim) return new double[] {0};

            double[] newCoeff= new double[dim];
            for (int j = 0; j < st; j++)
            {
                newCoeff = new double[dim];

                for (int i = 0; i < dim; i++)
                {
                    newCoeff[i] = coef[i]*(dim - i);
                }
                coef = newCoeff;
                dim--;
            }
            return newCoeff;
        }

        
    }
}
