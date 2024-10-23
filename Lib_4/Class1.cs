
using System.Data;

namespace Lib_4
{
    public static class VisualArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("������� �" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }

        /// <summary>
        /// ���������� ����������� ����� �����, ������� ������ 0
        /// </summary>
        /// <param name="mas">������</param>
        /// <returns>������������ �������� ���������� ������ �� �����, ������� ������ 0</returns>
        public static List<double> CalculatorFunkcion(int[] mas)
        {
            List<double> rez = new List<double>();

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    double rezult = Math.Sqrt(mas[i]);
                    rez.Add(rezult);
                }
            }

            return rez;
        }
    }
}
