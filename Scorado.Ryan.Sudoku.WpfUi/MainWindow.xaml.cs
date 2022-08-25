using Newtonsoft.Json;
using System;
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
        private static readonly string baseApiUrl = "http://localhost:5141";

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
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlToGet).GetAwaiter().GetResult();
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var solution = JsonConvert.DeserializeObject<int[][]>(responseString);

                    DataTable solutionDataTable = new DataTable();

                    for (int i = 0; i < 9; i++)
                    {
                        solutionDataTable.Columns.Add(string.Empty, typeof(int));
                    }

                    for (int j = 8; j > -1; j--)
                    {
                        solutionDataTable.Rows.Add(solution[0][j], solution[1][j], solution[2][j], solution[3][j], solution[4][j], solution[5][j], solution[6][j], solution[7][j], solution[8][j]);
                    }

                    grid.ItemsSource = solutionDataTable.DefaultView;

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Anything could have gone wrong.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Anything could have gone wrong. {ex.Message}");
            }            
        }

        private void SetPuzzleSquare()
        {
            setResult.Content = string.Empty;

            try
            {
                int xPositionToSet = int.Parse(xPosition.Text);
                int yPositionToSet = int.Parse(yPosition.Text);
                int puzzleValueToSet = int.Parse(puzzleValue.Text);

                var urlToSet = $"{baseApiUrl}/PuzzleCell?xPosition={xPositionToSet}&yPosition={yPositionToSet}&value={puzzleValueToSet}";

                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlToSet).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        setResult.Content = "Set was successful";
                    }
                    else
                    {
                        MessageBox.Show("Anything could have gone wrong.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Anything could have gone wrong. {ex.Message}");
            }
        }
    }
}
