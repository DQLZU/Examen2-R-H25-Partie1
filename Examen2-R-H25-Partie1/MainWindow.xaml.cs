using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Examen2_R_H25_Partie1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employe> les_employes;

        public MainWindow()
        {
            Employe employe = new Employe();
            InitializeComponent();
            les_employes = new List<Employe>() {
                new Employe("12345", "Smith", "Bob", "819-555-5555", "2222", "bob.smith@cegep.com", (float)45.50),
                new Employe("12346", "Tremblay", "Ginette", "819-555-5555", "1122", "ginette.tremblay@cegep.com", 60)
            };

            DataContext = employe;

            UpdateList();
          
        }

    
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoEmploye.Text) ||
               string.IsNullOrWhiteSpace(txtNom.Text) ||
               string.IsNullOrWhiteSpace(txtPrenom.Text) ||
               string.IsNullOrWhiteSpace(txtNoPoste.Text) ||
               string.IsNullOrWhiteSpace(txtCourriel.Text))
            {
                lblSortie.Content = "Tous les champs doivent être remplis";
                lblSortie.Foreground = Brushes.Red;
            }
            else 
            {
                try { 

                    Employe employe = new Employe(txtNoEmploye.Text, txtNom.Text, txtPrenom.Text, "819-555-5555", txtNoPoste.Text, txtCourriel.Text, float.Parse(txtTax.Text, CultureInfo.InvariantCulture));
                    les_employes.Add(employe);

                    UpdateList();
                    lblSortie.Content = "";
                    
                } 
                catch (Exception ex)
                {
                    lblSortie.Content = ex.Message;
                    lblSortie.Foreground = Brushes.Red;
                }

                
                txtNoEmploye.Clear();
                txtNom.Clear();
                txtPrenom.Clear();
                txtNoPoste.Clear();
                txtCourriel.Clear();
                txtTax.Clear();
               
            }
        }


        // Cette méthode est basée sur ma solution de l’exercice de contact
        //Nettoie la ListBox et lui attribue les nouvelles valeurs de la liste les_employes
        private void UpdateList()
        {
            lstEmp.ItemsSource = null; 
            lstEmp.ItemsSource = les_employes; 
        }



    }
}
