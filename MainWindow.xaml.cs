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
        int imgCount = 0;
        Random rnd = new Random();
        List<Image> ImgObj = new List<Image>();
        List<Button> btnObj = new List<Button>();
        List<string> imageNames_All = new List<string>() { "cat1jpg.jpg", "cat2.jpg", "cat3.jpg", "cat41.jpg" };
        

        public MainWindow()
        {
            InitializeComponent();
            BuildBtn_Click(null, null);
            List<string> imageNames = new List<string>(imageNames_All);

            foreach (UIElement ctrl in this.myGrid.Children)
            {
                if(ctrl is Button) this.btnObj.Add(ctrl as Button);
                else
                if (ctrl is Image) this.ImgObj.Add(ctrl as Image);
            }

            while(imageNames.Count > 0 && imgCount < this.count)
            {
                int img = rnd.Next(imageNames.Count);

                var uri = new Uri("pack://application:,,,/Images/" + imageNames[img]);
                var bitmap = new BitmapImage(uri);

                for(int i = 0;i < 2;i++)
                {
                    int inx = findFreeBtn();
                    Grid grid = btnObj[inx].Parent as Grid;
                    grid.Background = new ImageBrush(bitmap);
                    btnObj[inx].Tag = imageNames[img];
                }
                imgCount++;
                imageNames.RemoveAt(img);
            }
        }

        private void build()
        {
            btn1 = null;
            btn2 = null;
            mone = 0;
            count = 4;
            move = 0;
            imgCount = 0;
            this.myGrid.Children.Clear();
            btnObj.Clear();

            for(int i = 0;i < this.count*2;i++)
            {
                Grid grid = new Grid();
                grid.Margin = new Thickness(10);

                Button btn = new Button();
                btn.Click += BtnClick;

                grid.Children.Add(btn);
                this.myGrid.Children.Add(grid);

                btnObj.Add(btn);
            }
        }

        private void BuildBtn_Click(object sender, RoutedEventArgs e)
        {
            this.count = int.Parse(this.SizeTxt.Text);
            build();
        }

        private int findFreeBtn()
        {
            int inx = -1;
            int x;
            while(inx < 0)
            {
                x = rnd.Next(btnObj.Count);
                if (btnObj[x].Tag == null) 
                    inx = x;
            }
            return inx;
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
                    {
                        mone++;
                    }
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
