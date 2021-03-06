﻿using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace BooyerMooreGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            string haystack = new TextRange(
        haystackTextBox.Document.ContentStart,
        haystackTextBox.Document.ContentEnd
    ).Text.Trim();

            if (patternTextBox.Text.Trim()==string.Empty || haystack == string.Empty)
            {
                return;
            }

            BoyerMoore.BoyerMoore bm = new BoyerMoore.BoyerMoore(patternTextBox.Text.Trim(), haystack);

            if (bm.IndexOf == -1) resultInformationTextBlock.Text = "Nije pronađen uzorak";
            else
            {
                resultInformationTextBlock.Text = " Uzorak je pronađen s početnim indeksom " + bm.IndexOf + ". \n Broj usporedbi: " + bm.numberOfComparisons;

                var haystackAsTR = new TextRange(haystackTextBox.Document.ContentStart.GetPositionAtOffset(bm.IndexOf +2), haystackTextBox.Document.ContentStart.GetPositionAtOffset(bm.IndexOf+patternTextBox.Text.Length +2));
                haystackAsTR.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                haystackAsTR.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                haystackAsTR.ApplyPropertyValue(TextElement.FontSizeProperty, (double)30);
            }
        }
    }
}
