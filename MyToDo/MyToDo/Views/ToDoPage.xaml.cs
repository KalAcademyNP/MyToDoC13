using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "todo.txt");
        public ToDoPage()
        {
            InitializeComponent();

            if (File.Exists(fileName))
            {
                editor.Text = File.ReadAllText(fileName);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, editor.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            editor.Text = String.Empty;
        }
    }
}