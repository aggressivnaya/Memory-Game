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

namespace MemoryGame1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button btn1, btn2;
        int mone = 0;
        int count = 4;
        int move = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            move++;

            btn.Visibility = Visibility.Collapsed;
            if(btn1 == null) { btn1 = btn; }
            else
            {
                if(btn2 == null)
                {
                    btn2 = btn;
                    if(count == mone + 1)
                    {
                        MessageBox.Show("Well done you finished the game \nIn " + move.ToString() + " moves");
                    }
                }
                else
                {
                    if (btn1.Tag.Equals(btn2.Tag))
                        mone++;
                    else
                    {
                        btn1.Visibility = Visibility.Visible;
                        btn2.Visibility = Visibility.Visible;
                    }
                    btn1 = btn;
                    btn2 = null;
                }
            }
        }
    }
}
