using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace MedizinRezeptErsteller
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sind die Angaben korrekt?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string name = txtName.Text;
                string medikamentName = txtMedikamentName.Text;
                string symptome = txtSymptome.Text;
                string erkrankung = txtErkrankung.Text;
                string ueberweisung = txtUeberweisung.Text;
                string arztName = txtArztName.Text;

                string rezeptText = $"Name: {name}\nMedikament Name: {medikamentName}\nSymptome: {symptome}\nMögliche Erkrankung: {erkrankung}\nÜberweisung (Arzt): {ueberweisung}\nArzt Name: {arztName}";

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog.Filter = "Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, rezeptText);
                    MessageBox.Show("Rezept erfolgreich erstellt und gespeichert.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
