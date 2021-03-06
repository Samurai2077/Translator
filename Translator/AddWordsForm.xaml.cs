﻿using System;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddWordForm : Window
    {
        List<TextBox> userInputField;

        public AddWordForm()
        {
            InitializeComponent();
            userInputField = new List<TextBox>();
            userInputField.Add(mainWord);
            userInputField.Add(translate);
            userInputField.Add(secondForm);
            userInputField.Add(thirdForm);
        }

        public void AddWord(object sender, RoutedEventArgs e)
        {
            using (var context = new WordContext())
            {
                ResetFieldColor();
                Word word = new Word();

                if (context.Words.Count() > 0)
                    word.WordId = (from element in context.Words select element.WordId).ToList().Last() + 1;
                else
                    word.WordId = 1;

                word.FirstForm = mainWord.Text.ToLower();
                word.Translate = translate.Text.ToLower();
                word.SecondForm = secondForm.Text.ToLower();
                word.ThirdForm = thirdForm.Text.ToLower();

                if(context.Words.Any(element => element.FirstForm == word.FirstForm))
                {
                    MessageBox.Show($"Слово {word.FirstForm} уже числится в словаре");
                    return;
                }

                if (CheckUserInput())
                {
                    ClearField();
                    context.Words.Add(word);
                    context.SaveChanges();
                }
            }
        }

        private bool CheckUserInput()
        {
            bool success = true;
            for (int i = 0; i < userInputField.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(userInputField[i].Text))
                {
                    userInputField[i].Background = Brushes.Red;
                    success = false;
                }
            }
            return success;
        }

        public void ClearField()
        {
            for (int i = 0; i < userInputField.Count; i++)
                userInputField[i].Text = string.Empty;
        }

        private void ResetFieldColor()
        {
            for (int i = 0; i < userInputField.Count; i++)
                userInputField[i].Background = Brushes.White;
        }

        private void mainWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new WordContext())
            {
                if(context.Words.Any(word => word.FirstForm == ((TextBox)sender).Text))
                {
                    mainWord.Background = Brushes.Red;
                }
                else
                {
                    mainWord.Background = Brushes.White;
                }
            }
        }
    }
}
