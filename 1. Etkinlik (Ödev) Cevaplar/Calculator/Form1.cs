using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double? sayi1, sayi2, sonuc;
        public string gecmis = "";

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length == 0)
            {
                
                MessageBox.Show("İlk sayı girilmeden işlem girilemez.");
                return;
            }

            Button button = sender as Button;


            if (labelSonuc.Text.Length > 0)
            {
                label1.Text = labelSonuc.Text.Substring(2);
                labelSonuc.Text =
                    label2.Text = String.Empty;
            }

            bool islemYapilsin = label1.Text.Length > 0 && label2.Text.Length > 0 && labelIslem.Text.Length > 0;

            if (button.Text == "√" || islemYapilsin)
            {
                button10_Click(null, null);
            }

            if (islemYapilsin)
            {
                label1.Text = labelSonuc.Text.Substring(2);
                label2.Text = String.Empty;
                labelSonuc.Text = String.Empty;
            }
            
            labelIslem.Text = button.Text;
            toolStripStatusLabel1.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (labelIslem.Text.Length == 0)
            {
                label1.Text = label1.Text + button.Text;
            }
            else
            {
                if (labelIslem.Text != "√")
                {
                    label2.Text = label2.Text + button.Text;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Karekök işleminde ikinci sayı kullanılamaz.";
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = labelIslem.Text.Length == 0 ? label1.Text : label2.Text;
            
            if (cevrilecekSayi.Length == 0)
            {
                cevrilecekSayi = "-";
            }
            else
            {
                if (cevrilecekSayi[0].ToString() == "-")
                {
                    cevrilecekSayi = cevrilecekSayi.Replace("-", "+");
                }
                else if (cevrilecekSayi[0].ToString() == "+")
                {
                    cevrilecekSayi = cevrilecekSayi.Replace("+", "-");
                }
                else
                {
                    cevrilecekSayi = cevrilecekSayi.Insert(0, "-");
                }
            }

            if (labelIslem.Text.Length == 0)
            {
                label1.Text = cevrilecekSayi;
            }
            else
            {
                label2.Text = cevrilecekSayi;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                sayi1 = Double.Parse(label1.Text);

                if (labelIslem.Text != "√")
                {
                    if (label2.Text.Length == 0)
                    {
                        
                        MessageBox.Show("İkinci sayı girilmedi.");
                        return;
                    }

                    sayi2 = Double.Parse(label2.Text);
                }

                switch (labelIslem.Text)
                {
                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "/":
                        sonuc = sayi1 / sayi2;
                        break;
                    case "*":
                        sonuc = sayi1 * sayi2;
                        break;
                    case "Pow":
                        sonuc = Math.Pow(sayi1.Value, sayi2.Value);
                        break;
                    case "Mod":
                        sonuc = sayi1 % sayi2;
                        break;
                    case "√":
                        sonuc = Math.Sqrt(sayi1.Value);
                        break;
                    case "Ekok":
                        int max = Convert.ToInt32(sayi1) * Convert.ToInt32(sayi2);                         
                        int ekok = 0;                       
                        for (int i = max; i > 0; i--)
                        {
                            if (i % sayi1 == 0 && i % sayi2 == 0)
                            {
                                ekok = i;
                            }
                        }
                        sonuc = ekok;
                        break;
                    case "Ebob":
                        int ebob = 0;
                        for (int i = 1; i < sayi1; i++)
                        {
                            if (sayi1 % i == 0 && sayi2 % i == 0)
                            {
                                ebob = i;
                            }
                        }
                        sonuc = ebob;
                        break;
                }

                labelSonuc.Text = "= " + sonuc?.ToString("F3");
                gecmis = gecmis + sayi1 + labelIslem.Text + sayi2 + labelSonuc.Text + "#";
                toolStripStatusLabel1.Text = String.Empty;
                sayi1 = null;
                sayi2 = null;
                sonuc = null;

                //dataGridViewTarihce.Rows.Add(label1.Text, labelIslem.Text, label2.Text, labelSonuc.Text.Substring(2));

            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                button5_Click(new Button {Text = e.KeyChar.ToString()}, null);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = labelIslem.Text.Length == 0 ? label1.Text : label2.Text;

            if (cevrilecekSayi.Length == 1)
            {
                cevrilecekSayi = String.Empty;
            }
            else if (cevrilecekSayi.Length > 1)
            {
                cevrilecekSayi = cevrilecekSayi.Substring(0, cevrilecekSayi.Length - 1);
            }

            if (labelIslem.Text.Length == 0)
            {
                label1.Text = cevrilecekSayi;
            }
            else
            {
                label2.Text = cevrilecekSayi;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = labelIslem.Text.Length == 0 ? label1.Text : label2.Text;

            if (!cevrilecekSayi.Contains(","))
            {
                cevrilecekSayi += ",";
            }

            if (labelIslem.Text.Length == 0)
            {
                label1.Text = cevrilecekSayi;
            }
            else
            {
                label2.Text = cevrilecekSayi;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =
                label2.Text =
                    labelIslem.Text = 
                        labelSonuc.Text = String.Empty;
        }


        private void button26_Click(object sender, EventArgs e)
        {
            string[] subs = gecmis.Split('#');
            labelgecmis.Text = String.Empty;
            foreach (var sub in subs)
            {
                labelgecmis.Text = labelgecmis.Text + "\n" + sub;
            }
            


        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void labelgecmis_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == "C")
            {
                sayi1 = null;
                sayi2 = null;
                sonuc = null;

                label1.Text =
                    label2.Text =
                        labelSonuc.Text =
                        labelIslem.Text = String.Empty;

                
            }
            else
            {
                if (labelSonuc.Text.Length > 0)
                {
                    return;
                }

                var cevrilecekSayi = String.Empty;

                if (labelIslem.Text.Length == 0)
                {
                    label1.Text = cevrilecekSayi;
                }
                else
                {
                    label2.Text = cevrilecekSayi;
                }
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }
    }
}
