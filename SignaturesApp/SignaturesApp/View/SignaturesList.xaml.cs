using System;
using System.IO;
using SignaturesApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturesList : ContentPage
    {
        public SignaturesList()
        {
            InitializeComponent();
            // Image = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Signatures.imageCode)));
           imageSig.Source =
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            LoadCollectionView();
        }
        private async void LoadCollectionView()
        {
            listSignatures.ItemsSource = await App.BaseDatos.GetListSignatures();
        }
    }
}