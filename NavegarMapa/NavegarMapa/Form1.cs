using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;




namespace NavegarMapa
{
    public partial class Form1 : Form
    {
        System.IO.Ports.SerialPort puerto;
        int guardaremos = 0;
        Random random = new Random();
        int mama = 0;
        int serie1 = 0, serie2 = 0, serie3 = 0, serie4 = 0, serie5 = 0, serie6 = 0, serie7 = 0;
        String[] listado_puerto = System.IO.Ports.SerialPort.GetPortNames();
        string datos_puerto;
        public string filepath = @"C:\Micro\Mapa.txt";
        public string filepath2 = @"C:\Micro\norte.txt";
        public string filepath3 = @"C:\Micro\sur.txt";
        public string filepath4 = @"C:\Micro\este.txt";
        public string filepath5 = @"C:\Micro\oeste.txt";
        string[] norte;
        string[] sur;
        string[] este;
        string[] oeste;
        int divisions, divisionn, divisiones, divisiono = 0;
        int posicionn = -1;

        int[] n1 = new int[100000];
        int[] s1 = new int[100000];
        int[] o1 = new int[100000];
        int[] es1 = new int[100000];

        int[] n2 = new int[100000];
        int[] s2 = new int[100000];
        int[] o2 = new int[100000];
        int[] es2 = new int[100000];

        int n, s, es, o = 0;
        int tamañonorte, tamañosur, tamañoeste, tamañooeste = 0;
        int movn, movs, moves, movo = 0;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button323_Click(object sender, EventArgs e)
        {
            try
            {
                puerto.Close();
                timer1.Stop();
                comboBox1.Enabled = true;
                button322.Enabled = true;
                button323.Enabled = false;
                groupBox3.Enabled = true;
            }
            catch { }
        }

        private void button324_Click(object sender, EventArgs e)
        {
            guardaremos = 1;
            try
            {
                groupBox1.Enabled = false;
                button361.Enabled = true;
                button362.Enabled = true;
                button363.Enabled = true;
                button364.Enabled = true;
            }
            catch { }
            string[] text1 = System.IO.File.ReadAllLines(filepath2); // read the file into a string array with removing the duplicates and empty lines
            string[] text2 = System.IO.File.ReadAllLines(filepath3); // read the file into a string array with removing the duplicates and empty lines
            string[] text3 = System.IO.File.ReadAllLines(filepath4); // read the file into a string array with removing the duplicates and empty lines
            string[] text4 = System.IO.File.ReadAllLines(filepath5); // read the file into a string array with removing the duplicates and empty lines
            //string[] text1 = System.IO.File.ReadAllLines(filepath2); // read the file into a string array with removing the duplicates and empty lines
            tamañonorte = text1.Length;
            tamañosur = text2.Length;
            tamañoeste = text3.Length;
            tamañooeste = text4.Length;

            movn = 0;
            movo = 0;
            moves = 0;
            movs = 0;

            sumn = 0;
            sums = 0;
            sumo = 0;
            sumes = 0;

            for(int i = 0; i< tamañonorte; i++)
            {
                n = Convert.ToInt32(text1[i]);
                //button365.Text = Convert.ToString(divisionn);
                n2[i] = n;
                n1[i] = n2[i];
                //button364.Text = Convert.ToString(divisions);

            }
            for (int i = 0; i < tamañosur; i++)
            {
                s = Convert.ToInt32(text2[i]);
                s2[i] = s;
                s1[i] = s2[i];
            }
            for (int i = 0; i < tamañoeste; i++)
            {
                es = Convert.ToInt32(text3[i]);
                es2[i] = es;
                es1[i] = es2[i];
            }
            for (int i = 0; i < tamañooeste; i++)
            {
                o = Convert.ToInt32(text4[i]);
                o2[i] = o;
                o1[i] = o2[i];
            }
            botones();
        }

        private void button325_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Enabled = true;
                button361.Enabled = false;
                button362.Enabled = false;
                button363.Enabled = false;
                button364.Enabled = false;
                movn = 0;
                movo = 0;
                moves = 0;
                movs = 0;

                sumn = 0;
                sums = 0;
                sumo = 0;
                sumes = 0;
                botones();
            }
            catch { }
        }

        private void w(object sender, KeyPressEventArgs e)
        {
            //button361.PerformClick();
        }

        private void button362_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       /* private void s(object sender, KeyPressEventArgs e)
        {
            button362.PerformClick();
        }*/

       /* private void x(object sender, KeyPressEventArgs e)
        {
            
        }*/

        private void a(object sender, KeyPressEventArgs e)
        {
            //button363.PerformClick();
        }

        private void d(object sender, KeyPressEventArgs e)
        {
            //button364.PerformClick();
        }

        private void z(object sender, KeyPressEventArgs e)
        {
            //button362.PerformClick();
        }

        private void button361_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button322_Click(object sender, EventArgs e)
        {
            try
            {
                movn = 0;
                movo = 0;
                moves = 0;
                movs = 0;

                sumn = 0;
                sums = 0;
                sumo = 0;
                sumes = 0;
                botones();
                serial();
                puerto.Open();
                timer1.Start();
                comboBox1.Enabled = false;
                button323.Enabled = true;
                button322.Enabled = false;
                groupBox3.Enabled = false;
            }
            catch (Exception)
            { }
        }

        private void button364_Click(object sender, EventArgs e)
        {
            
            if (movn > tamañonorte)
            {
                movn = tamañonorte;
            }
            else
            {
                movn++;
                movs++;


                sumo = sumo + 30;
                sumes = sumes - 30;
            }
            label7.Text = movn.ToString() + "," + movo.ToString();
            botones();
        }

        private void button363_Click(object sender, EventArgs e)
        {
            if (movn <= 0)
            {
                movn = 0;
            }
            else
            {
                movn--;
                movs--;


                sumo = sumo - 30;
                sumes = sumes + 30;
            }
            label7.Text = movn.ToString() + "," + movo.ToString();
            botones();
        }

        private void button362_Click(object sender, EventArgs e)
        {
            if (movo <= 0)
            {
                movo = 0;
            }
            else
            {
                movo--;
                moves--;

                sumn = sumn + 30;
                sums = sums - 30;
            }
            label7.Text = movn.ToString() + "," + movo.ToString();
            botones();
        }

        int sumn, sums, sumes, sumo = 0;
        private void button361_Click(object sender, EventArgs e)
        {
            
            if (movo > tamañooeste)
            {
                movo = tamañooeste;             
            }
            else
            {
                movo++;
                moves++;

                sumn = sumn - 30;
                sums = sums + 30;
            }
            label7.Text = movn.ToString() + "," + movo.ToString();
            botones();

        }

        int rowread = 0;
        string tester;
        int xxx = 1;
        double tiempo = 0.0;
        int x = 0;
        private void button365_Click(object sender, EventArgs e)
        {

        }              
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DataSource = listado_puerto; // listado de puertos
        }

        public void botones()
        {
            //norte linea 1 de izq a der
            if (n1[movn] + sumn < 30)
            {
                button10.Enabled = true;
                button20.Enabled = true;
                button30.Enabled = true;
                button40.Enabled = true;
                button50.Enabled = true;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.LightGray;
                button20.BackColor = Color.LightGray;
                button30.BackColor = Color.LightGray;
                button40.BackColor = Color.LightGray;
                button50.BackColor = Color.LightGray;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;
            }
            else if (n1[movn] + sumn < 31)
            {
                button10.Enabled = false;
                button20.Enabled = true;
                button30.Enabled = true;
                button40.Enabled = true;
                button50.Enabled = true;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;
                button10.BackColor = Color.Lime;
                button20.BackColor = Color.LightGray;
                button30.BackColor = Color.LightGray;
                button40.BackColor = Color.LightGray;
                button50.BackColor = Color.LightGray;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 61)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = true;
                button40.Enabled = true;
                button50.Enabled = true;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.LightGray;
                button40.BackColor = Color.LightGray;
                button50.BackColor = Color.LightGray;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 91)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = true;
                button50.Enabled = true;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.LightGray;
                button50.BackColor = Color.LightGray;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 121)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = false;
                button50.Enabled = true;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.Lime;
                button50.BackColor = Color.LightGray;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 151)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = false;
                button50.Enabled = false;
                button60.Enabled = true;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.Lime;
                button50.BackColor = Color.Lime;
                button60.BackColor = Color.LightGray;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 181)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = false;
                button50.Enabled = false;
                button60.Enabled = false;
                button70.Enabled = true;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.Lime;
                button50.BackColor = Color.Lime;
                button60.BackColor = Color.Lime;
                button70.BackColor = Color.LightGray;
                button80.BackColor = Color.LightGray;

            }
            else if (n1[movn] + sumn < 211)
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = false;
                button50.Enabled = false;
                button60.Enabled = false;
                button70.Enabled = false;
                button80.Enabled = true;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.Lime;
                button50.BackColor = Color.Lime;
                button60.BackColor = Color.Lime;
                button70.BackColor = Color.Lime;
                button80.BackColor = Color.LightGray;
            }
            else
            {
                button10.Enabled = false;
                button20.Enabled = false;
                button30.Enabled = false;
                button40.Enabled = false;
                button50.Enabled = false;
                button60.Enabled = false;
                button70.Enabled = false;
                button80.Enabled = false;

                button10.BackColor = Color.Lime;
                button20.BackColor = Color.Lime;
                button30.BackColor = Color.Lime;
                button40.BackColor = Color.Lime;
                button50.BackColor = Color.Lime;
                button60.BackColor = Color.Lime;
                button70.BackColor = Color.Lime;
                button80.BackColor = Color.Lime;
            }
            //norte linea 2 de izq a der
            if (n1[movn + 1] + sumn < 30)
            {
                button9.Enabled = true;
                button19.Enabled = true;
                button29.Enabled = true;
                button39.Enabled = true;
                button49.Enabled = true;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.LightGray;
                button19.BackColor = Color.LightGray;
                button29.BackColor = Color.LightGray;
                button39.BackColor = Color.LightGray;
                button49.BackColor = Color.LightGray;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 31)
            {
                button9.Enabled = false;
                button19.Enabled = true;
                button29.Enabled = true;
                button39.Enabled = true;
                button49.Enabled = true;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.LightGray;
                button29.BackColor = Color.LightGray;
                button39.BackColor = Color.LightGray;
                button49.BackColor = Color.LightGray;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 61)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = true;
                button39.Enabled = true;
                button49.Enabled = true;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.LightGray;
                button39.BackColor = Color.LightGray;
                button49.BackColor = Color.LightGray;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 91)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = true;
                button49.Enabled = true;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.LightGray;
                button49.BackColor = Color.LightGray;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 121)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = false;
                button49.Enabled = true;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.Lime;
                button49.BackColor = Color.LightGray;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 151)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = false;
                button49.Enabled = false;
                button59.Enabled = true;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.Lime;
                button49.BackColor = Color.Lime;
                button59.BackColor = Color.LightGray;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 181)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = false;
                button49.Enabled = false;
                button59.Enabled = false;
                button69.Enabled = true;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.Lime;
                button49.BackColor = Color.Lime;
                button59.BackColor = Color.Lime;
                button69.BackColor = Color.LightGray;
                button79.BackColor = Color.LightGray;
            }
            else if (n1[movn + 1] + sumn < 211)
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = false;
                button49.Enabled = false;
                button59.Enabled = false;
                button69.Enabled = false;
                button79.Enabled = true;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.Lime;
                button49.BackColor = Color.Lime;
                button59.BackColor = Color.Lime;
                button69.BackColor = Color.Lime;
                button79.BackColor = Color.LightGray;
            }
            else
            {
                button9.Enabled = false;
                button19.Enabled = false;
                button29.Enabled = false;
                button39.Enabled = false;
                button49.Enabled = false;
                button59.Enabled = false;
                button69.Enabled = false;
                button79.Enabled = false;

                button9.BackColor = Color.Lime;
                button19.BackColor = Color.Lime;
                button29.BackColor = Color.Lime;
                button39.BackColor = Color.Lime;
                button49.BackColor = Color.Lime;
                button59.BackColor = Color.Lime;
                button69.BackColor = Color.Lime;
                button79.BackColor = Color.Lime;
            }
            //norte linea 3 de izq a der
            if (n1[movn + 2] + sumn < 30)
            {
                button8.Enabled = true;
                button18.Enabled = true;
                button28.Enabled = true;
                button38.Enabled = true;
                button48.Enabled = true;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.LightGray;
                button18.BackColor = Color.LightGray;
                button28.BackColor = Color.LightGray;
                button38.BackColor = Color.LightGray;
                button48.BackColor = Color.LightGray;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 31)
            {
                button8.Enabled = false;
                button18.Enabled = true;
                button28.Enabled = true;
                button38.Enabled = true;
                button48.Enabled = true;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.LightGray;
                button28.BackColor = Color.LightGray;
                button38.BackColor = Color.LightGray;
                button48.BackColor = Color.LightGray;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 61)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = true;
                button38.Enabled = true;
                button48.Enabled = true;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.LightGray;
                button38.BackColor = Color.LightGray;
                button48.BackColor = Color.LightGray;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 91)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = true;
                button48.Enabled = true;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.LightGray;
                button48.BackColor = Color.LightGray;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 121)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = false;
                button48.Enabled = true;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.Lime;
                button48.BackColor = Color.LightGray;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 151)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = false;
                button48.Enabled = false;
                button58.Enabled = true;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.Lime;
                button48.BackColor = Color.Lime;
                button58.BackColor = Color.LightGray;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 181)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = false;
                button48.Enabled = false;
                button58.Enabled = false;
                button68.Enabled = true;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.Lime;
                button48.BackColor = Color.Lime;
                button58.BackColor = Color.Lime;
                button68.BackColor = Color.LightGray;
                button78.BackColor = Color.LightGray;
            }
            else if (n1[movn + 2] + sumn < 211)
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = false;
                button48.Enabled = false;
                button58.Enabled = false;
                button68.Enabled = false;
                button78.Enabled = true;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.Lime;
                button48.BackColor = Color.Lime;
                button58.BackColor = Color.Lime;
                button68.BackColor = Color.Lime;
                button78.BackColor = Color.LightGray;
            }
            else
            {
                button8.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button38.Enabled = false;
                button48.Enabled = false;
                button58.Enabled = false;
                button68.Enabled = false;
                button78.Enabled = false;

                button8.BackColor = Color.Lime;
                button18.BackColor = Color.Lime;
                button28.BackColor = Color.Lime;
                button38.BackColor = Color.Lime;
                button48.BackColor = Color.Lime;
                button58.BackColor = Color.Lime;
                button68.BackColor = Color.Lime;
                button78.BackColor = Color.Lime;
            }
            //norte linea 4 de izq a der
            if (n1[movn + 3] + sumn < 30)
            {
                button7.Enabled = true;
                button17.Enabled = true;
                button27.Enabled = true;
                button37.Enabled = true;
                button47.Enabled = true;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.LightGray;
                button17.BackColor = Color.LightGray;
                button27.BackColor = Color.LightGray;
                button37.BackColor = Color.LightGray;
                button47.BackColor = Color.LightGray;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 31)
            {
                button7.Enabled = false;
                button17.Enabled = true;
                button27.Enabled = true;
                button37.Enabled = true;
                button47.Enabled = true;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.LightGray;
                button27.BackColor = Color.LightGray;
                button37.BackColor = Color.LightGray;
                button47.BackColor = Color.LightGray;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 61)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = true;
                button37.Enabled = true;
                button47.Enabled = true;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.LightGray;
                button37.BackColor = Color.LightGray;
                button47.BackColor = Color.LightGray;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 91)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = true;
                button47.Enabled = true;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.LightGray;
                button47.BackColor = Color.LightGray;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 121)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = false;
                button47.Enabled = true;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.Lime;
                button47.BackColor = Color.LightGray;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 151)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = false;
                button47.Enabled = false;
                button57.Enabled = true;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.Lime;
                button47.BackColor = Color.Lime;
                button57.BackColor = Color.LightGray;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 181)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = false;
                button47.Enabled = false;
                button57.Enabled = false;
                button67.Enabled = true;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.Lime;
                button47.BackColor = Color.Lime;
                button57.BackColor = Color.Lime;
                button67.BackColor = Color.LightGray;
                button77.BackColor = Color.LightGray;
            }
            else if (n1[movn + 3] + sumn < 211)
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = false;
                button47.Enabled = false;
                button57.Enabled = false;
                button67.Enabled = false;
                button77.Enabled = true;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.Lime;
                button47.BackColor = Color.Lime;
                button57.BackColor = Color.Lime;
                button67.BackColor = Color.Lime;
                button77.BackColor = Color.LightGray;
            }
            else
            {
                button7.Enabled = false;
                button17.Enabled = false;
                button27.Enabled = false;
                button37.Enabled = false;
                button47.Enabled = false;
                button57.Enabled = false;
                button67.Enabled = false;
                button77.Enabled = false;

                button7.BackColor = Color.Lime;
                button17.BackColor = Color.Lime;
                button27.BackColor = Color.Lime;
                button37.BackColor = Color.Lime;
                button47.BackColor = Color.Lime;
                button57.BackColor = Color.Lime;
                button67.BackColor = Color.Lime;
                button77.BackColor = Color.Lime;
            }
            //norte linea 5 de izq a der
            if (n1[movn + 4] + sumn < 30)
            {
                button6.Enabled = true;
                button16.Enabled = true;
                button26.Enabled = true;
                button36.Enabled = true;
                button46.Enabled = true;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.LightGray;
                button16.BackColor = Color.LightGray;
                button26.BackColor = Color.LightGray;
                button36.BackColor = Color.LightGray;
                button46.BackColor = Color.LightGray;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;

            }
            else if (n1[movn + 4] + sumn < 31)
            {
                button6.Enabled = false;
                button16.Enabled = true;
                button26.Enabled = true;
                button36.Enabled = true;
                button46.Enabled = true;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.LightGray;
                button26.BackColor = Color.LightGray;
                button36.BackColor = Color.LightGray;
                button46.BackColor = Color.LightGray;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 61)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = true;
                button36.Enabled = true;
                button46.Enabled = true;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.LightGray;
                button36.BackColor = Color.LightGray;
                button46.BackColor = Color.LightGray;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 91)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = true;
                button46.Enabled = true;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.LightGray;
                button46.BackColor = Color.LightGray;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 121)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = false;
                button46.Enabled = true;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.Lime;
                button46.BackColor = Color.LightGray;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 151)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = false;
                button46.Enabled = false;
                button56.Enabled = true;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.Lime;
                button46.BackColor = Color.Lime;
                button56.BackColor = Color.LightGray;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 181)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = false;
                button46.Enabled = false;
                button56.Enabled = false;
                button66.Enabled = true;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.Lime;
                button46.BackColor = Color.Lime;
                button56.BackColor = Color.Lime;
                button66.BackColor = Color.LightGray;
                button76.BackColor = Color.LightGray;
            }
            else if (n1[movn + 4] + sumn < 211)
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = false;
                button46.Enabled = false;
                button56.Enabled = false;
                button66.Enabled = false;
                button76.Enabled = true;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.Lime;
                button46.BackColor = Color.Lime;
                button56.BackColor = Color.Lime;
                button66.BackColor = Color.Lime;
                button76.BackColor = Color.LightGray;
            }
            else
            {
                button6.Enabled = false;
                button16.Enabled = false;
                button26.Enabled = false;
                button36.Enabled = false;
                button46.Enabled = false;
                button56.Enabled = false;
                button66.Enabled = false;
                button76.Enabled = false;

                button6.BackColor = Color.Lime;
                button16.BackColor = Color.Lime;
                button26.BackColor = Color.Lime;
                button36.BackColor = Color.Lime;
                button46.BackColor = Color.Lime;
                button56.BackColor = Color.Lime;
                button66.BackColor = Color.Lime;
                button76.BackColor = Color.Lime;
            }
            //norte linea 6 de izq a der
            if (n1[movn + 5] + sumn < 30)
            {
                button5.Enabled = true;
                button15.Enabled = true;
                button25.Enabled = true;
                button35.Enabled = true;
                button45.Enabled = true;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.LightGray;
                button15.BackColor = Color.LightGray;
                button25.BackColor = Color.LightGray;
                button35.BackColor = Color.LightGray;
                button45.BackColor = Color.LightGray;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;

            }
            else if (n1[movn + 5] + sumn < 31)
            {
                button5.Enabled = false;
                button15.Enabled = true;
                button25.Enabled = true;
                button35.Enabled = true;
                button45.Enabled = true;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.LightGray;
                button25.BackColor = Color.LightGray;
                button35.BackColor = Color.LightGray;
                button45.BackColor = Color.LightGray;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 61)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = true;
                button35.Enabled = true;
                button45.Enabled = true;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.LightGray;
                button35.BackColor = Color.LightGray;
                button45.BackColor = Color.LightGray;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 91)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = true;
                button45.Enabled = true;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.LightGray;
                button45.BackColor = Color.LightGray;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 121)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = false;
                button45.Enabled = true;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.Lime;
                button45.BackColor = Color.LightGray;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 151)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = false;
                button45.Enabled = false;
                button55.Enabled = true;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.Lime;
                button45.BackColor = Color.Lime;
                button55.BackColor = Color.LightGray;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 181)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = false;
                button45.Enabled = false;
                button55.Enabled = false;
                button65.Enabled = true;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.Lime;
                button45.BackColor = Color.Lime;
                button55.BackColor = Color.Lime;
                button65.BackColor = Color.LightGray;
                button75.BackColor = Color.LightGray;
            }
            else if (n1[movn + 5] + sumn < 211)
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = false;
                button45.Enabled = false;
                button55.Enabled = false;
                button65.Enabled = false;
                button75.Enabled = true;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.Lime;
                button45.BackColor = Color.Lime;
                button55.BackColor = Color.Lime;
                button65.BackColor = Color.Lime;
                button75.BackColor = Color.LightGray;
            }
            else
            {
                button5.Enabled = false;
                button15.Enabled = false;
                button25.Enabled = false;
                button35.Enabled = false;
                button45.Enabled = false;
                button55.Enabled = false;
                button65.Enabled = false;
                button75.Enabled = false;

                button5.BackColor = Color.Lime;
                button15.BackColor = Color.Lime;
                button25.BackColor = Color.Lime;
                button35.BackColor = Color.Lime;
                button45.BackColor = Color.Lime;
                button55.BackColor = Color.Lime;
                button65.BackColor = Color.Lime;
                button75.BackColor = Color.Lime;
            }
            //norte linea 7 de izq a der
            if (n1[movn + 6] + sumn < 30)
            {
                button4.Enabled = true;
                button14.Enabled = true;
                button24.Enabled = true;
                button34.Enabled = true;
                button44.Enabled = true;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.LightGray;
                button14.BackColor = Color.LightGray;
                button24.BackColor = Color.LightGray;
                button34.BackColor = Color.LightGray;
                button44.BackColor = Color.LightGray;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 31)
            {
                button4.Enabled = false;
                button14.Enabled = true;
                button24.Enabled = true;
                button34.Enabled = true;
                button44.Enabled = true;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.LightGray;
                button24.BackColor = Color.LightGray;
                button34.BackColor = Color.LightGray;
                button44.BackColor = Color.LightGray;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;

            }
            else if (n1[movn + 6] + sumn < 61)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = true;
                button34.Enabled = true;
                button44.Enabled = true;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.LightGray;
                button34.BackColor = Color.LightGray;
                button44.BackColor = Color.LightGray;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 91)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = true;
                button44.Enabled = true;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.LightGray;
                button44.BackColor = Color.LightGray;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 121)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = false;
                button44.Enabled = true;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.Lime;
                button44.BackColor = Color.LightGray;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 151)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = false;
                button44.Enabled = false;
                button54.Enabled = true;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.Lime;
                button44.BackColor = Color.Lime;
                button54.BackColor = Color.LightGray;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 181)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = false;
                button44.Enabled = false;
                button54.Enabled = false;
                button64.Enabled = true;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.Lime;
                button44.BackColor = Color.Lime;
                button54.BackColor = Color.Lime;
                button64.BackColor = Color.LightGray;
                button74.BackColor = Color.LightGray;
            }
            else if (n1[movn + 6] + sumn < 211)
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = false;
                button44.Enabled = false;
                button54.Enabled = false;
                button64.Enabled = false;
                button74.Enabled = true;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.Lime;
                button44.BackColor = Color.Lime;
                button54.BackColor = Color.Lime;
                button64.BackColor = Color.Lime;
                button74.BackColor = Color.LightGray;
            }
            else
            {
                button4.Enabled = false;
                button14.Enabled = false;
                button24.Enabled = false;
                button34.Enabled = false;
                button44.Enabled = false;
                button54.Enabled = false;
                button64.Enabled = false;
                button74.Enabled = false;

                button4.BackColor = Color.Lime;
                button14.BackColor = Color.Lime;
                button24.BackColor = Color.Lime;
                button34.BackColor = Color.Lime;
                button44.BackColor = Color.Lime;
                button54.BackColor = Color.Lime;
                button64.BackColor = Color.Lime;
                button74.BackColor = Color.Lime;
            }
            //norte linea 8 de izq a der
            if (n1[movn + 7] + sumn < 30)
            {
                button3.Enabled = true;
                button13.Enabled = true;
                button23.Enabled = true;
                button33.Enabled = true;
                button43.Enabled = true;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.LightGray;
                button13.BackColor = Color.LightGray;
                button23.BackColor = Color.LightGray;
                button33.BackColor = Color.LightGray;
                button43.BackColor = Color.LightGray;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 31)
            {
                button3.Enabled = false;
                button13.Enabled = true;
                button23.Enabled = true;
                button33.Enabled = true;
                button43.Enabled = true;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.LightGray;
                button23.BackColor = Color.LightGray;
                button33.BackColor = Color.LightGray;
                button43.BackColor = Color.LightGray;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 61)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = true;
                button33.Enabled = true;
                button43.Enabled = true;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.LightGray;
                button33.BackColor = Color.LightGray;
                button43.BackColor = Color.LightGray;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 91)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = true;
                button43.Enabled = true;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.LightGray;
                button43.BackColor = Color.LightGray;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 121)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = false;
                button43.Enabled = true;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.Lime;
                button43.BackColor = Color.LightGray;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 151)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = false;
                button43.Enabled = false;
                button53.Enabled = true;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.Lime;
                button43.BackColor = Color.Lime;
                button53.BackColor = Color.LightGray;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 181)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = false;
                button43.Enabled = false;
                button53.Enabled = false;
                button63.Enabled = true;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.Lime;
                button43.BackColor = Color.Lime;
                button53.BackColor = Color.Lime;
                button63.BackColor = Color.LightGray;
                button73.BackColor = Color.LightGray;
            }
            else if (n1[movn + 7] + sumn < 211)
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = false;
                button43.Enabled = false;
                button53.Enabled = false;
                button63.Enabled = false;
                button73.Enabled = true;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.Lime;
                button43.BackColor = Color.Lime;
                button53.BackColor = Color.Lime;
                button63.BackColor = Color.Lime;
                button73.BackColor = Color.LightGray;
            }
            else
            {
                button3.Enabled = false;
                button13.Enabled = false;
                button23.Enabled = false;
                button33.Enabled = false;
                button43.Enabled = false;
                button53.Enabled = false;
                button63.Enabled = false;
                button73.Enabled = false;

                button3.BackColor = Color.Lime;
                button13.BackColor = Color.Lime;
                button23.BackColor = Color.Lime;
                button33.BackColor = Color.Lime;
                button43.BackColor = Color.Lime;
                button53.BackColor = Color.Lime;
                button63.BackColor = Color.Lime;
                button73.BackColor = Color.Lime;
            }
            //norte linea 9 de izq a der
            if (n1[movn + 8] + sumn < 30)
            {
                button2.Enabled = true;
                button12.Enabled = true;
                button22.Enabled = true;
                button32.Enabled = true;
                button42.Enabled = true;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.LightGray;
                button12.BackColor = Color.LightGray;
                button22.BackColor = Color.LightGray;
                button32.BackColor = Color.LightGray;
                button42.BackColor = Color.LightGray;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 31)
            {
                button2.Enabled = false;
                button12.Enabled = true;
                button22.Enabled = true;
                button32.Enabled = true;
                button42.Enabled = true;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.LightGray;
                button22.BackColor = Color.LightGray;
                button32.BackColor = Color.LightGray;
                button42.BackColor = Color.LightGray;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 61)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = true;
                button32.Enabled = true;
                button42.Enabled = true;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.LightGray;
                button32.BackColor = Color.LightGray;
                button42.BackColor = Color.LightGray;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 91)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = true;
                button42.Enabled = true;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.LightGray;
                button42.BackColor = Color.LightGray;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 121)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = false;
                button42.Enabled = true;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.Lime;
                button42.BackColor = Color.LightGray;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 151)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = false;
                button42.Enabled = false;
                button52.Enabled = true;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.Lime;
                button42.BackColor = Color.Lime;
                button52.BackColor = Color.LightGray;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 181)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = false;
                button42.Enabled = false;
                button52.Enabled = false;
                button62.Enabled = true;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.Lime;
                button42.BackColor = Color.Lime;
                button52.BackColor = Color.Lime;
                button62.BackColor = Color.LightGray;
                button72.BackColor = Color.LightGray;
            }
            else if (n1[movn + 8] + sumn < 211)
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = false;
                button42.Enabled = false;
                button52.Enabled = false;
                button62.Enabled = false;
                button72.Enabled = true;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.Lime;
                button42.BackColor = Color.Lime;
                button52.BackColor = Color.Lime;
                button62.BackColor = Color.Lime;
                button72.BackColor = Color.LightGray;
            }
            else
            {
                button2.Enabled = false;
                button12.Enabled = false;
                button22.Enabled = false;
                button32.Enabled = false;
                button42.Enabled = false;
                button52.Enabled = false;
                button62.Enabled = false;
                button72.Enabled = false;

                button2.BackColor = Color.Lime;
                button12.BackColor = Color.Lime;
                button22.BackColor = Color.Lime;
                button32.BackColor = Color.Lime;
                button42.BackColor = Color.Lime;
                button52.BackColor = Color.Lime;
                button62.BackColor = Color.Lime;
                button72.BackColor = Color.Lime;
            }
            //norte linea 9 de izq a der
            if (n1[movn + 9] + sumn < 30)
            {
                button1.Enabled = true;
                button11.Enabled = true;
                button21.Enabled = true;
                button31.Enabled = true;
                button41.Enabled = true;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.LightGray;
                button11.BackColor = Color.LightGray;
                button21.BackColor = Color.LightGray;
                button31.BackColor = Color.LightGray;
                button41.BackColor = Color.LightGray;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 31)
            {
                button1.Enabled = false;
                button11.Enabled = true;
                button21.Enabled = true;
                button31.Enabled = true;
                button41.Enabled = true;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.LightGray;
                button21.BackColor = Color.LightGray;
                button31.BackColor = Color.LightGray;
                button41.BackColor = Color.LightGray;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 61)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = true;
                button31.Enabled = true;
                button41.Enabled = true;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.LightGray;
                button31.BackColor = Color.LightGray;
                button41.BackColor = Color.LightGray;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 91)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = true;
                button41.Enabled = true;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.LightGray;
                button41.BackColor = Color.LightGray;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 121)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = false;
                button41.Enabled = true;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.Lime;
                button41.BackColor = Color.LightGray;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 151)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = false;
                button41.Enabled = false;
                button51.Enabled = true;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.Lime;
                button41.BackColor = Color.Lime;
                button51.BackColor = Color.LightGray;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 181)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = false;
                button41.Enabled = false;
                button51.Enabled = false;
                button61.Enabled = true;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.Lime;
                button41.BackColor = Color.Lime;
                button51.BackColor = Color.Lime;
                button61.BackColor = Color.LightGray;
                button71.BackColor = Color.LightGray;
            }
            else if (n1[movn + 9] + sumn < 211)
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = false;
                button41.Enabled = false;
                button51.Enabled = false;
                button61.Enabled = false;
                button71.Enabled = true;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.Lime;
                button41.BackColor = Color.Lime;
                button51.BackColor = Color.Lime;
                button61.BackColor = Color.Lime;
                button71.BackColor = Color.LightGray;
            }
            else
            {
                button1.Enabled = false;
                button11.Enabled = false;
                button21.Enabled = false;
                button31.Enabled = false;
                button41.Enabled = false;
                button51.Enabled = false;
                button61.Enabled = false;
                button71.Enabled = false;

                button1.BackColor = Color.Lime;
                button11.BackColor = Color.Lime;
                button21.BackColor = Color.Lime;
                button31.BackColor = Color.Lime;
                button41.BackColor = Color.Lime;
                button51.BackColor = Color.Lime;
                button61.BackColor = Color.Lime;
                button71.BackColor = Color.Lime;
            }
            //sur linea 1 de izq a der
            if (s1[movs] + sums < 30)
            {
                button90.Enabled = true;
                button100.Enabled = true;
                button110.Enabled = true;
                button120.Enabled = true;
                button130.Enabled = true;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.LightGray;
                button100.BackColor = Color.LightGray;
                button110.BackColor = Color.LightGray;
                button120.BackColor = Color.LightGray;
                button130.BackColor = Color.LightGray;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 31)
            {
                button90.Enabled = false;
                button100.Enabled = true;
                button110.Enabled = true;
                button120.Enabled = true;
                button130.Enabled = true;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.LightGray;
                button110.BackColor = Color.LightGray;
                button120.BackColor = Color.LightGray;
                button130.BackColor = Color.LightGray;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 61)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = true;
                button120.Enabled = true;
                button130.Enabled = true;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.LightGray;
                button120.BackColor = Color.LightGray;
                button130.BackColor = Color.LightGray;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 91)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = true;
                button130.Enabled = true;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.LightGray;
                button130.BackColor = Color.LightGray;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 121)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = false;
                button130.Enabled = true;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.Lime;
                button130.BackColor = Color.LightGray;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 151)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = false;
                button130.Enabled = false;
                button140.Enabled = true;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.Lime;
                button130.BackColor = Color.Lime;
                button140.BackColor = Color.LightGray;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 181)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = false;
                button130.Enabled = false;
                button140.Enabled = false;
                button150.Enabled = true;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.Lime;
                button130.BackColor = Color.Lime;
                button140.BackColor = Color.Lime;
                button150.BackColor = Color.LightGray;
                button160.BackColor = Color.LightGray;
            }
            else if (s1[movs] + sums < 211)
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = false;
                button130.Enabled = false;
                button140.Enabled = false;
                button150.Enabled = false;
                button160.Enabled = true;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.Lime;
                button130.BackColor = Color.Lime;
                button140.BackColor = Color.Lime;
                button150.BackColor = Color.Lime;
                button160.BackColor = Color.LightGray;
            }
            else
            {
                button90.Enabled = false;
                button100.Enabled = false;
                button110.Enabled = false;
                button120.Enabled = false;
                button130.Enabled = false;
                button140.Enabled = false;
                button150.Enabled = false;
                button160.Enabled = false;

                button90.BackColor = Color.Lime;
                button100.BackColor = Color.Lime;
                button110.BackColor = Color.Lime;
                button120.BackColor = Color.Lime;
                button130.BackColor = Color.Lime;
                button140.BackColor = Color.Lime;
                button150.BackColor = Color.Lime;
                button160.BackColor = Color.Lime;
            }
            //sur linea 2 de izq a der
            if (s1[movs + 1] + sums < 30)
            {
                button89.Enabled = true;
                button99.Enabled = true;
                button109.Enabled = true;
                button119.Enabled = true;
                button129.Enabled = true;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.LightGray;
                button99.BackColor = Color.LightGray;
                button109.BackColor = Color.LightGray;
                button119.BackColor = Color.LightGray;
                button129.BackColor = Color.LightGray;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 31)
            {
                button89.Enabled = false;
                button99.Enabled = true;
                button109.Enabled = true;
                button119.Enabled = true;
                button129.Enabled = true;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.LightGray;
                button109.BackColor = Color.LightGray;
                button119.BackColor = Color.LightGray;
                button129.BackColor = Color.LightGray;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 61)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = true;
                button119.Enabled = true;
                button129.Enabled = true;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.LightGray;
                button119.BackColor = Color.LightGray;
                button129.BackColor = Color.LightGray;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 91)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = true;
                button129.Enabled = true;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.LightGray;
                button129.BackColor = Color.LightGray;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 121)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = false;
                button129.Enabled = true;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.Lime;
                button129.BackColor = Color.LightGray;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 151)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = false;
                button129.Enabled = false;
                button139.Enabled = true;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.Lime;
                button129.BackColor = Color.Lime;
                button139.BackColor = Color.LightGray;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 181)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = false;
                button129.Enabled = false;
                button139.Enabled = false;
                button149.Enabled = true;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.Lime;
                button129.BackColor = Color.Lime;
                button139.BackColor = Color.Lime;
                button149.BackColor = Color.LightGray;
                button159.BackColor = Color.LightGray;
            }
            else if (s1[movs + 1] + sums < 211)
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = false;
                button129.Enabled = false;
                button139.Enabled = false;
                button149.Enabled = false;
                button159.Enabled = true;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.Lime;
                button129.BackColor = Color.Lime;
                button139.BackColor = Color.Lime;
                button149.BackColor = Color.Lime;
                button159.BackColor = Color.LightGray;
            }
            else
            {
                button89.Enabled = false;
                button99.Enabled = false;
                button109.Enabled = false;
                button119.Enabled = false;
                button129.Enabled = false;
                button139.Enabled = false;
                button149.Enabled = false;
                button159.Enabled = false;

                button89.BackColor = Color.Lime;
                button99.BackColor = Color.Lime;
                button109.BackColor = Color.Lime;
                button119.BackColor = Color.Lime;
                button129.BackColor = Color.Lime;
                button139.BackColor = Color.Lime;
                button149.BackColor = Color.Lime;
                button159.BackColor = Color.Lime;
            }
            //sur linea 3 de izq a der
            if (s1[movs + 2] + sums < 30)
            {
                button88.Enabled = true;
                button98.Enabled = true;
                button108.Enabled = true;
                button118.Enabled = true;
                button128.Enabled = true;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.LightGray;
                button98.BackColor = Color.LightGray;
                button108.BackColor = Color.LightGray;
                button118.BackColor = Color.LightGray;
                button128.BackColor = Color.LightGray;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 31)
            {
                button88.Enabled = false;
                button98.Enabled = true;
                button108.Enabled = true;
                button118.Enabled = true;
                button128.Enabled = true;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.LightGray;
                button108.BackColor = Color.LightGray;
                button118.BackColor = Color.LightGray;
                button128.BackColor = Color.LightGray;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 61)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = true;
                button118.Enabled = true;
                button128.Enabled = true;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.LightGray;
                button118.BackColor = Color.LightGray;
                button128.BackColor = Color.LightGray;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 91)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = true;
                button128.Enabled = true;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.LightGray;
                button128.BackColor = Color.LightGray;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 121)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = false;
                button128.Enabled = true;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.Lime;
                button128.BackColor = Color.LightGray;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 151)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = false;
                button128.Enabled = false;
                button138.Enabled = true;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.Lime;
                button128.BackColor = Color.Lime;
                button138.BackColor = Color.LightGray;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 181)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = false;
                button128.Enabled = false;
                button138.Enabled = false;
                button148.Enabled = true;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.Lime;
                button128.BackColor = Color.Lime;
                button138.BackColor = Color.Lime;
                button148.BackColor = Color.LightGray;
                button158.BackColor = Color.LightGray;
            }
            else if (s1[movs + 2] + sums < 211)
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = false;
                button128.Enabled = false;
                button138.Enabled = false;
                button148.Enabled = false;
                button158.Enabled = true;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.Lime;
                button128.BackColor = Color.Lime;
                button138.BackColor = Color.Lime;
                button148.BackColor = Color.Lime;
                button158.BackColor = Color.LightGray;
            }
            else
            {
                button88.Enabled = false;
                button98.Enabled = false;
                button108.Enabled = false;
                button118.Enabled = false;
                button128.Enabled = false;
                button138.Enabled = false;
                button148.Enabled = false;
                button158.Enabled = false;

                button88.BackColor = Color.Lime;
                button98.BackColor = Color.Lime;
                button108.BackColor = Color.Lime;
                button118.BackColor = Color.Lime;
                button128.BackColor = Color.Lime;
                button138.BackColor = Color.Lime;
                button148.BackColor = Color.Lime;
                button158.BackColor = Color.Lime;
            }
            //sur linea 4 de izq a der
            if (s1[movs + 3] + sums < 30)
            {
                button87.Enabled = true;
                button97.Enabled = true;
                button107.Enabled = true;
                button117.Enabled = true;
                button127.Enabled = true;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.LightGray;
                button97.BackColor = Color.LightGray;
                button107.BackColor = Color.LightGray;
                button117.BackColor = Color.LightGray;
                button127.BackColor = Color.LightGray;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 31)
            {
                button87.Enabled = false;
                button97.Enabled = true;
                button107.Enabled = true;
                button117.Enabled = true;
                button127.Enabled = true;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.LightGray;
                button107.BackColor = Color.LightGray;
                button117.BackColor = Color.LightGray;
                button127.BackColor = Color.LightGray;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 61)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = true;
                button117.Enabled = true;
                button127.Enabled = true;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.LightGray;
                button117.BackColor = Color.LightGray;
                button127.BackColor = Color.LightGray;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 91)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = true;
                button127.Enabled = true;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.LightGray;
                button127.BackColor = Color.LightGray;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 121)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = false;
                button127.Enabled = true;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.Lime;
                button127.BackColor = Color.LightGray;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 151)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = false;
                button127.Enabled = false;
                button137.Enabled = true;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.Lime;
                button127.BackColor = Color.Lime;
                button137.BackColor = Color.LightGray;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 181)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = false;
                button127.Enabled = false;
                button137.Enabled = false;
                button147.Enabled = true;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.Lime;
                button127.BackColor = Color.Lime;
                button137.BackColor = Color.Lime;
                button147.BackColor = Color.LightGray;
                button157.BackColor = Color.LightGray;
            }
            else if (s1[movs + 3] + sums < 211)
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = false;
                button127.Enabled = false;
                button137.Enabled = false;
                button147.Enabled = false;
                button157.Enabled = true;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.Lime;
                button127.BackColor = Color.Lime;
                button137.BackColor = Color.Lime;
                button147.BackColor = Color.Lime;
                button157.BackColor = Color.LightGray;
            }
            else
            {
                button87.Enabled = false;
                button97.Enabled = false;
                button107.Enabled = false;
                button117.Enabled = false;
                button127.Enabled = false;
                button137.Enabled = false;
                button147.Enabled = false;
                button157.Enabled = false;

                button87.BackColor = Color.Lime;
                button97.BackColor = Color.Lime;
                button107.BackColor = Color.Lime;
                button117.BackColor = Color.Lime;
                button127.BackColor = Color.Lime;
                button137.BackColor = Color.Lime;
                button147.BackColor = Color.Lime;
                button157.BackColor = Color.Lime;
            }
            //sur linea 5 de izq a der
            if (s1[movs + 4] + sums < 30)
            {
                button86.Enabled = true;
                button96.Enabled = true;
                button106.Enabled = true;
                button116.Enabled = true;
                button126.Enabled = true;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.LightGray;
                button96.BackColor = Color.LightGray;
                button106.BackColor = Color.LightGray;
                button116.BackColor = Color.LightGray;
                button126.BackColor = Color.LightGray;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 31)
            {
                button86.Enabled = false;
                button96.Enabled = true;
                button106.Enabled = true;
                button116.Enabled = true;
                button126.Enabled = true;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.LightGray;
                button106.BackColor = Color.LightGray;
                button116.BackColor = Color.LightGray;
                button126.BackColor = Color.LightGray;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 61)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = true;
                button116.Enabled = true;
                button126.Enabled = true;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.Lime;
                button106.BackColor = Color.LightGray;
                button116.BackColor = Color.LightGray;
                button126.BackColor = Color.LightGray;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 91)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = true;
                button126.Enabled = true;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.LightGray;
                button126.BackColor = Color.LightGray;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 121)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = false;
                button126.Enabled = true;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.Lime;
                button126.BackColor = Color.LightGray;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 151)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = false;
                button126.Enabled = false;
                button136.Enabled = true;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.Lime;
                button126.BackColor = Color.Lime;
                button136.BackColor = Color.LightGray;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 181)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = false;
                button126.Enabled = false;
                button136.Enabled = false;
                button146.Enabled = true;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button96.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.Lime;
                button126.BackColor = Color.Lime;
                button136.BackColor = Color.Lime;
                button146.BackColor = Color.LightGray;
                button156.BackColor = Color.LightGray;
            }
            else if (s1[movs + 4] + sums < 211)
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = false;
                button126.Enabled = false;
                button136.Enabled = false;
                button146.Enabled = false;
                button156.Enabled = true;

                button86.BackColor = Color.Lime;
                button86.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.Lime;
                button126.BackColor = Color.Lime;
                button136.BackColor = Color.Lime;
                button146.BackColor = Color.Lime;
                button156.BackColor = Color.LightGray;
            }
            else
            {
                button86.Enabled = false;
                button96.Enabled = false;
                button106.Enabled = false;
                button116.Enabled = false;
                button126.Enabled = false;
                button136.Enabled = false;
                button146.Enabled = false;
                button156.Enabled = false;

                button86.BackColor = Color.Lime;
                button86.BackColor = Color.Lime;
                button106.BackColor = Color.Lime;
                button116.BackColor = Color.Lime;
                button126.BackColor = Color.Lime;
                button136.BackColor = Color.Lime;
                button146.BackColor = Color.Lime;
                button156.BackColor = Color.Lime;
            }
            //sur linea 6 de izq a der
            if (s1[movs + 5] + sums < 30)
            {
                button85.Enabled = true;
                button95.Enabled = true;
                button105.Enabled = true;
                button115.Enabled = true;
                button125.Enabled = true;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.LightGray;
                button95.BackColor = Color.LightGray;
                button105.BackColor = Color.LightGray;
                button115.BackColor = Color.LightGray;
                button125.BackColor = Color.LightGray;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 31)
            {
                button85.Enabled = false;
                button95.Enabled = true;
                button105.Enabled = true;
                button115.Enabled = true;
                button125.Enabled = true;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.LightGray;
                button105.BackColor = Color.LightGray;
                button115.BackColor = Color.LightGray;
                button125.BackColor = Color.LightGray;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 61)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = true;
                button115.Enabled = true;
                button125.Enabled = true;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.LightGray;
                button115.BackColor = Color.LightGray;
                button125.BackColor = Color.LightGray;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 91)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = true;
                button125.Enabled = true;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.LightGray;
                button125.BackColor = Color.LightGray;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 121)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = false;
                button125.Enabled = true;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.Lime;
                button125.BackColor = Color.LightGray;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 151)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = false;
                button125.Enabled = false;
                button135.Enabled = true;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.Lime;
                button125.BackColor = Color.Lime;
                button135.BackColor = Color.LightGray;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 181)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = false;
                button125.Enabled = false;
                button135.Enabled = false;
                button145.Enabled = true;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.Lime;
                button125.BackColor = Color.Lime;
                button135.BackColor = Color.Lime;
                button145.BackColor = Color.LightGray;
                button155.BackColor = Color.LightGray;
            }
            else if (s1[movs + 5] + sums < 211)
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = false;
                button125.Enabled = false;
                button135.Enabled = false;
                button145.Enabled = false;
                button155.Enabled = true;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.Lime;
                button125.BackColor = Color.Lime;
                button135.BackColor = Color.Lime;
                button145.BackColor = Color.Lime;
                button155.BackColor = Color.LightGray;
            }
            else
            {
                button85.Enabled = false;
                button95.Enabled = false;
                button105.Enabled = false;
                button115.Enabled = false;
                button125.Enabled = false;
                button135.Enabled = false;
                button145.Enabled = false;
                button155.Enabled = false;

                button85.BackColor = Color.Lime;
                button95.BackColor = Color.Lime;
                button105.BackColor = Color.Lime;
                button115.BackColor = Color.Lime;
                button125.BackColor = Color.Lime;
                button135.BackColor = Color.Lime;
                button145.BackColor = Color.Lime;
                button155.BackColor = Color.Lime;
            }
            //sur linea 7 de izq a der
            if (s1[movs + 6] + sums < 30)
            {
                button84.Enabled = true;
                button94.Enabled = true;
                button104.Enabled = true;
                button114.Enabled = true;
                button124.Enabled = true;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.LightGray;
                button94.BackColor = Color.LightGray;
                button104.BackColor = Color.LightGray;
                button114.BackColor = Color.LightGray;
                button124.BackColor = Color.LightGray;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 31)
            {
                button84.Enabled = false;
                button94.Enabled = true;
                button104.Enabled = true;
                button114.Enabled = true;
                button124.Enabled = true;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.LightGray;
                button104.BackColor = Color.LightGray;
                button114.BackColor = Color.LightGray;
                button124.BackColor = Color.LightGray;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 61)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = true;
                button114.Enabled = true;
                button124.Enabled = true;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.LightGray;
                button114.BackColor = Color.LightGray;
                button124.BackColor = Color.LightGray;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 91)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = true;
                button124.Enabled = true;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.LightGray;
                button124.BackColor = Color.LightGray;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 121)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = false;
                button124.Enabled = true;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.Lime;
                button124.BackColor = Color.LightGray;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 151)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = false;
                button124.Enabled = false;
                button134.Enabled = true;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.Lime;
                button124.BackColor = Color.Lime;
                button134.BackColor = Color.LightGray;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 181)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = false;
                button124.Enabled = false;
                button134.Enabled = false;
                button144.Enabled = true;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.Lime;
                button124.BackColor = Color.Lime;
                button134.BackColor = Color.Lime;
                button144.BackColor = Color.LightGray;
                button154.BackColor = Color.LightGray;
            }
            else if (s1[movs + 6] + sums < 211)
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = false;
                button124.Enabled = false;
                button134.Enabled = false;
                button144.Enabled = false;
                button154.Enabled = true;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.Lime;
                button124.BackColor = Color.Lime;
                button134.BackColor = Color.Lime;
                button144.BackColor = Color.Lime;
                button154.BackColor = Color.LightGray;
            }
            else
            {
                button84.Enabled = false;
                button94.Enabled = false;
                button104.Enabled = false;
                button114.Enabled = false;
                button124.Enabled = false;
                button134.Enabled = false;
                button144.Enabled = false;
                button154.Enabled = false;

                button84.BackColor = Color.Lime;
                button94.BackColor = Color.Lime;
                button104.BackColor = Color.Lime;
                button114.BackColor = Color.Lime;
                button124.BackColor = Color.Lime;
                button134.BackColor = Color.Lime;
                button144.BackColor = Color.Lime;
                button154.BackColor = Color.Lime;
            }
            // sur linea 8 de izq a der
            if (s1[movs + 7] + sums < 30)
            {
                button83.Enabled = true;
                button93.Enabled = true;
                button103.Enabled = true;
                button113.Enabled = true;
                button123.Enabled = true;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.LightGray;
                button93.BackColor = Color.LightGray;
                button103.BackColor = Color.LightGray;
                button113.BackColor = Color.LightGray;
                button123.BackColor = Color.LightGray;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;

            }
            else if (s1[movs + 7] + sums < 31)
            {
                button83.Enabled = false;
                button93.Enabled = true;
                button103.Enabled = true;
                button113.Enabled = true;
                button123.Enabled = true;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.LightGray;
                button103.BackColor = Color.LightGray;
                button113.BackColor = Color.LightGray;
                button123.BackColor = Color.LightGray;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 61)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = true;
                button113.Enabled = true;
                button123.Enabled = true;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.LightGray;
                button113.BackColor = Color.LightGray;
                button123.BackColor = Color.LightGray;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 91)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = true;
                button123.Enabled = true;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.LightGray;
                button123.BackColor = Color.LightGray;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 121)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = false;
                button123.Enabled = true;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.Lime;
                button123.BackColor = Color.LightGray;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 151)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = false;
                button123.Enabled = false;
                button133.Enabled = true;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.Lime;
                button123.BackColor = Color.Lime;
                button133.BackColor = Color.LightGray;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 181)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = false;
                button123.Enabled = false;
                button133.Enabled = false;
                button143.Enabled = true;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.Lime;
                button123.BackColor = Color.Lime;
                button133.BackColor = Color.Lime;
                button143.BackColor = Color.LightGray;
                button153.BackColor = Color.LightGray;
            }
            else if (s1[movs + 7] + sums < 211)
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = false;
                button123.Enabled = false;
                button133.Enabled = false;
                button143.Enabled = false;
                button153.Enabled = true;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.Lime;
                button123.BackColor = Color.Lime;
                button133.BackColor = Color.Lime;
                button143.BackColor = Color.Lime;
                button153.BackColor = Color.LightGray;
            }
            else
            {
                button83.Enabled = false;
                button93.Enabled = false;
                button103.Enabled = false;
                button113.Enabled = false;
                button123.Enabled = false;
                button133.Enabled = false;
                button143.Enabled = false;
                button153.Enabled = false;

                button83.BackColor = Color.Lime;
                button93.BackColor = Color.Lime;
                button103.BackColor = Color.Lime;
                button113.BackColor = Color.Lime;
                button123.BackColor = Color.Lime;
                button133.BackColor = Color.Lime;
                button143.BackColor = Color.Lime;
                button153.BackColor = Color.Lime;
            }
            // sur linea 9 de izq a der
            if (s1[movs + 8] + sums < 30)
            {
                button82.Enabled = true;
                button92.Enabled = true;
                button102.Enabled = true;
                button112.Enabled = true;
                button122.Enabled = true;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.LightGray;
                button92.BackColor = Color.LightGray;
                button102.BackColor = Color.LightGray;
                button112.BackColor = Color.LightGray;
                button122.BackColor = Color.LightGray;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 31)
            {
                button82.Enabled = false;
                button92.Enabled = true;
                button102.Enabled = true;
                button112.Enabled = true;
                button122.Enabled = true;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.LightGray;
                button102.BackColor = Color.LightGray;
                button112.BackColor = Color.LightGray;
                button122.BackColor = Color.LightGray;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 61)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = true;
                button112.Enabled = true;
                button122.Enabled = true;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.LightGray;
                button112.BackColor = Color.LightGray;
                button122.BackColor = Color.LightGray;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 91)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = true;
                button122.Enabled = true;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.LightGray;
                button122.BackColor = Color.LightGray;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 121)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = false;
                button122.Enabled = true;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.Lime;
                button122.BackColor = Color.LightGray;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 151)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = false;
                button122.Enabled = false;
                button132.Enabled = true;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.Lime;
                button122.BackColor = Color.Lime;
                button132.BackColor = Color.LightGray;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 181)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = false;
                button122.Enabled = false;
                button132.Enabled = false;
                button142.Enabled = true;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.Lime;
                button122.BackColor = Color.Lime;
                button132.BackColor = Color.Lime;
                button142.BackColor = Color.LightGray;
                button152.BackColor = Color.LightGray;
            }
            else if (s1[movs + 8] + sums < 211)
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = false;
                button122.Enabled = false;
                button132.Enabled = false;
                button142.Enabled = false;
                button152.Enabled = true;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.Lime;
                button122.BackColor = Color.Lime;
                button132.BackColor = Color.Lime;
                button142.BackColor = Color.Lime;
                button152.BackColor = Color.LightGray;
            }
            else
            {
                button82.Enabled = false;
                button92.Enabled = false;
                button102.Enabled = false;
                button112.Enabled = false;
                button122.Enabled = false;
                button132.Enabled = false;
                button142.Enabled = false;
                button152.Enabled = false;

                button82.BackColor = Color.Lime;
                button92.BackColor = Color.Lime;
                button102.BackColor = Color.Lime;
                button112.BackColor = Color.Lime;
                button122.BackColor = Color.Lime;
                button132.BackColor = Color.Lime;
                button142.BackColor = Color.Lime;
                button152.BackColor = Color.Lime;
            }
            // sur linea 10 de izq a der
            if (s1[movs + 9] + sums < 30)
            {
                button81.Enabled = true;
                button91.Enabled = true;
                button101.Enabled = true;
                button111.Enabled = true;
                button121.Enabled = true;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.LightGray;
                button91.BackColor = Color.LightGray;
                button101.BackColor = Color.LightGray;
                button111.BackColor = Color.LightGray;
                button121.BackColor = Color.LightGray;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 31)
            {
                button81.Enabled = false;
                button91.Enabled = true;
                button101.Enabled = true;
                button111.Enabled = true;
                button121.Enabled = true;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.LightGray;
                button101.BackColor = Color.LightGray;
                button111.BackColor = Color.LightGray;
                button121.BackColor = Color.LightGray;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 61)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = true;
                button111.Enabled = true;
                button121.Enabled = true;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.LightGray;
                button111.BackColor = Color.LightGray;
                button121.BackColor = Color.LightGray;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 91)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = true;
                button121.Enabled = true;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.LightGray;
                button121.BackColor = Color.LightGray;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 121)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = false;
                button121.Enabled = true;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.Lime;
                button121.BackColor = Color.LightGray;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 151)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = false;
                button121.Enabled = false;
                button131.Enabled = true;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.Lime;
                button121.BackColor = Color.Lime;
                button131.BackColor = Color.LightGray;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 181)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = false;
                button121.Enabled = false;
                button131.Enabled = false;
                button141.Enabled = true;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.Lime;
                button121.BackColor = Color.Lime;
                button131.BackColor = Color.Lime;
                button141.BackColor = Color.LightGray;
                button151.BackColor = Color.LightGray;
            }
            else if (s1[movs + 9] + sums < 211)
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = false;
                button121.Enabled = false;
                button131.Enabled = false;
                button141.Enabled = false;
                button151.Enabled = true;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.Lime;
                button121.BackColor = Color.Lime;
                button131.BackColor = Color.Lime;
                button141.BackColor = Color.Lime;
                button151.BackColor = Color.LightGray;
            }
            else
            {
                button81.Enabled = false;
                button91.Enabled = false;
                button101.Enabled = false;
                button111.Enabled = false;
                button121.Enabled = false;
                button131.Enabled = false;
                button141.Enabled = false;
                button151.Enabled = false;

                button81.BackColor = Color.Lime;
                button91.BackColor = Color.Lime;
                button101.BackColor = Color.Lime;
                button111.BackColor = Color.Lime;
                button121.BackColor = Color.Lime;
                button131.BackColor = Color.Lime;
                button141.BackColor = Color.Lime;
                button151.BackColor = Color.Lime;
            }
            // este linea 1 de izq a der
            if (es1[moves] + sumes < 30)
            {
                button240.Enabled = true;
                button230.Enabled = true;
                button220.Enabled = true;
                button210.Enabled = true;
                button200.Enabled = true;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.LightGray;
                button230.BackColor = Color.LightGray;
                button220.BackColor = Color.LightGray;
                button210.BackColor = Color.LightGray;
                button200.BackColor = Color.LightGray;
                button190.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;

            }
            else if (es1[moves] + sumes < 31)
            {
                button240.Enabled = false;
                button230.Enabled = true;
                button220.Enabled = true;
                button210.Enabled = true;
                button200.Enabled = true;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.LightGray;
                button220.BackColor = Color.LightGray;
                button210.BackColor = Color.LightGray;
                button200.BackColor = Color.LightGray;
                button190.BackColor = Color.LightGray;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 61)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = true;
                button210.Enabled = true;
                button200.Enabled = true;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.LightGray;
                button210.BackColor = Color.LightGray;
                button200.BackColor = Color.LightGray;
                button190.BackColor = Color.LightGray;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 91)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = true;
                button200.Enabled = true;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.LightGray;
                button200.BackColor = Color.LightGray;
                button190.BackColor = Color.LightGray;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 121)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = false;
                button200.Enabled = true;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.Lime;
                button200.BackColor = Color.LightGray;
                button190.BackColor = Color.LightGray;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 151)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = false;
                button200.Enabled = false;
                button190.Enabled = true;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.Lime;
                button200.BackColor = Color.Lime;
                button190.BackColor = Color.LightGray;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 181)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = false;
                button200.Enabled = false;
                button190.Enabled = false;
                button180.Enabled = true;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.Lime;
                button200.BackColor = Color.Lime;
                button190.BackColor = Color.Lime;
                button180.BackColor = Color.LightGray;
                button170.BackColor = Color.LightGray;
            }
            else if (es1[moves] + sumes < 211)
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = false;
                button200.Enabled = false;
                button190.Enabled = false;
                button180.Enabled = false;
                button170.Enabled = true;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.Lime;
                button200.BackColor = Color.Lime;
                button190.BackColor = Color.Lime;
                button180.BackColor = Color.Lime;
                button170.BackColor = Color.LightGray;
            }
            else
            {
                button240.Enabled = false;
                button230.Enabled = false;
                button220.Enabled = false;
                button210.Enabled = false;
                button200.Enabled = false;
                button190.Enabled = false;
                button180.Enabled = false;
                button170.Enabled = false;

                button240.BackColor = Color.Lime;
                button230.BackColor = Color.Lime;
                button220.BackColor = Color.Lime;
                button210.BackColor = Color.Lime;
                button200.BackColor = Color.Lime;
                button190.BackColor = Color.Lime;
                button180.BackColor = Color.Lime;
                button170.BackColor = Color.Lime;
            }
            // este linea 1 de izq a der
            if (es1[moves + 1] + sumes < 30)
            {
                button239.Enabled = true;
                button229.Enabled = true;
                button219.Enabled = true;
                button209.Enabled = true;
                button199.Enabled = true;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.LightGray;
                button229.BackColor = Color.LightGray;
                button219.BackColor = Color.LightGray;
                button209.BackColor = Color.LightGray;
                button199.BackColor = Color.LightGray;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 31)
            {
                button239.Enabled = false;
                button229.Enabled = true;
                button219.Enabled = true;
                button209.Enabled = true;
                button199.Enabled = true;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.LightGray;
                button219.BackColor = Color.LightGray;
                button209.BackColor = Color.LightGray;
                button199.BackColor = Color.LightGray;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 61)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = true;
                button209.Enabled = true;
                button199.Enabled = true;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.LightGray;
                button209.BackColor = Color.LightGray;
                button199.BackColor = Color.LightGray;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 91)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = true;
                button199.Enabled = true;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.LightGray;
                button199.BackColor = Color.LightGray;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 121)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = false;
                button199.Enabled = true;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.Lime;
                button199.BackColor = Color.LightGray;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 151)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = false;
                button199.Enabled = false;
                button189.Enabled = true;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.Lime;
                button199.BackColor = Color.Lime;
                button189.BackColor = Color.LightGray;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 181)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = false;
                button199.Enabled = false;
                button189.Enabled = false;
                button179.Enabled = true;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.Lime;
                button199.BackColor = Color.Lime;
                button189.BackColor = Color.Lime;
                button179.BackColor = Color.LightGray;
                button169.BackColor = Color.LightGray;
            }
            else if (es1[moves + 1] + sumes < 211)
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = false;
                button199.Enabled = false;
                button189.Enabled = false;
                button179.Enabled = false;
                button169.Enabled = true;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.Lime;
                button199.BackColor = Color.Lime;
                button189.BackColor = Color.Lime;
                button179.BackColor = Color.Lime;
                button169.BackColor = Color.LightGray;
            }
            else
            {
                button239.Enabled = false;
                button229.Enabled = false;
                button219.Enabled = false;
                button209.Enabled = false;
                button199.Enabled = false;
                button189.Enabled = false;
                button179.Enabled = false;
                button169.Enabled = false;

                button239.BackColor = Color.Lime;
                button229.BackColor = Color.Lime;
                button219.BackColor = Color.Lime;
                button209.BackColor = Color.Lime;
                button199.BackColor = Color.Lime;
                button189.BackColor = Color.Lime;
                button179.BackColor = Color.Lime;
                button169.BackColor = Color.Lime;
            }
            // este linea 3 de izq a der
            if (es1[moves + 2] + sumes < 30)
            {
                button238.Enabled = true;
                button228.Enabled = true;
                button218.Enabled = true;
                button208.Enabled = true;
                button198.Enabled = true;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.LightGray;
                button228.BackColor = Color.LightGray;
                button218.BackColor = Color.LightGray;
                button208.BackColor = Color.LightGray;
                button198.BackColor = Color.LightGray;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 31)
            {
                button238.Enabled = false;
                button228.Enabled = true;
                button218.Enabled = true;
                button208.Enabled = true;
                button198.Enabled = true;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.LightGray;
                button218.BackColor = Color.LightGray;
                button208.BackColor = Color.LightGray;
                button198.BackColor = Color.LightGray;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 61)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = true;
                button208.Enabled = true;
                button198.Enabled = true;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.LightGray;
                button208.BackColor = Color.LightGray;
                button198.BackColor = Color.LightGray;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 91)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = true;
                button198.Enabled = true;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.LightGray;
                button198.BackColor = Color.LightGray;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 121)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = false;
                button198.Enabled = true;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.Lime;
                button198.BackColor = Color.LightGray;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;

            }
            else if (es1[moves + 2] + sumes < 151)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = false;
                button198.Enabled = false;
                button188.Enabled = true;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.Lime;
                button198.BackColor = Color.Lime;
                button188.BackColor = Color.LightGray;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 181)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = false;
                button198.Enabled = false;
                button188.Enabled = false;
                button178.Enabled = true;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.Lime;
                button198.BackColor = Color.Lime;
                button188.BackColor = Color.Lime;
                button178.BackColor = Color.LightGray;
                button168.BackColor = Color.LightGray;
            }
            else if (es1[moves + 2] + sumes < 211)
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = false;
                button198.Enabled = false;
                button188.Enabled = false;
                button178.Enabled = false;
                button168.Enabled = true;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.Lime;
                button198.BackColor = Color.Lime;
                button188.BackColor = Color.Lime;
                button178.BackColor = Color.Lime;
                button168.BackColor = Color.LightGray;
            }
            else
            {
                button238.Enabled = false;
                button228.Enabled = false;
                button218.Enabled = false;
                button208.Enabled = false;
                button198.Enabled = false;
                button188.Enabled = false;
                button178.Enabled = false;
                button168.Enabled = false;

                button238.BackColor = Color.Lime;
                button228.BackColor = Color.Lime;
                button218.BackColor = Color.Lime;
                button208.BackColor = Color.Lime;
                button198.BackColor = Color.Lime;
                button188.BackColor = Color.Lime;
                button178.BackColor = Color.Lime;
                button168.BackColor = Color.Lime;
            }
            // este linea 4 de izq a der
            if (es1[moves + 3] + sumes < 30)
            {
                button237.Enabled = true;
                button227.Enabled = true;
                button217.Enabled = true;
                button207.Enabled = true;
                button197.Enabled = true;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.LightGray;
                button227.BackColor = Color.LightGray;
                button217.BackColor = Color.LightGray;
                button207.BackColor = Color.LightGray;
                button197.BackColor = Color.LightGray;
                button187.BackColor = Color.LightGray;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 31)
            {
                button237.Enabled = false;
                button227.Enabled = true;
                button217.Enabled = true;
                button207.Enabled = true;
                button197.Enabled = true;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.LightGray;
                button217.BackColor = Color.LightGray;
                button207.BackColor = Color.LightGray;
                button197.BackColor = Color.LightGray;
                button187.BackColor = Color.LightGray;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 61)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = true;
                button207.Enabled = true;
                button197.Enabled = true;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.LightGray;
                button207.BackColor = Color.LightGray;
                button197.BackColor = Color.LightGray;
                button187.BackColor = Color.LightGray;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 91)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = true;
                button197.Enabled = true;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.LightGray;
                button197.BackColor = Color.LightGray;
                button187.BackColor = Color.LightGray;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 121)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = false;
                button197.Enabled = true;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.Lime;
                button197.BackColor = Color.Lime;
                button187.BackColor = Color.Lime;
                button177.BackColor = Color.Lime;
                button167.BackColor = Color.Lime;
            }
            else if (es1[moves + 3] + sumes < 151)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = false;
                button197.Enabled = false;
                button187.Enabled = true;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.Lime;
                button197.BackColor = Color.Lime;
                button187.BackColor = Color.LightGray;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 181)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = false;
                button197.Enabled = false;
                button187.Enabled = false;
                button177.Enabled = true;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.Lime;
                button197.BackColor = Color.Lime;
                button187.BackColor = Color.Lime;
                button177.BackColor = Color.LightGray;
                button167.BackColor = Color.LightGray;
            }
            else if (es1[moves + 3] + sumes < 211)
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = false;
                button197.Enabled = false;
                button187.Enabled = false;
                button177.Enabled = false;
                button167.Enabled = true;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.Lime;
                button197.BackColor = Color.Lime;
                button187.BackColor = Color.Lime;
                button177.BackColor = Color.Lime;
                button167.BackColor = Color.LightGray;
            }
            else
            {
                button237.Enabled = false;
                button227.Enabled = false;
                button217.Enabled = false;
                button207.Enabled = false;
                button197.Enabled = false;
                button187.Enabled = false;
                button177.Enabled = false;
                button167.Enabled = false;

                button237.BackColor = Color.Lime;
                button227.BackColor = Color.Lime;
                button217.BackColor = Color.Lime;
                button207.BackColor = Color.Lime;
                button197.BackColor = Color.Lime;
                button187.BackColor = Color.Lime;
                button177.BackColor = Color.Lime;
                button167.BackColor = Color.Lime;
            }
            // este linea 5 de izq a der
            if (es1[moves + 4] + sumes < 30)
            {
                button236.Enabled = true;
                button226.Enabled = true;
                button216.Enabled = true;
                button206.Enabled = true;
                button196.Enabled = true;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.LightGray;
                button226.BackColor = Color.LightGray;
                button216.BackColor = Color.LightGray;
                button206.BackColor = Color.LightGray;
                button196.BackColor = Color.LightGray;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 31)
            {
                button236.Enabled = false;
                button226.Enabled = true;
                button216.Enabled = true;
                button206.Enabled = true;
                button196.Enabled = true;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.LightGray;
                button216.BackColor = Color.LightGray;
                button206.BackColor = Color.LightGray;
                button196.BackColor = Color.LightGray;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 61)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = true;
                button206.Enabled = true;
                button196.Enabled = true;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.LightGray;
                button206.BackColor = Color.LightGray;
                button196.BackColor = Color.LightGray;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 91)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = true;
                button196.Enabled = true;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.LightGray;
                button196.BackColor = Color.LightGray;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 121)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = false;
                button196.Enabled = true;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.Lime;
                button196.BackColor = Color.LightGray;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 151)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = false;
                button196.Enabled = false;
                button186.Enabled = true;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.Lime;
                button196.BackColor = Color.Lime;
                button186.BackColor = Color.LightGray;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 181)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = false;
                button196.Enabled = false;
                button186.Enabled = false;
                button176.Enabled = true;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.Lime;
                button196.BackColor = Color.Lime;
                button186.BackColor = Color.Lime;
                button176.BackColor = Color.LightGray;
                button166.BackColor = Color.LightGray;
            }
            else if (es1[moves + 4] + sumes < 211)
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = false;
                button196.Enabled = false;
                button186.Enabled = false;
                button176.Enabled = false;
                button166.Enabled = true;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.Lime;
                button196.BackColor = Color.Lime;
                button186.BackColor = Color.Lime;
                button176.BackColor = Color.Lime;
                button166.BackColor = Color.LightGray;
            }
            else
            {
                button236.Enabled = false;
                button226.Enabled = false;
                button216.Enabled = false;
                button206.Enabled = false;
                button196.Enabled = false;
                button186.Enabled = false;
                button176.Enabled = false;
                button166.Enabled = false;

                button236.BackColor = Color.Lime;
                button226.BackColor = Color.Lime;
                button216.BackColor = Color.Lime;
                button206.BackColor = Color.Lime;
                button196.BackColor = Color.Lime;
                button186.BackColor = Color.Lime;
                button176.BackColor = Color.Lime;
                button166.BackColor = Color.Lime;
            }
            // este linea 6 de izq a der
            if (es1[moves + 5] + sumes < 30)
            {
                button235.Enabled = true;
                button225.Enabled = true;
                button215.Enabled = true;
                button205.Enabled = true;
                button195.Enabled = true;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.LightGray;
                button225.BackColor = Color.LightGray;
                button215.BackColor = Color.LightGray;
                button205.BackColor = Color.LightGray;
                button195.BackColor = Color.LightGray;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 31)
            {
                button235.Enabled = false;
                button225.Enabled = true;
                button215.Enabled = true;
                button205.Enabled = true;
                button195.Enabled = true;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.LightGray;
                button215.BackColor = Color.LightGray;
                button205.BackColor = Color.LightGray;
                button195.BackColor = Color.LightGray;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 61)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = true;
                button205.Enabled = true;
                button195.Enabled = true;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.LightGray;
                button205.BackColor = Color.LightGray;
                button195.BackColor = Color.LightGray;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 91)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = true;
                button195.Enabled = true;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.LightGray;
                button195.BackColor = Color.LightGray;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 121)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = false;
                button195.Enabled = true;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.Lime;
                button195.BackColor = Color.LightGray;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 151)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = false;
                button195.Enabled = false;
                button185.Enabled = true;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.Lime;
                button195.BackColor = Color.Lime;
                button185.BackColor = Color.LightGray;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 181)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = false;
                button195.Enabled = false;
                button185.Enabled = false;
                button175.Enabled = true;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.Lime;
                button195.BackColor = Color.Lime;
                button185.BackColor = Color.Lime;
                button175.BackColor = Color.LightGray;
                button165.BackColor = Color.LightGray;
            }
            else if (es1[moves + 5] + sumes < 211)
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = false;
                button195.Enabled = false;
                button185.Enabled = false;
                button175.Enabled = false;
                button165.Enabled = true;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.Lime;
                button195.BackColor = Color.Lime;
                button185.BackColor = Color.Lime;
                button175.BackColor = Color.Lime;
                button165.BackColor = Color.LightGray;
            }
            else
            {
                button235.Enabled = false;
                button225.Enabled = false;
                button215.Enabled = false;
                button205.Enabled = false;
                button195.Enabled = false;
                button185.Enabled = false;
                button175.Enabled = false;
                button165.Enabled = false;

                button235.BackColor = Color.Lime;
                button225.BackColor = Color.Lime;
                button215.BackColor = Color.Lime;
                button205.BackColor = Color.Lime;
                button195.BackColor = Color.Lime;
                button185.BackColor = Color.Lime;
                button175.BackColor = Color.Lime;
                button165.BackColor = Color.Lime;
            }
            // este linea 6 de izq a der
            if (es1[moves + 6] + sumes < 30)
            {
                button234.Enabled = true;
                button224.Enabled = true;
                button214.Enabled = true;
                button204.Enabled = true;
                button194.Enabled = true;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.LightGray;
                button224.BackColor = Color.LightGray;
                button214.BackColor = Color.LightGray;
                button204.BackColor = Color.LightGray;
                button194.BackColor = Color.LightGray;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 31)
            {
                button234.Enabled = false;
                button224.Enabled = true;
                button214.Enabled = true;
                button204.Enabled = true;
                button194.Enabled = true;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.LightGray;
                button214.BackColor = Color.LightGray;
                button204.BackColor = Color.LightGray;
                button194.BackColor = Color.LightGray;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 61)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = true;
                button204.Enabled = true;
                button194.Enabled = true;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.LightGray;
                button204.BackColor = Color.LightGray;
                button194.BackColor = Color.LightGray;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 91)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = true;
                button194.Enabled = true;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.LightGray;
                button194.BackColor = Color.LightGray;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 121)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = false;
                button194.Enabled = true;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.Lime;
                button194.BackColor = Color.LightGray;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 151)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = false;
                button194.Enabled = false;
                button184.Enabled = true;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.Lime;
                button194.BackColor = Color.Lime;
                button184.BackColor = Color.LightGray;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 181)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = false;
                button194.Enabled = false;
                button184.Enabled = false;
                button174.Enabled = true;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.Lime;
                button194.BackColor = Color.Lime;
                button184.BackColor = Color.Lime;
                button174.BackColor = Color.LightGray;
                button164.BackColor = Color.LightGray;
            }
            else if (es1[moves + 6] + sumes < 211)
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = false;
                button194.Enabled = false;
                button184.Enabled = false;
                button174.Enabled = false;
                button164.Enabled = true;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.Lime;
                button194.BackColor = Color.Lime;
                button184.BackColor = Color.Lime;
                button174.BackColor = Color.Lime;
                button164.BackColor = Color.LightGray;
            }
            else
            {
                button234.Enabled = false;
                button224.Enabled = false;
                button214.Enabled = false;
                button204.Enabled = false;
                button194.Enabled = false;
                button184.Enabled = false;
                button174.Enabled = false;
                button164.Enabled = false;

                button234.BackColor = Color.Lime;
                button224.BackColor = Color.Lime;
                button214.BackColor = Color.Lime;
                button204.BackColor = Color.Lime;
                button194.BackColor = Color.Lime;
                button184.BackColor = Color.Lime;
                button174.BackColor = Color.Lime;
                button164.BackColor = Color.Lime;
            }
            // este linea 8 de izq a der
            if (es1[moves + 7] + sumes < 30)
            {
                button233.Enabled = true;
                button223.Enabled = true;
                button213.Enabled = true;
                button203.Enabled = true;
                button193.Enabled = true;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.LightGray;
                button223.BackColor = Color.LightGray;
                button213.BackColor = Color.LightGray;
                button203.BackColor = Color.LightGray;
                button193.BackColor = Color.LightGray;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 31)
            {
                button233.Enabled = false;
                button223.Enabled = true;
                button213.Enabled = true;
                button203.Enabled = true;
                button193.Enabled = true;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.LightGray;
                button213.BackColor = Color.LightGray;
                button203.BackColor = Color.LightGray;
                button193.BackColor = Color.LightGray;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 61)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = true;
                button203.Enabled = true;
                button193.Enabled = true;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.LightGray;
                button203.BackColor = Color.LightGray;
                button193.BackColor = Color.LightGray;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 91)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = true;
                button193.Enabled = true;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.LightGray;
                button193.BackColor = Color.LightGray;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 121)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = false;
                button193.Enabled = true;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.Lime;
                button193.BackColor = Color.LightGray;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 151)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = false;
                button193.Enabled = false;
                button183.Enabled = true;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.Lime;
                button193.BackColor = Color.Lime;
                button183.BackColor = Color.LightGray;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 181)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = false;
                button193.Enabled = false;
                button183.Enabled = false;
                button173.Enabled = true;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.Lime;
                button193.BackColor = Color.Lime;
                button183.BackColor = Color.Lime;
                button173.BackColor = Color.LightGray;
                button163.BackColor = Color.LightGray;
            }
            else if (es1[moves + 7] + sumes < 211)
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = false;
                button193.Enabled = false;
                button183.Enabled = false;
                button173.Enabled = false;
                button163.Enabled = true;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.Lime;
                button193.BackColor = Color.Lime;
                button183.BackColor = Color.Lime;
                button173.BackColor = Color.Lime;
                button163.BackColor = Color.LightGray;
            }
            else
            {
                button233.Enabled = false;
                button223.Enabled = false;
                button213.Enabled = false;
                button203.Enabled = false;
                button193.Enabled = false;
                button183.Enabled = false;
                button173.Enabled = false;
                button163.Enabled = false;

                button233.BackColor = Color.Lime;
                button223.BackColor = Color.Lime;
                button213.BackColor = Color.Lime;
                button203.BackColor = Color.Lime;
                button193.BackColor = Color.Lime;
                button183.BackColor = Color.Lime;
                button173.BackColor = Color.Lime;
                button163.BackColor = Color.Lime;
            }
            // este linea 8 de izq a der
            if (es1[moves + 8] + sumes < 30)
            {
                button232.Enabled = true;
                button222.Enabled = true;
                button212.Enabled = true;
                button202.Enabled = true;
                button192.Enabled = true;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.LightGray;
                button222.BackColor = Color.LightGray;
                button212.BackColor = Color.LightGray;
                button202.BackColor = Color.LightGray;
                button192.BackColor = Color.LightGray;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;


            }
            else if (es1[moves + 8] + sumes < 31)
            {
                button232.Enabled = false;
                button222.Enabled = true;
                button212.Enabled = true;
                button202.Enabled = true;
                button192.Enabled = true;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.LightGray;
                button212.BackColor = Color.LightGray;
                button202.BackColor = Color.LightGray;
                button192.BackColor = Color.LightGray;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 61)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = true;
                button202.Enabled = true;
                button192.Enabled = true;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.LightGray;
                button202.BackColor = Color.LightGray;
                button192.BackColor = Color.LightGray;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 91)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = true;
                button192.Enabled = true;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.LightGray;
                button192.BackColor = Color.LightGray;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 121)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = false;
                button192.Enabled = true;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.Lime;
                button192.BackColor = Color.LightGray;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 151)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = false;
                button192.Enabled = false;
                button182.Enabled = true;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.Lime;
                button192.BackColor = Color.Lime;
                button182.BackColor = Color.LightGray;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 181)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = false;
                button192.Enabled = false;
                button182.Enabled = false;
                button172.Enabled = true;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.Lime;
                button192.BackColor = Color.Lime;
                button182.BackColor = Color.Lime;
                button172.BackColor = Color.LightGray;
                button162.BackColor = Color.LightGray;
            }
            else if (es1[moves + 8] + sumes < 211)
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = false;
                button192.Enabled = false;
                button182.Enabled = false;
                button172.Enabled = false;
                button162.Enabled = true;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.Lime;
                button192.BackColor = Color.Lime;
                button182.BackColor = Color.Lime;
                button172.BackColor = Color.Lime;
                button162.BackColor = Color.LightGray;
            }
            else
            {
                button232.Enabled = false;
                button222.Enabled = false;
                button212.Enabled = false;
                button202.Enabled = false;
                button192.Enabled = false;
                button182.Enabled = false;
                button172.Enabled = false;
                button162.Enabled = false;

                button232.BackColor = Color.Lime;
                button222.BackColor = Color.Lime;
                button212.BackColor = Color.Lime;
                button202.BackColor = Color.Lime;
                button192.BackColor = Color.Lime;
                button182.BackColor = Color.Lime;
                button172.BackColor = Color.Lime;
                button162.BackColor = Color.Lime;
            }
            // este linea 10 de izq a der
            if (es1[moves + 9] + sumes < 30)
            {
                button231.Enabled = true;
                button221.Enabled = true;
                button211.Enabled = true;
                button201.Enabled = true;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.LightGray;
                button221.BackColor = Color.LightGray;
                button211.BackColor = Color.LightGray;
                button201.BackColor = Color.LightGray;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;

            }
            else if (es1[moves + 9] + sumes < 31)
            {
                button231.Enabled = false;
                button221.Enabled = true;
                button211.Enabled = true;
                button201.Enabled = true;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.LightGray;
                button211.BackColor = Color.LightGray;
                button201.BackColor = Color.LightGray;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 61)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = true;
                button201.Enabled = true;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.LightGray;
                button201.BackColor = Color.LightGray;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 91)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = true;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.LightGray;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 91)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = true;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.LightGray;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 121)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = false;
                button191.Enabled = true;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.Lime;
                button191.BackColor = Color.LightGray;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 151)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = false;
                button191.Enabled = false;
                button181.Enabled = true;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.Lime;
                button191.BackColor = Color.Lime;
                button181.BackColor = Color.LightGray;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 181)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = false;
                button191.Enabled = false;
                button181.Enabled = false;
                button171.Enabled = true;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.Lime;
                button191.BackColor = Color.Lime;
                button181.BackColor = Color.Lime;
                button171.BackColor = Color.LightGray;
                button161.BackColor = Color.LightGray;
            }
            else if (es1[moves + 9] + sumes < 211)
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = false;
                button191.Enabled = false;
                button181.Enabled = false;
                button171.Enabled = false;
                button161.Enabled = true;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.Lime;
                button191.BackColor = Color.Lime;
                button181.BackColor = Color.Lime;
                button171.BackColor = Color.Lime;
                button161.BackColor = Color.LightGray;
            }
            else
            {
                button231.Enabled = false;
                button221.Enabled = false;
                button211.Enabled = false;
                button201.Enabled = false;
                button191.Enabled = false;
                button181.Enabled = false;
                button171.Enabled = false;
                button161.Enabled = false;

                button231.BackColor = Color.Lime;
                button221.BackColor = Color.Lime;
                button211.BackColor = Color.Lime;
                button201.BackColor = Color.Lime;
                button191.BackColor = Color.Lime;
                button181.BackColor = Color.Lime;
                button171.BackColor = Color.Lime;
                button161.BackColor = Color.Lime;
            }
            //oeste linea 1 
            if (o1[movo] + sumo < 30)
            {
                button311.Enabled = true;
                button301.Enabled = true;
                button291.Enabled = true;
                button281.Enabled = true;
                button271.Enabled = true;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.LightGray;
                button301.BackColor = Color.LightGray;
                button291.BackColor = Color.LightGray;
                button281.BackColor = Color.LightGray;
                button271.BackColor = Color.LightGray;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;

            }
            else if (o1[movo] + sumo < 31)
            {
                button311.Enabled = false;
                button301.Enabled = true;
                button291.Enabled = true;
                button281.Enabled = true;
                button271.Enabled = true;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.LightGray;
                button291.BackColor = Color.LightGray;
                button281.BackColor = Color.LightGray;
                button271.BackColor = Color.LightGray;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 61)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = true;
                button281.Enabled = true;
                button271.Enabled = true;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.LightGray;
                button281.BackColor = Color.LightGray;
                button271.BackColor = Color.LightGray;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 91)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = true;
                button271.Enabled = true;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.LightGray;
                button271.BackColor = Color.LightGray;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 121)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = false;
                button271.Enabled = true;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.Lime;
                button271.BackColor = Color.LightGray;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 151)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = false;
                button271.Enabled = false;
                button261.Enabled = true;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.Lime;
                button271.BackColor = Color.Lime;
                button261.BackColor = Color.LightGray;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 181)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = false;
                button271.Enabled = false;
                button261.Enabled = false;
                button251.Enabled = true;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.Lime;
                button271.BackColor = Color.Lime;
                button261.BackColor = Color.Lime;
                button251.BackColor = Color.LightGray;
                button241.BackColor = Color.LightGray;
            }
            else if (o1[movo] + sumo < 211)
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = false;
                button271.Enabled = false;
                button261.Enabled = false;
                button251.Enabled = false;
                button241.Enabled = true;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.Lime;
                button271.BackColor = Color.Lime;
                button261.BackColor = Color.Lime;
                button251.BackColor = Color.Lime;
                button241.BackColor = Color.LightGray;
            }
            else
            {
                button311.Enabled = false;
                button301.Enabled = false;
                button291.Enabled = false;
                button281.Enabled = false;
                button271.Enabled = false;
                button261.Enabled = false;
                button251.Enabled = false;
                button241.Enabled = false;

                button311.BackColor = Color.Lime;
                button301.BackColor = Color.Lime;
                button291.BackColor = Color.Lime;
                button281.BackColor = Color.Lime;
                button271.BackColor = Color.Lime;
                button261.BackColor = Color.Lime;
                button251.BackColor = Color.Lime;
                button241.BackColor = Color.Lime;
            }
            //oeste linea 2 
            if (o1[movo + 1] + sumo < 30)
            {
                button312.Enabled = true;
                button302.Enabled = true;
                button292.Enabled = true;
                button282.Enabled = true;
                button272.Enabled = true;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.LightGray;
                button302.BackColor = Color.LightGray;
                button292.BackColor = Color.LightGray;
                button282.BackColor = Color.LightGray;
                button272.BackColor = Color.LightGray;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;

            }
            else if (o1[movo + 1] + sumo < 31)
            {
                button312.Enabled = false;
                button302.Enabled = true;
                button292.Enabled = true;
                button282.Enabled = true;
                button272.Enabled = true;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.LightGray;
                button292.BackColor = Color.LightGray;
                button282.BackColor = Color.LightGray;
                button272.BackColor = Color.LightGray;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 61)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = true;
                button282.Enabled = true;
                button272.Enabled = true;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.LightGray;
                button282.BackColor = Color.LightGray;
                button272.BackColor = Color.LightGray;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 91)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = true;
                button272.Enabled = true;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.LightGray;
                button272.BackColor = Color.LightGray;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 121)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = false;
                button272.Enabled = true;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.Lime;
                button272.BackColor = Color.LightGray;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 151)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = false;
                button272.Enabled = false;
                button262.Enabled = true;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.Lime;
                button272.BackColor = Color.Lime;
                button262.BackColor = Color.LightGray;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 181)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = false;
                button272.Enabled = false;
                button262.Enabled = false;
                button252.Enabled = true;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.Lime;
                button272.BackColor = Color.Lime;
                button262.BackColor = Color.Lime;
                button252.BackColor = Color.LightGray;
                button242.BackColor = Color.LightGray;
            }
            else if (o1[movo + 1] + sumo < 211)
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = false;
                button272.Enabled = false;
                button262.Enabled = false;
                button252.Enabled = false;
                button242.Enabled = true;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.Lime;
                button272.BackColor = Color.Lime;
                button262.BackColor = Color.Lime;
                button252.BackColor = Color.Lime;
                button242.BackColor = Color.LightGray;
            }
            else
            {
                button312.Enabled = false;
                button302.Enabled = false;
                button292.Enabled = false;
                button282.Enabled = false;
                button272.Enabled = false;
                button262.Enabled = false;
                button252.Enabled = false;
                button242.Enabled = false;

                button312.BackColor = Color.Lime;
                button302.BackColor = Color.Lime;
                button292.BackColor = Color.Lime;
                button282.BackColor = Color.Lime;
                button272.BackColor = Color.Lime;
                button262.BackColor = Color.Lime;
                button252.BackColor = Color.Lime;
                button242.BackColor = Color.Lime;
            }
            //oeste linea 3
            if (o1[movo + 2] + sumo < 30)
            {
                button313.Enabled = true;
                button303.Enabled = true;
                button293.Enabled = true;
                button283.Enabled = true;
                button273.Enabled = true;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.LightGray;
                button303.BackColor = Color.LightGray;
                button293.BackColor = Color.LightGray;
                button283.BackColor = Color.LightGray;
                button273.BackColor = Color.LightGray;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 31)
            {
                button313.Enabled = false;
                button303.Enabled = true;
                button293.Enabled = true;
                button283.Enabled = true;
                button273.Enabled = true;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.LightGray;
                button293.BackColor = Color.LightGray;
                button283.BackColor = Color.LightGray;
                button273.BackColor = Color.LightGray;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 61)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = true;
                button283.Enabled = true;
                button273.Enabled = true;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.LightGray;
                button283.BackColor = Color.LightGray;
                button273.BackColor = Color.LightGray;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 91)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = true;
                button273.Enabled = true;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.LightGray;
                button273.BackColor = Color.LightGray;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 121)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = false;
                button273.Enabled = true;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.Lime;
                button273.BackColor = Color.LightGray;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 151)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = false;
                button273.Enabled = false;
                button263.Enabled = true;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.Lime;
                button273.BackColor = Color.Lime;
                button263.BackColor = Color.LightGray;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 181)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = false;
                button273.Enabled = false;
                button263.Enabled = false;
                button253.Enabled = true;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.Lime;
                button273.BackColor = Color.Lime;
                button263.BackColor = Color.Lime;
                button253.BackColor = Color.LightGray;
                button243.BackColor = Color.LightGray;
            }
            else if (o1[movo + 2] + sumo < 211)
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = false;
                button273.Enabled = false;
                button263.Enabled = false;
                button253.Enabled = false;
                button243.Enabled = true;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.Lime;
                button273.BackColor = Color.Lime;
                button263.BackColor = Color.Lime;
                button253.BackColor = Color.Lime;
                button243.BackColor = Color.LightGray;
            }
            else
            {
                button313.Enabled = false;
                button303.Enabled = false;
                button293.Enabled = false;
                button283.Enabled = false;
                button273.Enabled = false;
                button263.Enabled = false;
                button253.Enabled = false;
                button243.Enabled = false;

                button313.BackColor = Color.Lime;
                button303.BackColor = Color.Lime;
                button293.BackColor = Color.Lime;
                button283.BackColor = Color.Lime;
                button273.BackColor = Color.Lime;
                button263.BackColor = Color.Lime;
                button253.BackColor = Color.Lime;
                button243.BackColor = Color.Lime;
            }
            //oeste linea 4
            if (o1[movo + 3] + sumo < 30)
            {
                button314.Enabled = true;
                button304.Enabled = true;
                button294.Enabled = true;
                button284.Enabled = true;
                button274.Enabled = true;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.LightGray;
                button304.BackColor = Color.LightGray;
                button294.BackColor = Color.LightGray;
                button284.BackColor = Color.LightGray;
                button274.BackColor = Color.LightGray;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;

            }
            else if (o1[movo + 3] + sumo < 31)
            {
                button314.Enabled = false;
                button304.Enabled = true;
                button294.Enabled = true;
                button284.Enabled = true;
                button274.Enabled = true;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.LightGray;
                button294.BackColor = Color.LightGray;
                button284.BackColor = Color.LightGray;
                button274.BackColor = Color.LightGray;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 61)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = true;
                button284.Enabled = true;
                button274.Enabled = true;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.LightGray;
                button284.BackColor = Color.LightGray;
                button274.BackColor = Color.LightGray;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 91)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = true;
                button274.Enabled = true;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.LightGray;
                button274.BackColor = Color.LightGray;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 121)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = false;
                button274.Enabled = true;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.Lime;
                button274.BackColor = Color.LightGray;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 151)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = false;
                button274.Enabled = false;
                button264.Enabled = true;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.Lime;
                button274.BackColor = Color.Lime;
                button264.BackColor = Color.LightGray;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 181)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = false;
                button274.Enabled = false;
                button264.Enabled = false;
                button254.Enabled = true;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.Lime;
                button274.BackColor = Color.Lime;
                button264.BackColor = Color.Lime;
                button254.BackColor = Color.LightGray;
                button244.BackColor = Color.LightGray;
            }
            else if (o1[movo + 3] + sumo < 211)
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = false;
                button274.Enabled = false;
                button264.Enabled = false;
                button254.Enabled = false;
                button244.Enabled = true;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.Lime;
                button274.BackColor = Color.Lime;
                button264.BackColor = Color.Lime;
                button254.BackColor = Color.Lime;
                button244.BackColor = Color.LightGray;
            }
            else
            {
                button314.Enabled = false;
                button304.Enabled = false;
                button294.Enabled = false;
                button284.Enabled = false;
                button274.Enabled = false;
                button264.Enabled = false;
                button254.Enabled = false;
                button244.Enabled = false;

                button314.BackColor = Color.Lime;
                button304.BackColor = Color.Lime;
                button294.BackColor = Color.Lime;
                button284.BackColor = Color.Lime;
                button274.BackColor = Color.Lime;
                button264.BackColor = Color.Lime;
                button254.BackColor = Color.Lime;
                button244.BackColor = Color.Lime;
            }
            //oeste linea 5
            if (o1[movo + 4] + sumo < 30)
            {
                button315.Enabled = true;
                button305.Enabled = true;
                button295.Enabled = true;
                button285.Enabled = true;
                button275.Enabled = true;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.LightGray;
                button305.BackColor = Color.LightGray;
                button295.BackColor = Color.LightGray;
                button285.BackColor = Color.LightGray;
                button275.BackColor = Color.LightGray;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 31)
            {
                button315.Enabled = false;
                button305.Enabled = true;
                button295.Enabled = true;
                button285.Enabled = true;
                button275.Enabled = true;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.LightGray;
                button295.BackColor = Color.LightGray;
                button285.BackColor = Color.LightGray;
                button275.BackColor = Color.LightGray;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 61)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = true;
                button285.Enabled = true;
                button275.Enabled = true;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.LightGray;
                button285.BackColor = Color.LightGray;
                button275.BackColor = Color.LightGray;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 91)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = true;
                button275.Enabled = true;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.LightGray;
                button275.BackColor = Color.LightGray;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 121)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = false;
                button275.Enabled = true;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.Lime;
                button275.BackColor = Color.LightGray;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 151)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = false;
                button275.Enabled = false;
                button265.Enabled = true;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.Lime;
                button275.BackColor = Color.Lime;
                button265.BackColor = Color.LightGray;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 181)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = false;
                button275.Enabled = false;
                button265.Enabled = false;
                button255.Enabled = true;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.Lime;
                button275.BackColor = Color.Lime;
                button265.BackColor = Color.Lime;
                button255.BackColor = Color.LightGray;
                button245.BackColor = Color.LightGray;
            }
            else if (o1[movo + 4] + sumo < 211)
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = false;
                button275.Enabled = false;
                button265.Enabled = false;
                button255.Enabled = false;
                button245.Enabled = true;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.Lime;
                button275.BackColor = Color.Lime;
                button265.BackColor = Color.Lime;
                button255.BackColor = Color.Lime;
                button245.BackColor = Color.LightGray;
            }

            else
            {
                button315.Enabled = false;
                button305.Enabled = false;
                button295.Enabled = false;
                button285.Enabled = false;
                button275.Enabled = false;
                button265.Enabled = false;
                button255.Enabled = false;
                button245.Enabled = false;

                button315.BackColor = Color.Lime;
                button305.BackColor = Color.Lime;
                button295.BackColor = Color.Lime;
                button285.BackColor = Color.Lime;
                button275.BackColor = Color.Lime;
                button265.BackColor = Color.Lime;
                button255.BackColor = Color.Lime;
                button245.BackColor = Color.Lime;
            }
            //oeste linea 6
            if (o1[movo + 5] + sumo < 30)
            {
                button316.Enabled = true;
                button306.Enabled = true;
                button296.Enabled = true;
                button286.Enabled = true;
                button276.Enabled = true;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.LightGray;
                button306.BackColor = Color.LightGray;
                button296.BackColor = Color.LightGray;
                button286.BackColor = Color.LightGray;
                button276.BackColor = Color.LightGray;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 31)
            {
                button316.Enabled = false;
                button306.Enabled = true;
                button296.Enabled = true;
                button286.Enabled = true;
                button276.Enabled = true;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.LightGray;
                button296.BackColor = Color.LightGray;
                button286.BackColor = Color.LightGray;
                button276.BackColor = Color.LightGray;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 61)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = true;
                button286.Enabled = true;
                button276.Enabled = true;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.LightGray;
                button286.BackColor = Color.LightGray;
                button276.BackColor = Color.LightGray;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 91)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = true;
                button276.Enabled = true;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.LightGray;
                button276.BackColor = Color.LightGray;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 121)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = false;
                button276.Enabled = true;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.Lime;
                button276.BackColor = Color.LightGray;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 151)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = false;
                button276.Enabled = false;
                button266.Enabled = true;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.Lime;
                button276.BackColor = Color.Lime;
                button266.BackColor = Color.LightGray;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 181)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = false;
                button276.Enabled = false;
                button266.Enabled = false;
                button256.Enabled = true;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.Lime;
                button276.BackColor = Color.Lime;
                button266.BackColor = Color.Lime;
                button256.BackColor = Color.LightGray;
                button246.BackColor = Color.LightGray;
            }
            else if (o1[movo + 5] + sumo < 211)
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = false;
                button276.Enabled = false;
                button266.Enabled = false;
                button256.Enabled = false;
                button246.Enabled = true;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.Lime;
                button276.BackColor = Color.Lime;
                button266.BackColor = Color.Lime;
                button256.BackColor = Color.Lime;
                button246.BackColor = Color.LightGray;
            }
            else
            {
                button316.Enabled = false;
                button306.Enabled = false;
                button296.Enabled = false;
                button286.Enabled = false;
                button276.Enabled = false;
                button266.Enabled = false;
                button256.Enabled = false;
                button246.Enabled = false;

                button316.BackColor = Color.Lime;
                button306.BackColor = Color.Lime;
                button296.BackColor = Color.Lime;
                button286.BackColor = Color.Lime;
                button276.BackColor = Color.Lime;
                button266.BackColor = Color.Lime;
                button256.BackColor = Color.Lime;
                button246.BackColor = Color.Lime;
            }
            //oeste linea 7
            if (o1[movo + 6] + sumo < 30)
            {
                button317.Enabled = true;
                button307.Enabled = true;
                button297.Enabled = true;
                button287.Enabled = true;
                button277.Enabled = true;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.LightGray;
                button307.BackColor = Color.LightGray;
                button297.BackColor = Color.LightGray;
                button287.BackColor = Color.LightGray;
                button277.BackColor = Color.LightGray;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 31)
            {
                button317.Enabled = false;
                button307.Enabled = true;
                button297.Enabled = true;
                button287.Enabled = true;
                button277.Enabled = true;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.LightGray;
                button297.BackColor = Color.LightGray;
                button287.BackColor = Color.LightGray;
                button277.BackColor = Color.LightGray;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 61)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = true;
                button287.Enabled = true;
                button277.Enabled = true;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.LightGray;
                button287.BackColor = Color.LightGray;
                button277.BackColor = Color.LightGray;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 91)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = true;
                button277.Enabled = true;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.LightGray;
                button277.BackColor = Color.LightGray;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 121)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = false;
                button277.Enabled = true;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.Lime;
                button277.BackColor = Color.LightGray;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 151)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = false;
                button277.Enabled = false;
                button267.Enabled = true;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.Lime;
                button277.BackColor = Color.Lime;
                button267.BackColor = Color.LightGray;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 181)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = false;
                button277.Enabled = false;
                button267.Enabled = false;
                button257.Enabled = true;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.Lime;
                button277.BackColor = Color.Lime;
                button267.BackColor = Color.Lime;
                button257.BackColor = Color.LightGray;
                button247.BackColor = Color.LightGray;
            }
            else if (o1[movo + 6] + sumo < 211)
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = false;
                button277.Enabled = false;
                button267.Enabled = false;
                button257.Enabled = false;
                button247.Enabled = true;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.Lime;
                button277.BackColor = Color.Lime;
                button267.BackColor = Color.Lime;
                button257.BackColor = Color.Lime;
                button247.BackColor = Color.LightGray;
            }
            else
            {
                button317.Enabled = false;
                button307.Enabled = false;
                button297.Enabled = false;
                button287.Enabled = false;
                button277.Enabled = false;
                button267.Enabled = false;
                button257.Enabled = false;
                button247.Enabled = false;

                button317.BackColor = Color.Lime;
                button307.BackColor = Color.Lime;
                button297.BackColor = Color.Lime;
                button287.BackColor = Color.Lime;
                button277.BackColor = Color.Lime;
                button267.BackColor = Color.Lime;
                button257.BackColor = Color.Lime;
                button247.BackColor = Color.Lime;

            }
            //oeste linea 8
            if (o1[movo + 7] + sumo < 30)
            {
                button318.Enabled = true;
                button308.Enabled = true;
                button298.Enabled = true;
                button288.Enabled = true;
                button278.Enabled = true;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.LightGray;
                button308.BackColor = Color.LightGray;
                button298.BackColor = Color.LightGray;
                button288.BackColor = Color.LightGray;
                button278.BackColor = Color.LightGray;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;

            }
            else if (o1[movo + 7] + sumo < 31)
            {
                button318.Enabled = false;
                button308.Enabled = true;
                button298.Enabled = true;
                button288.Enabled = true;
                button278.Enabled = true;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.LightGray;
                button298.BackColor = Color.LightGray;
                button288.BackColor = Color.LightGray;
                button278.BackColor = Color.LightGray;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 61)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = true;
                button288.Enabled = true;
                button278.Enabled = true;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.LightGray;
                button288.BackColor = Color.LightGray;
                button278.BackColor = Color.LightGray;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 91)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = true;
                button278.Enabled = true;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.LightGray;
                button278.BackColor = Color.LightGray;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 121)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = false;
                button278.Enabled = true;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.Lime;
                button278.BackColor = Color.LightGray;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 151)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = false;
                button278.Enabled = false;
                button268.Enabled = true;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.Lime;
                button278.BackColor = Color.Lime;
                button268.BackColor = Color.LightGray;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 181)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = false;
                button278.Enabled = false;
                button268.Enabled = false;
                button258.Enabled = true;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.Lime;
                button278.BackColor = Color.Lime;
                button268.BackColor = Color.Lime;
                button258.BackColor = Color.LightGray;
                button248.BackColor = Color.LightGray;
            }
            else if (o1[movo + 7] + sumo < 211)
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = false;
                button278.Enabled = false;
                button268.Enabled = false;
                button258.Enabled = false;
                button248.Enabled = true;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.Lime;
                button278.BackColor = Color.Lime;
                button268.BackColor = Color.Lime;
                button258.BackColor = Color.Lime;
                button248.BackColor = Color.LightGray;

            }
            else
            {
                button318.Enabled = false;
                button308.Enabled = false;
                button298.Enabled = false;
                button288.Enabled = false;
                button278.Enabled = false;
                button268.Enabled = false;
                button258.Enabled = false;
                button248.Enabled = false;

                button318.BackColor = Color.Lime;
                button308.BackColor = Color.Lime;
                button298.BackColor = Color.Lime;
                button288.BackColor = Color.Lime;
                button278.BackColor = Color.Lime;
                button268.BackColor = Color.Lime;
                button258.BackColor = Color.Lime;
                button248.BackColor = Color.Lime;
            }
            //oeste linea 9
            if (o1[movo + 8] + sumo < 30)
            {
                button319.Enabled = true;
                button309.Enabled = true;
                button299.Enabled = true;
                button289.Enabled = true;
                button279.Enabled = true;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.LightGray;
                button309.BackColor = Color.LightGray;
                button299.BackColor = Color.LightGray;
                button289.BackColor = Color.LightGray;
                button279.BackColor = Color.LightGray;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 31)
            {
                button319.Enabled = false;
                button309.Enabled = true;
                button299.Enabled = true;
                button289.Enabled = true;
                button279.Enabled = true;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.LightGray;
                button299.BackColor = Color.LightGray;
                button289.BackColor = Color.LightGray;
                button279.BackColor = Color.LightGray;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 61)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = true;
                button289.Enabled = true;
                button279.Enabled = true;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.LightGray;
                button289.BackColor = Color.LightGray;
                button279.BackColor = Color.LightGray;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 91)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = true;
                button279.Enabled = true;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.LightGray;
                button279.BackColor = Color.LightGray;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 121)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = false;
                button279.Enabled = true;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.Lime;
                button279.BackColor = Color.LightGray;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 151)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = false;
                button279.Enabled = false;
                button269.Enabled = true;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.Lime;
                button279.BackColor = Color.Lime;
                button269.BackColor = Color.LightGray;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 181)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = false;
                button279.Enabled = false;
                button269.Enabled = false;
                button259.Enabled = true;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.Lime;
                button279.BackColor = Color.Lime;
                button269.BackColor = Color.Lime;
                button259.BackColor = Color.LightGray;
                button249.BackColor = Color.LightGray;
            }
            else if (o1[movo + 8] + sumo < 211)
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = false;
                button279.Enabled = false;
                button269.Enabled = false;
                button259.Enabled = false;
                button249.Enabled = true;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.Lime;
                button279.BackColor = Color.Lime;
                button269.BackColor = Color.Lime;
                button259.BackColor = Color.Lime;
                button249.BackColor = Color.LightGray;
            }
            else
            {
                button319.Enabled = false;
                button309.Enabled = false;
                button299.Enabled = false;
                button289.Enabled = false;
                button279.Enabled = false;
                button269.Enabled = false;
                button259.Enabled = false;
                button249.Enabled = false;

                button319.BackColor = Color.Lime;
                button309.BackColor = Color.Lime;
                button299.BackColor = Color.Lime;
                button289.BackColor = Color.Lime;
                button279.BackColor = Color.Lime;
                button269.BackColor = Color.Lime;
                button259.BackColor = Color.Lime;
                button249.BackColor = Color.Lime;
            }
            //oeste linea 10
            if (o1[movo + 9] + sumo < 30)
            {
                button320.Enabled = true;
                button310.Enabled = true;
                button300.Enabled = true;
                button290.Enabled = true;
                button280.Enabled = true;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.LightGray;
                button310.BackColor = Color.LightGray;
                button300.BackColor = Color.LightGray;
                button290.BackColor = Color.LightGray;
                button280.BackColor = Color.LightGray;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 31)
            {
                button320.Enabled = false;
                button310.Enabled = true;
                button300.Enabled = true;
                button290.Enabled = true;
                button280.Enabled = true;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.LightGray;
                button300.BackColor = Color.LightGray;
                button290.BackColor = Color.LightGray;
                button280.BackColor = Color.LightGray;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;

            }
            else if (o1[movo + 9] + sumo < 61)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = true;
                button290.Enabled = true;
                button280.Enabled = true;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.LightGray;
                button290.BackColor = Color.LightGray;
                button280.BackColor = Color.LightGray;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 91)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = true;
                button280.Enabled = true;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.LightGray;
                button280.BackColor = Color.LightGray;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 121)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = false;
                button280.Enabled = true;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.Lime;
                button280.BackColor = Color.LightGray;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 151)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = false;
                button280.Enabled = false;
                button270.Enabled = true;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.Lime;
                button280.BackColor = Color.Lime;
                button270.BackColor = Color.LightGray;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 181)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = false;
                button280.Enabled = false;
                button270.Enabled = false;
                button260.Enabled = true;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.Lime;
                button280.BackColor = Color.Lime;
                button270.BackColor = Color.Lime;
                button260.BackColor = Color.LightGray;
                button250.BackColor = Color.LightGray;
            }
            else if (o1[movo + 9] + sumo < 211)
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = false;
                button280.Enabled = false;
                button270.Enabled = false;
                button260.Enabled = false;
                button250.Enabled = true;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.Lime;
                button280.BackColor = Color.Lime;
                button270.BackColor = Color.Lime;
                button260.BackColor = Color.Lime;
                button250.BackColor = Color.LightGray;
            }
            else
            {
                button320.Enabled = false;
                button310.Enabled = false;
                button300.Enabled = false;
                button290.Enabled = false;
                button280.Enabled = false;
                button270.Enabled = false;
                button260.Enabled = false;
                button250.Enabled = false;

                button320.BackColor = Color.Lime;
                button310.BackColor = Color.Lime;
                button300.BackColor = Color.Lime;
                button290.BackColor = Color.Lime;
                button280.BackColor = Color.Lime;
                button270.BackColor = Color.Lime;
                button260.BackColor = Color.Lime;
                button250.BackColor = Color.Lime;
            }
        }

        public void serial()
        {

            try
            {
                this.puerto = new System.IO.Ports.SerialPort("" + comboBox1.SelectedItem, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                this.puerto.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(recepcion);

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique:" + System.Environment.NewLine + "- Voltage" + System.Environment.NewLine + "- Conexion del puerto", "Error de puerto COM", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void recepcion(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(10);
                datos_puerto = this.puerto.ReadLine();
                Console.WriteLine(datos_puerto);
                if (datos_puerto.StartsWith("$"))
                { this.Invoke(new EventHandler(actualizar)); }

            }

            catch (Exception) { }


        }
        int final = 0;
        public void guardar()
        {
            if(final ==0)
            {
                try
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true);
                    if (mama == 0)
                    {
                        //file.Write("\r");

                        file.Write("Norte,Sur,Este,Oeste");
                        file.Write("\r\n");
                        mama = 1;
                    }
                    file.Write((serie1 + serie4) / 2);
                    //file.Write("\r");
                    file.Write(",");
                    file.Write(serie5);
                    //file.Write("\r");
                    file.Write(",");
                    file.Write(serie6);
                    //file.Write("\r");
                    file.Write(",");
                    file.Write(serie7);
                    file.Write("\r\n");
                    file.Close();
                }
                catch
                { }
                try
                {
                    System.IO.StreamWriter file2 = new System.IO.StreamWriter(filepath2, true);
                    file2.Write((serie1 + serie4) / 2);
                    file2.Write("\r\n");
                    file2.Close();
                }
                catch
                { }
                try
                {
                    System.IO.StreamWriter file3 = new System.IO.StreamWriter(filepath3, true);

                    file3.Write(serie5);
                    file3.Write("\r\n");
                    file3.Close();
                }
                catch
                { }
                try
                {
                    System.IO.StreamWriter file4 = new System.IO.StreamWriter(filepath4, true);

                    file4.Write(serie6);
                    file4.Write("\r\n");
                    file4.Close();
                }
                catch
                { }
                try
                {
                    System.IO.StreamWriter file5 = new System.IO.StreamWriter(filepath5, true);


                    file5.Write(serie7);
                    file5.Write("\r\n");
                    file5.Close();
                }
                catch
                { }
            }
            else
            {

            }
        }
        public void actualizar(object s, EventArgs e)
        {
            
            try
            {
                datos_puerto = datos_puerto.Remove(0, 1);
                string[] arreglo = datos_puerto.Split(';');
                serie1 = Convert.ToInt32(arreglo[0].Replace(".", ","));
                //serie2 = Convert.ToDouble(arreglo[1].Replace(".", ","));
                //serie3 = Convert.ToDouble(arreglo[2].Replace(".", ","));
                serie4 = Convert.ToInt32(arreglo[1].Replace(".", ","));
                serie5 = Convert.ToInt32(arreglo[2].Replace(".", ","));
                serie6 = Convert.ToInt32(arreglo[3].Replace(".", ","));
                serie7 = Convert.ToInt32(arreglo[4].Replace(".", ","));
                //button322.Text = (serie1+serie2).ToString();

                if(guardaremos == 0)
                {
                    guardar();
                }
                else
                {
                    guardaremos = 0;
                }
                posicionn++;

                n1[posicionn] = (serie1 + serie4);
                s1[posicionn] = serie5;
                o1[posicionn] = serie6;
                es1[posicionn] = serie7;
                if(n1[posicionn] <20)
                {
                    groupBox4.BackColor = Color.Red;
                }
                else
                {
                    groupBox4.BackColor = Color.Lime;
                }
                if (s1[posicionn] < 20)
                {
                    groupBox5.BackColor = Color.Red;
                }
                else
                {
                    groupBox5.BackColor = Color.Lime;
                }
                if (o1[posicionn] < 20)
                {
                    groupBox6.BackColor = Color.Red;
                }
                else
                {
                    groupBox6.BackColor = Color.Lime;
                }
                if (es1[posicionn] < 20)
                {
                    groupBox7.BackColor = Color.Red;
                }
                else
                {
                    groupBox7.BackColor = Color.Lime;
                }
                if (posicionn ==0)
                {
                    movn = posicionn;
                    movo = posicionn;
                    moves = posicionn;
                    movs = posicionn;
                }
                else if (posicionn == 1)
                {
                    movn = posicionn - 1;
                    movo = posicionn - 1;
                    moves = posicionn - 1;
                    movs = posicionn - 1;
                }
                else if (posicionn == 2)
                {
                    movn = posicionn - 2;
                    movo = posicionn - 2;
                    moves = posicionn - 2;
                    movs = posicionn - 2;
                }
                else if (posicionn == 3)
                {
                    movn = posicionn - 3;
                    movo = posicionn - 3;
                    moves = posicionn - 3;
                    movs = posicionn - 3;
                }
                else if (posicionn == 4)
                {
                    movn = posicionn - 4;
                    movo = posicionn - 4;
                    moves = posicionn - 4;
                    movs = posicionn - 4;
                }
                else if (posicionn == 5)
                {
                    movn = posicionn - 5;
                    movo = posicionn - 5;
                    moves = posicionn - 5;
                    movs = posicionn - 5;
                }
                else if (posicionn == 6)
                {
                    movn = posicionn - 6;
                    movo = posicionn - 6;
                    moves = posicionn - 6;
                    movs = posicionn - 6;
                }
                else if (posicionn == 7)
                {
                    movn = posicionn - 7;
                    movo = posicionn - 7;
                    moves = posicionn - 7;
                    movs = posicionn - 7;
                }
                else if (posicionn == 8)
                {
                    movn = posicionn - 8;
                    movo = posicionn - 8;
                    moves = posicionn - 8;
                    movs = posicionn - 8;
                }
                else if (posicionn == 9)
                {
                    movn = posicionn - 9;
                    movo = posicionn - 9;
                    moves = posicionn - 9;
                    movs = posicionn - 9;
                }
                else 
                {
                    movn = posicionn - 10;
                    movo = posicionn - 10;
                    moves = posicionn - 10;
                    movs = posicionn - 10;
                }

                botones();
                
            }
            catch
            { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            guardaremos = 0;
            movn = 0;
            movo = 0;
            moves = 0;
            movs = 0;

            sumn = 0;
            sums = 0;
            sumo = 0;
            sumes = 0;

            label2.Text = movn.ToString();
            label3.Text = movs.ToString();
            label4.Text = moves.ToString();
            label5.Text = movo.ToString();           
        }
    }
}