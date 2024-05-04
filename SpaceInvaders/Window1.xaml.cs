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
        // Definiáljuk a hpSlider-t publikus tulajdonságként
        public Slider HpSlider { get; } = new Slider();
        public Slider DiffSlider { get; } = new Slider();


        public OptionsWindow()
        {
            Window1 window1 = new Window1();
            var start = Start_Options;
            var back = Back_click;
            Height = 600;
            Width = 400;
            Background = Brushes.Black;
            Title = "Options";
            Icon = new BitmapImage(new Uri(@"X:\coding\C#\Wpf\SpaceInvaders\SpaceInvaders\images\icon.png"));

            Grid mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
          
            // Beállítjuk a Sliderek tulajgaidonsát
            HpSlider.Name = "hpSlider";
            HpSlider.Minimum = 1;
            HpSlider.Maximum = 100;
            HpSlider.Value = 100;
            HpSlider.Width = 200;
            HpSlider.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
            HpSlider.TickFrequency = 10;

            DiffSlider.Name = "DiffSlider";
            DiffSlider.Minimum = 1;
            DiffSlider.Maximum = 3;
            DiffSlider.Value = 3;
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


            Button button = new Button();
            button.Content = "Start";
            button.Foreground = Brushes.White;
            button.Height = 100;
            button.Width = 300;
            button.FontSize = 30;
            button.Background = Brushes.Transparent;
            button.Click += new RoutedEventHandler(start);

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


            Grid.SetRow(button, 2);
            mainGrid.Children.Add(button);

            Grid.SetRow(close, 3);
            mainGrid.Children.Add(close);




            // Beállítjuk a Grid-et az ablak tartalmára
            this.Content = mainGrid;
            
        }
        public void Back_click(object sender, RoutedEventArgs e)
        {
           
            Window1 window1 = new Window1();
            OptionsWindow optionsWindow = new OptionsWindow();



            window1.Show();

            this.Close();




        }
        public void Start_Options(object sender, RoutedEventArgs e)
        {
            // Létrehozzuk az OptionsWindow objektumot
            OptionsWindow optionsWindow = new OptionsWindow();

           

            // Az új ablak létrehozása és a hp tulajdonság beállítása
            MainWindow existingWindow = new MainWindow();
            existingWindow.hp = (int)HpSlider.Value;
            existingWindow.Difficulty = (int)DiffSlider.Value;

            // Az új ablak létrehozása és a hp tulajdonság beállítása
            this.Close();

            existingWindow.Show();

            // Az aktuális ablak bezárása

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
            // Létrehozzuk az OptionsWindow objektumot
            OptionsWindow optionsWindow = new OptionsWindow();

            // Az OptionsWindow megjelenítése
            optionsWindow.Show();

            // Az aktuális ablak bezárása
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
