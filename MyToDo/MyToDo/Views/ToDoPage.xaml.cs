using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyToDo.Models;

namespace MyToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var todo = (ToDo)BindingContext;
            if (!string.IsNullOrEmpty(todo.FileName))
            {
                editor.Text = File.ReadAllText(todo.FileName);
            }

        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            if (string.IsNullOrEmpty(todo.FileName))
            {
                //create a new file
                todo.FileName = Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                            $"{Path.GetRandomFileName()}.notes.txt");
            }

            File.WriteAllText(todo.FileName, editor.Text);
            await Task.Delay(1000);
            await Navigation.PopModalAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            if (File.Exists(todo.FileName))
            {
                File.Delete(todo.FileName);
            }
            editor.Text = String.Empty;
            await Task.Delay(1000);
            await Navigation.PopModalAsync();
        }
    }
}