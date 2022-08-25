using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

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

                var cust = JsonConvert.DeserializeObject<int[][]>(customerJsonString);


                System.Data.DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                dt.Columns.Add(string.Empty, typeof(int));
                               
                for (int j = 8; j > -1; j--)
                {
                    dt.Rows.Add(cust[0][j], cust[1][j], cust[2][j], cust[3][j], cust[4][j], cust[5][j], cust[6][j], cust[7][j], cust[8][j]);
                }
                              

                grid.ItemsSource = dt.DefaultView;



                //DataGridTextColumn textColumn = new DataGridTextColumn();
                //textColumn.Header = "First Name";
                //textColumn.Binding = new Binding("FirstName");
                //grid.Columns.Add(textColumn);

                //grid.Items.Add()

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
