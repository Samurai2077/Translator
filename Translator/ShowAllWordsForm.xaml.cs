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
using System.Windows.Shapes;

namespace Translator
{
    /// <summary>
    /// Логика взаимодействия для ShowAllWordsForm.xaml
    /// </summary>
    public partial class ShowAllWordsForm : Window
    {
        public ShowAllWordsForm()
        {
            InitializeComponent();
            ShowWords();
        }

        private void ShowWords()
        {
            using (var context =  new WordContext())
            {
                foreach (var word in context.Words)
                {
                    wordsList.Items.Add(word);
                }
            }
        }
    }
}
