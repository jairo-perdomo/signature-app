using SignaturePad.Forms;
using SignaturesApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SignaturesApp
{
    public partial class MainPage : ContentPage
    {
        string valueBase64;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Jpeg);
            // var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if(String.IsNullOrWhiteSpace(name.Text) == true || String.IsNullOrWhiteSpace(description.Text) == true)
            {
                await DisplayAlert("Error", "Se deben llenar los campos de nombre y descripcion", "Aceptar");
            }

            var signatureToSave = new Signatures
            {
                imageCode = valueBase64,
                name = name.Text,
                description = description.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if(result != 1)
            {
                await DisplayAlert("Error", "Ocurrio un error, porfavor intente de nuevo", "Aceptar");

            }

        }
            
        private void ViewSignaturesButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            PadView.Clear();
        }
    }
}
