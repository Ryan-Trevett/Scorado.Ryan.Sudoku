using Newtonsoft.Json;
using Scorado.Ryan.Sudoku.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Scorado.Ryan.Sudoku.WpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string baseApiUrl = "http://localhost:5141";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (button.Content.ToString() == "Get")
            {
                GetSolution();
            }
            else
            {
                SetPuzzleSquare();
            }  
        }

        private void GetSolution()
        {
            var urlToGet = $"{baseApiUrl}/Solution";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlToGet).GetAwaiter().GetResult();

                var stuff = response.Content;

                var responseContent = response.Content;

                var customerJsonString = responseContent.ReadAsStringAsync().Result;

                var cust = JsonConvert.DeserializeObject<Cell[][]>(customerJsonString);

                if (response.IsSuccessStatusCode)
                {
                    
                    //return responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
        }

        private void SetPuzzleSquare()
        {
            int xPositionToSet = int.Parse(xPosition.Text);
            int yPositionToSet = int.Parse(xPosition.Text);
            int puzzleValueToSet = int.Parse(puzzleValue.Text);

            var urlToSet = $"{baseApiUrl}/PuzzleCell?xPosition={xPositionToSet}&yPosition={yPositionToSet}&value={puzzleValueToSet}";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlToSet).GetAwaiter().GetResult();               

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    //return responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
        }
    }
}
