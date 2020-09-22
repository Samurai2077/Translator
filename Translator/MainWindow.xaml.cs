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

namespace Translator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {

        }

        public void AddWord(object sender, RoutedEventArgs e)
        {
            AddWordForm addWordForm = new AddWordForm();
            addWordForm.Owner = this;
            addWordForm.ShowDialog();

            using (var context = new WordContext())
            {
                Word lastWord = (from element in context.Words select element).ToList().Last();
                mainWord.Content = lastWord.FirstForm;
            }
        }

        private void ShowAllWords(object sender, RoutedEventArgs e)
        {
            ShowAllWordsForm form = new ShowAllWordsForm();
            form.Owner = this;
            form.Show();
        }
    }
}
