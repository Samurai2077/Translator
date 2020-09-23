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
        Word currentWord;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            using (var context = new WordContext())
            {

            }
            ShowNextWord();
        }

        public void AddWord(object sender, RoutedEventArgs e)
        {
            AddWordForm addWordForm = new AddWordForm();
            addWordForm.Owner = this;
            addWordForm.ShowDialog();
        }

        private void ShowAllWords(object sender, RoutedEventArgs e)
        {
            ShowAllWordsForm form = new ShowAllWordsForm();
            form.Owner = this;
            form.Show();
        }

        private void ShowNextWord()
        {
            ResetColorTextBox();
            ResetRightAnswerLabel();
            ResetContentTextBox();

            checkButton.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Hidden;
            using (var context = new WordContext())
            {
                if (context.Words.Count() == 0)
                    return;

                Random random = new Random((int)DateTime.Now.Ticks);
                currentWord = context.Words.ToList()[random.Next(context.Words.Count())];

                mainWord.Content = currentWord.FirstForm;
            }
        }

        private void ShowNextWord(object sender, RoutedEventArgs e)
        {
            ShowNextWord();
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }

        private void CheckAnswer()
        {
            checkButton.Visibility = Visibility.Hidden;
            nextButton.Visibility = Visibility.Visible;

            translateTextBox.Background = translateTextBox.Text.ToLower() == currentWord.Translate ? Brushes.Green : Brushes.Red;
            secondFormTextBox.Background = secondFormTextBox.Text.ToLower() == currentWord.SecondForm ? Brushes.Green : Brushes.Red;
            thirdFormTextBox.Background = thirdFormTextBox.Text.ToLower() == currentWord.ThirdForm ? Brushes.Green : Brushes.Red;

            rightTranslateLabel.Content = currentWord.Translate;
            rightSecondFormLabel.Content = currentWord.SecondForm;
            rightThirdFormLabel.Content = currentWord.ThirdForm;
        }

        private void ResetColorTextBox()
        {
            translateTextBox.Background = Brushes.White;
            secondFormTextBox.Background = Brushes.White;
            thirdFormTextBox.Background = Brushes.White;
        }

        private void ResetContentTextBox()
        {
            translateTextBox.Text = string.Empty;
            secondFormTextBox.Text = string.Empty;
            thirdFormTextBox.Text = string.Empty;
        }

        private void ResetRightAnswerLabel()
        {
            rightTranslateLabel.Content = string.Empty;
            rightSecondFormLabel.Content = string.Empty;
            rightThirdFormLabel.Content = string.Empty;
        }
    }
}
