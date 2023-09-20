using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void fajlBeolvasas(object sender, RoutedEventArgs e)
        {
            var tombHossz = 0;
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                lblPath.Content = fajl.FileName;

            }
            string eleresiUt = fajl.FileName;
            string[] beolvasott = File.ReadAllLines(eleresiUt, Encoding.UTF8);
            List<Fuvar> beolvasottTomb = new List<Fuvar>();
            for (int i = 0; i < beolvasott.Length; i++)
            {
                string[] splitelt = beolvasott[i].Split(' ');
                beolvasottTomb.Add(new Fuvar(Convert.ToInt32(splitelt[0]), Convert.ToDateTime((splitelt[1])), Convert.ToInt32(splitelt[2]), Convert.ToDouble(splitelt[3]), Convert.ToDouble(splitelt[4]), Convert.ToDouble(splitelt[5]), splitelt[6]));
                tombHossz++;
            }
        }
        private void Harmadik_Feladat(object sender, RoutedEventArgs e)
        {
            lblHarmadik.Content = "3. feladat: " + tombHossz;
        }

        private void Negyedik_Feladat(object sender, RoutedEventArgs e)
        {
            lblNegyedik.Content = "4. feladat: " + beolvasottTomb.Count(n => n.id == 6185) + "fuvar alatt: " + beolvasottTomb.Sum(n => n.viteldij + n.borravalo);
        }

        private void Ötödik_Feladat(object sender, RoutedEventArgs e)
        {
            lblOtodik.Content = "5. feladat: ";
            var ötodikFel = beolvasottTomb.GroupBy(n => n.fitezesiMod).Select(
                n => new
                {
                    fizetesiMod = n.Key,
                    db = n.Count()
                }
                );
            foreach (var a in otodikFel)
            {
                if (a.db > 1)
                    lblOtodik.Content += a.fizetesiMod + ":" + a.db + "fuvar" + "\n";
            }
        }

        private void Hatodik_Feladat(object sender, RoutedEventArgs e)
        {
            lblHatodik.Content = "6. feladat: " + Math.Round(beolvasottTomb.Sum(n => n.tavolsag), 2) + "km";
        }
    }
}
