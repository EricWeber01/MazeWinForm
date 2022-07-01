using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWinForm
{
    public class Laberint
    {
        class cord
        {
            int i, j;
            public int I { get; set; }
            public int J { get; set; }
            public cord(int i, int j) { I = i; J = j; }
            public cord() { }
        }
        List<cord> naid = new List<cord>();
        Random r = new Random();
        int sz = 5;
        int[,] lab2;

        public int Saiz { get { return sz; } set { sz = value; } }
        public int[,] Laberi { get { return lab2; } }

        public Laberint(int _sz) { if (_sz % 2 == 1) { sz = _sz; } else { sz = _sz - 1; } }
        public Laberint() { }

        void prover(string[,] lab)
        {
            for (int i = 0; i < naid.Count; i++)
            {
                int put = 0;
                if (naid[i].I - 2 > 0) { if (lab[naid[i].I - 2, naid[i].J] == "22") { put++; } }
                if (naid[i].J - 2 > 0) { if (lab[naid[i].I, naid[i].J - 2] == "22") { put++; } }
                if (naid[i].I + 2 < sz - 1) { if (lab[naid[i].I + 2, naid[i].J] == "22") { put++; } }
                if (naid[i].J + 2 < sz - 1) { if (lab[naid[i].I, naid[i].J + 2] == "22") { put++; } }
                if (put == 0) { naid.RemoveAt(i); i--; }
            }
        }
        void put(string[,] lab)
        {
            int col_22 = 0;
            do
            {
                prover(lab);
                //
                int v = r.Next(0, naid.Count);
                List<int> naprav = new List<int>();
                if (naid[v].I - 2 > 0) { if (lab[naid[v].I - 2, naid[v].J] == "22") { naprav.Add(1); } }
                if (naid[v].J - 2 > 0) { if (lab[naid[v].I, naid[v].J - 2] == "22") { naprav.Add(2); } }
                if (naid[v].I + 2 < sz - 1) { if (lab[naid[v].I + 2, naid[v].J] == "22") { naprav.Add(3); } }
                if (naid[v].J + 2 < sz - 1) { if (lab[naid[v].I, naid[v].J + 2] == "22") { naprav.Add(4); } }
                //
                int na = naprav[r.Next(0, naprav.Count)];
                if (na == 1) { lab[naid[v].I - 2, naid[v].J] = "77"; lab[naid[v].I - 1, naid[v].J] = "88"; naid.Add(new cord(naid[v].I - 2, naid[v].J)); }
                else if (na == 2) { lab[naid[v].I, naid[v].J - 2] = "77"; lab[naid[v].I, naid[v].J - 1] = "88"; naid.Add(new cord(naid[v].I, naid[v].J - 2)); }
                else if (na == 3) { lab[naid[v].I + 2, naid[v].J] = "77"; lab[naid[v].I + 1, naid[v].J] = "88"; naid.Add(new cord(naid[v].I + 2, naid[v].J)); }
                else if (na == 4) { lab[naid[v].I, naid[v].J + 2] = "77"; lab[naid[v].I, naid[v].J + 1] = "88"; naid.Add(new cord(naid[v].I, naid[v].J + 2)); }
                //
                col_22 = 0;
                for (int i = 0; i < sz - 1; i++)
                {
                    for (int j = 0; j < sz - 1; j++)
                    {
                        if (lab[i, j] == "22") { col_22++; }
                    }
                }
            } while (col_22 != 0);
        }
        void izmen(string[,] lab, int[,] lab2)
        {
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    if (lab[i, j] == "11" || lab[i, j] == "88" || lab[i, j] == "77") { lab2[i, j] = 0; }
                    else { lab2[i, j] = 1; }
                }
            }
        }
        public bool start()
        {
            string[,] lab = new string[sz, sz];
            int p = 0;
            int c1, c2;
            c1 = r.Next(0, (sz - 1) * 2);
            do
            {
                c2 = r.Next(0, (sz - 1) * 2);
            } while (c2 == c1);
            int sc = 0;
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    lab[i, j] = "22";
                    if (i % 2 == 0) { lab[i, j] = "99"; }
                    if (j % 2 == 0) { lab[i, j] = "99"; }
                    if ((i == 0 || j == 0 || i == sz - 1 || j == sz - 1) && !(i == 0 && j == 0) && !(i == 0 && j == sz - 1) && !(i == sz - 1 && j == 0) && !(i == sz - 1 && j == sz - 1) && (i % 2 == 1 || j % 2 == 1))
                    {
                        if (c1 == sc) { lab[i, j] = "11"; }
                        else if (c2 == sc) { lab[i, j] = "11"; }
                        sc++;
                    }
                }
            }
            lab[0, 0] = "00"; lab[0, sz - 1] = "00"; lab[sz - 1, 0] = "00"; lab[sz - 1, sz - 1] = "00";
            while (true)
            {
                for (int i = 0; i < sz; i++)
                {
                    for (int j = 0; j < sz; j++)
                    {
                        if (lab[i, j] == "22")
                        {
                            if (r.Next(1, 100) == 54)
                            {
                                lab[i, j] = "77"; naid.Add(new cord(i, j));
                                p = 1;
                                break;
                            }
                        }
                    }
                    if (p == 1) { break; }
                }
                if (p == 1) { break; }
            }
            put(lab);
            lab2 = new int[sz, sz];
            izmen(lab, lab2);
            return true;
        }

    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
