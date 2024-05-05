using System;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceInvaders
{
    public partial class OptionsWindow : Window
    {
       
        public Slider HpSlider { get; } = new Slider();
        public Slider DiffSlider { get; } = new Slider();
        public static int StartingHp { get; set; }
        public static int Difficulty { get; set; }


        public OptionsWindow()
        {
           
            var back = Back_click; 
            Height = 600;
            Width = 400;
            Background = Brushes.Black;
            Title = "Options";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Icon = new BitmapImage(new Uri(@"X:\coding\C#\Wpf\SpaceInvaders\SpaceInvaders\images\icon.png"));

            Grid mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
          
            // Beállítjuk a Sliderek tulajgaidonsát
            HpSlider.Name = "hpSlider";
            HpSlider.Minimum = 1;
            HpSlider.Maximum = 99;
            HpSlider.Value = 100;
            HpSlider.Width = 200;
            HpSlider.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            HpSlider.TickFrequency = 10;

            DiffSlider.Name = "DiffSlider";
            DiffSlider.Minimum = 1;
            DiffSlider.Maximum = 3;
            DiffSlider.Value = 1;
            DiffSlider.Width = 200;
            DiffSlider.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            DiffSlider.TickFrequency = 10;

            // Beállítjuk a labelek tulajgaidonsát

            Label label = new Label();
            label.Content = "Starting Hp: ";
            label.Foreground = Brushes.White;

            Label label1 = new Label();
            label1.Content = "Difficulty: ";
            label1.Foreground = Brushes.White;

            Button close = new Button();
            close.Content = "Back";
            close.Foreground = Brushes.White;
            close.Height = 100;
            close.Width = 300;
            close.FontSize = 30;
            close.Background = Brushes.Transparent;
            close.Click += new RoutedEventHandler(back);

            // Hozzáadjuk a slidereket a Grid-hez
            Grid.SetRow(label, 0);
            mainGrid.Children.Add(label);   
            Grid.SetRow(HpSlider, 0);
            mainGrid.Children.Add(HpSlider);

            Grid.SetRow(label1, 1);
            mainGrid.Children.Add(label1);
            Grid.SetRow(DiffSlider, 1);
            mainGrid.Children.Add(DiffSlider);

            Grid.SetRow(close, 3);
            mainGrid.Children.Add(close);

            HpSlider.Value = StartingHp;
            DiffSlider.Value = Difficulty;

            // Beállítjuk a Grid-et az ablak tartalmára
            this.Content = mainGrid;    
        }
        public void Back_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            StartingHp = (int)HpSlider.Value;
            Difficulty = (int)DiffSlider.Value;

            window1.Show();

            this.Close();
        }
    }

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public void Start_Game(object sender, RoutedEventArgs e)
        {
            MainWindow existingWindow = new MainWindow();
            OptionsWindow optionsWindow= new OptionsWindow();

            existingWindow.hp = OptionsWindow.StartingHp;
            existingWindow.Difficulty = OptionsWindow.Difficulty;

            this.Close();

            existingWindow.Show();
        }
        private void Options(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();

            optionsWindow.Show();

            this.Close();
        }

        private void Enter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Foreground = Brushes.Black;
            }
        }

        private void Leave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Foreground = Brushes.White;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
    }
}
